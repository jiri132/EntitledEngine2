using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using System.Collections;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

using EntitledEngine2.Core;
using EntitledEngine2.Core.Shapes;
using EntitledEngine2.Engine.Core.Maths;
using matrix = EntitledEngine2.Engine.Core.Maths.Matrix;
using EntitledEngine2.Core.ECS;

namespace EntitledEngine2.Engine
{
	class Canvas : Form
	{
		public Canvas()
		{
			this.DoubleBuffered = true;
		}
	}

	public abstract class Engine
	{
		#region Publics to change

		//screen information
		public Vector2 ScreenSize;
		public static Color BackgroundColor = Color.Beige;

		public Vector2 CameraZoom = new Vector2(.5f, .5f); //dont really mess with the camera zoom it is not really needed
		public Vector2 CameraPosition = Vector2.Zero; //position will automaticly go to the middle when the screen starts
		public float CameraAngle = 0; //rotation of the camera in 2D on Z axis R to L

		#endregion

		#region Privates dont touch 

		private string Title;

		private Canvas Window = null;
		private Thread GameLoopThread = null;

		//list for rendering all the sprites
		private static List<Entity> e_list = new List<Entity>();

		public static void RegisterSprite(Entity e)
		{
			e_list.Add(e);
		}
		public static void UnRegisterSprite(Entity e)
		{
			e_list.Remove(e);
		}
		#endregion


		public Engine(Vector2 ScreenSize, string Title)
		{
			//make the affected type of engine usable
			this.ScreenSize = ScreenSize;
			this.Title = Title;
			//give all behaviours of the window
			Window = new Canvas();
			Window.Size = new Size((int)this.ScreenSize.x, (int)this.ScreenSize.y);
			Window.Text = this.Title;
			Window.Paint += Renderer;
			Window.KeyDown += Window_KeyDown;
			Window.KeyUp += Window_KeyUp;

			GameLoopThread = new Thread(GameLoop);
			GameLoopThread.Start();


			Console.WriteLine("[SYSTEM] App Initialized");
			Application.Run(Window);
		}


		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			GetKeyUp(e);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			GetKeyDown(e);
		}

		void GameLoop()
		{
			OnLoad();
			Console.WriteLine("[APP] Game Data Loaded");
			while (GameLoopThread.IsAlive)
			{
				try
				{
					OnDraw();

					Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });

					OnUpdate();

					Thread.Sleep(8);
				}
				catch (Exception e)
				{
					if (!Window.Visible)
					{
						Console.WriteLine(e.ToString());
					}
				}
			}
		}


		#region Renderer
		private void Renderer(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			g.Clear(BackgroundColor);

			g.TranslateTransform(CameraPosition.x + 256, CameraPosition.y + 256);
			g.RotateTransform(CameraAngle);
			g.ScaleTransform(CameraZoom.x, CameraZoom.y);

			foreach (Entity et in e_list.ToArray())
			{
				Sprite[] s = et.GetSprites();
                for (int x = 0; x < s.Length; x++)
                {
					//Pen p = new Pen(s.GetColor(),5);
					SolidBrush b = new SolidBrush(s[x].GetColor());

					List<Point> points = new List<Point>();
					for (int i = 0; i < s[x].GetDrawingPoints().Length; i++)
					{
						//get all points
						Vector2 v = s[x].GetDrawingPoints()[i];

						//make rotation
						Vector2 rot = new Vector2();
						rot = Vector2.MatMul(matrix.RotationZ(et.transform.zAxis), v);
						v = rot;

						//add points postion anf into the drawing
						points.Add(new Point((int)(et.transform.Position.x + et.transform.Scale.x * v.x), (int)(et.transform.Position.y + et.transform.Scale.y * v.y)));
					}
					g.FillPolygon(b, points.ToArray());
				}
			}
		}
		#endregion

		#region Abstract functions
		public abstract void OnLoad();
		public abstract void OnUpdate();
		public abstract void OnDraw();

		
		public abstract void GetKeyDown(KeyEventArgs e);
		public abstract void GetKeyUp(KeyEventArgs e);
		#endregion


	}

}

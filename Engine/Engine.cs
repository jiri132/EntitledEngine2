using System.Drawing.Drawing2D;
using System.Windows.Forms;

using System.Collections;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

using EntitledEngine2.Engine.Core;
using EntitledEngine2.Engine.Core.Shapes;
using System;
using System.Drawing;

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
		public Color BackgroundColor = Color.Beige;

		public Vector2 CameraZoom = new Vector2(.5f, .5f); //dont really mess with the camera zoom it is not really needed
		public Vector2 CameraPosition = Vector2.Zero(); //position will automaticly go to the middle when the screen starts
		public float CameraAngle = 0; //rotation of the camera in 2D on Z axis R to L

		#endregion

		#region Privates dont touch 

		private string Title;

		private Canvas Window = null;
		private bool normalizedWindow = true;
		private Thread GameLoopThread = null;

		//list for rendering all the sprites
		private static List<Sprite> s_list = new List<Sprite>();

		public static void RegisterSprite(Sprite s)
		{
			s_list.Add(s);
		}
		public static void UnRegisterSprite(Sprite s)
		{
			s_list.Add(s);
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

			g.TranslateTransform(CameraPosition.x, CameraPosition.y);
			g.RotateTransform(CameraAngle);
			g.ScaleTransform(CameraZoom.x, CameraZoom.y);

			foreach (Sprite s in s_list)
			{
				Pen p = new Pen(s.GetColor(),5);

				List<Point> points = new List<Point>();
				for (int i = 0; i < s.GetDrawingPoints().Length; i++)
				{
					Vector2 v = s.GetDrawingPoints()[i];
					points.Add(new Point((int)v.x,(int)v.y));
				}

				g.DrawPolygon(p,points.ToArray());
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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using System.Collections;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

using matrix = EntitledEngine2.Engine.Core.Maths.Matrix;
using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Physics;
using EntitledEngine2.Engine.Core;
using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.Maths;

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

		public static float deltaTime;
		#endregion

		#region Privates dont touch 

		private string Title;

		private Canvas Window = null;
		private Thread GameLoopThread = null;

		//list for rendering all the sprites
		private static List<Entity> e_list = new List<Entity>();
		private List<Rigidbody> r_list = new List<Rigidbody>(); 
		private List<Collider> c_list = new List<Collider>();

		DateTime time1 = DateTime.Now;
		DateTime time2 = DateTime.Now;

		public static void RegisterEntity(Entity e)
		{
			e_list.Add(e);
		}
		public static void UnRegisterEntity(Entity e)
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
			//load in entitys
			OnLoad();
			//get all the colliders and rigidbodys
			getRigidbodys();
			getColliders();
			//check for possible collisions
			CombinationCalculation();
			Console.WriteLine("[APP] Game Data Loaded");

			while (GameLoopThread.IsAlive)
			{
				try
				{
					OnDraw();

					// This is it, use it where you want, it is time between
					// two iterations of while loop
					time2 = DateTime.Now;
					deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
					time1 = time2;

					Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });

					//physics update
					CombinationCalculation();
					PhysicsUpdate();

					//player code update
					OnUpdate();

					Thread.Sleep(8);
				}
				catch (Exception e)
				{
					if (!Window.Visible)
					{
						Console.WriteLine(e.ToString());
						Application.Exit();
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
				if (et.lineRenderer != null)
                {
					Pen p = new Pen(et.lineRenderer.GetLineColor(),4);

					Vector2[] point = et.lineRenderer.GetPoints();

					//i is the second on in the array so i-1 makes it to the first
                    for (int i = 1; i < point.Length; i++)
                    {
						g.DrawLine(p, point[i-1].x, point[i - 1].y, point[i].x, point[i].y);
					}
                }

				if (et.spriteRenderer != null)
                {
					SpriteRenderer s = et.GetSprite();

					if (s != null && s.GetSpriteType() == SpriteType.SPRITE)
					{
						g.DrawImage(s.GetImageSprite(), et.transform.Position.x, et.transform.Position.y, et.transform.Scale.x, et.transform.Scale.y);
						continue;
					}

					//Pen p = new Pen(s.GetColor(),5);
					SolidBrush b = new SolidBrush(s.GetColor());

					List<Point> points = new List<Point>();
					for (int i = 0; i < s.GetDrawingPoints().Length; i++)
					{
						//get all points
						Vector2 v = s.GetDrawingPoints()[i];

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

		#region Physics
		class Combinations
        {
			public Combinations(Rigidbody rb, Collider col)
            {
				this.rb = rb;
				this.col = col;

				one = rb.ownEntity.name;
				two = col.ownEntity.name;

				//Debug.Log($"link between {rb.ownEntity.name} & {col.ownEntity.name}");
            }

			public string one;
			public string two;

			
			public Rigidbody rb = null;
			public Collider col = null;
        }

		private List<Combinations> combs = new List<Combinations>();

        private void getRigidbodys()
        {
            foreach (Entity entity in e_list)
            {
				Rigidbody rb = entity.rigidbody;
				//guard close to continue if the rigidbody is null
				if (rb == null) { continue; }

				r_list.Add(rb);
            }
			//Debug.Log(r_list.Count.ToString());
		}
		private void getColliders()
        {
			foreach (Entity entity in e_list)
			{
				Collider col = entity.collider;
				//guard close to continue if the collider is null
				if (col == null) { continue; }

				c_list.Add(col);
			}
			//Debug.Log(c_list.Count.ToString());
		}
		private void CombinationCalculation()
        {

			combs.Clear();

            //determine all combinations
            foreach (Rigidbody rigidbody in r_list)
            {
				
				if (rigidbody.ownCollider == null) { continue; }

                foreach (Collider collider in c_list)
                {
					bool Double = false;
					//dont check if its on the same object
					if (rigidbody.ownCollider == collider) { continue; }

					//checking if it is a duplicate
					for (int i = 0; i < combs.ToArray().Length; i++)
					{
						if (combs[i].one == collider.ownEntity.name && combs[i].two == rigidbody.ownEntity.name)
						{
							Double = true;
							break;
						}
					}
					if (Double) { continue; }

					if (rigidbody.position.x < collider.position.x + collider.scale.x &&
						rigidbody.position.x + rigidbody.scale.x > collider.position.x)
                    {
						combs.Add(new Combinations(rigidbody,collider));
                    }

				}
            }

			//Debug.Log(combs.Count.ToString());
        }
		private void PhysicsUpdate()
        {
            foreach (Combinations combination in combs)
            {
				Rigidbody rb = combination.rb;
				Collider col = combination.col;


                if (rb.ownCollider.TestCollision(col))
                {
					//solve the collidings
					if (col.ownEntity.rigidbody == null)
                    {
						float m2 = 1f;
						Vector2 v2 = new Vector2(0,0);

						//only do the velocity for v1

						float part1 = (2 * m2) / (rb.Mass + m2);
						Vector2 part2 = Mathf.InnerProduct((rb.Velocity - v2), (rb.position - col.position)) / (Vector2.Normalized(rb.position - col.position) * Vector2.Normalized(rb.position - col.position));
						Vector2 part3 = (rb.position - col.position);

						//multiplie these 2 parts and you get a really weird answer back
						//when converting to ints it got overflown which it shouldn't
						Debug.Log(part1.ToString());
						Debug.Log(part2.ToString());
						Debug.Log(part3.ToString());

						Debug.Log((part2 * part3) .ToString());

						//rb.Velocity = rb.Velocity - (2 * m2 / (rb.Mass + m2)) * (Mathf.InnerProduct((rb.Velocity - v2), (rb.position - col.position)) / (Vector2.Normalized(rb.position - col.position) * 2)) * (rb.position - col.position);
						rb.Velocity = rb.Velocity - part1 * part2 * part3;

						Debug.Log("vel after" + rb.Velocity.ToString());
                    }else
                    {
						Rigidbody rb2 = col.ownEntity.rigidbody;


						//get toal energy before
						//divide the energy in to who has what
						//apply the multipliers to the correct rigidbodys
						Vector2 KE1B = (rb.Velocity * rb.Mass < 0) ? rb.Velocity * rb.Mass * -1 : rb.Velocity * rb.Mass, KE2B = (rb2.Velocity * rb2.Mass < 0) ? rb2.Velocity * rb2.Mass * -1 : rb2.Velocity * rb2.Mass;

						Vector2 totalKineticEnergyBefore = KE1B + KE2B;

						//get new energies
						Vector2 vel1After = rb.Velocity  - (2 * rb2.Mass)/ (rb.Mass + rb2.Mass) * (Mathf.InnerProduct((rb.Velocity - rb2.Velocity), (rb.position - rb2.position)) / (Vector2.Normalized(rb.position - rb2.position) * Vector2.Normalized(rb.position - rb2.position))) * (rb.position - rb2.position);
						Vector2 vel2After = rb2.Velocity - (2 * rb.Mass) / (rb.Mass + rb2.Mass) * (Mathf.InnerProduct((rb2.Velocity - rb.Velocity), (rb2.position - rb.position)) / (Vector2.Normalized(rb2.position - rb.position) * Vector2.Normalized(rb2.position - rb.position))) * (rb2.position - rb.position);

						Vector2 KE1A = (vel1After * rb.Mass < 0) ? vel1After * rb.Mass * -1 : vel1After * rb.Mass, KE2A = (vel2After * rb2.Mass < 0) ? vel2After * rb2.Mass * -1 : vel2After * rb2.Mass;

						Debug.CustomLog($"KE1A {KE1A} KE2A{KE2A}", ConsoleColor.Blue);

						//check how much each velocity has energy
						Vector2 totalKineticEnergyAfter = KE1A.Positive() + KE2A.Positive();

						Debug.Log($"velocity 1: {vel1After} velocity 2: {vel2After}");


						//Vector2 KE1P = KE1 / totalKineticEnergyAfter, KE2P = KE2 / totalKineticEnergyAfter;

						Debug.Log($"\nbefore collision KE: {totalKineticEnergyBefore} \nAfter collision KE {totalKineticEnergyAfter} \nDifference: {totalKineticEnergyBefore / totalKineticEnergyAfter} After Difference: {totalKineticEnergyAfter * (totalKineticEnergyBefore / totalKineticEnergyAfter)}");

						Vector2 multiplierDifference = totalKineticEnergyAfter / totalKineticEnergyBefore;
						vel1After /= multiplierDifference;
						vel2After /= multiplierDifference;
						
						//new kinetic energy limited to the same amount before
						KE1A = (vel1After * rb.Mass < 0) ? vel1After * rb.Mass * -1 : vel1After * rb.Mass;
						KE2A = (vel2After * rb2.Mass < 0) ? vel2After * rb2.Mass * -1 : vel2After * rb2.Mass;
						totalKineticEnergyAfter = KE1A.Positive() + KE2A.Positive();

						Debug.CustomLog($"KE1A {KE1A} KE2A{KE2A}",ConsoleColor.Blue);

						//making the kinetic energy also on the velocitys
						rb.Velocity = KE1A;
						rb2.Velocity = KE2A;



						Debug.Log(rb.Velocity.ToString());
						Debug.Log(rb2.Velocity.ToString());

					}

					Debug.Log("hitobjct");
					continue;
				}
				

				//simple old AABB
				/*if (rb.position.x < col.position.x + col.scale.x &&
					rb.position.x + rb.scale.x > col.position.x &&
					rb.position.y < col.position.y + col.scale.y &&
					rb.position.y + rb.scale.y > col.position.y)
				{
					//hit the object
				}*/

			}

            foreach (Rigidbody rb in r_list)
            {
				if(rb.position.x - rb.ownCollider.radius < -ScreenSize.x || rb.position.x + rb.ownCollider.radius > ScreenSize.x )
                {
					rb.Velocity.x *= -1;
                }
				if (/*rb.position.y - rb.ownCollider.radius < -ScreenSize.y ||*/ rb.position.y + rb.ownCollider.radius > ScreenSize.y)
				{
					rb.Velocity.y *= -1;
				}



				//Debug.Log($"[{rb.ownEntity.name}] Velocity : " + rb.Velocity.ToString());
				//Debug.Log($"[{rb.ownEntity.name}] Position : " + rb.position.ToString() + "\n");

				rb.Velocity.y += rb.Gravity;
				rb.UpdateBody();
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

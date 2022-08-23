using System.Windows.Forms;
using System.Drawing;


using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.Colliders;

using EntitledEngine2.Engine.Core.UI;
using EntitledEngine2.Engine.Core;

namespace EntitledEngine2
{
	class App : Engine.Engine
	{

		public App() : base(new Vector2(512, 512), "Entitled Engine Demo") { }

		Entity a = new Entity("a", EntityType.Physics);
		Entity b = new Entity("b", EntityType.Physics);
		Entity c = new Entity("c", EntityType.Physics);
		//Entity Line = new Entity("line");
		//Entity Lineb = new Entity("lineB");

		Text Text = new Text("hello", new Vector2(0,0),true);



		int i = 0;
		public override void OnDraw()
		{
			Text.text = i.ToString();

		}

		public override void OnLoad()
		{
			BackgroundColor = Color.Black;


            //setting the components values
            a.transform.Scale = new Vector2(30, 30);
            a.SetSprite(new Circle(Color.Blue, ""));
            a.SetCollider(ColliderType.Circle);
            a.rigidbody.Velocity = new Vector2(200, 0);
            a.rigidbody.Gravity = 9.81f;
			
            b.transform.Position = new Vector2(-100, -100);
            b.transform.Scale = new Vector2(60, 60);
            b.SetSprite(new Circle(Color.Green, ""));
            b.SetCollider(ColliderType.Circle);
            b.rigidbody.Velocity = new Vector2(-200, 0);
            b.rigidbody.Gravity = 9.81f;

			c.transform.Position = new Vector2(-300, -300);
			c.transform.Scale = new Vector2(40, 40);
			c.SetSprite(new Circle(Color.Red, ""));
			c.SetCollider(ColliderType.Circle);
			c.rigidbody.Velocity = new Vector2(-125, 0);
			c.rigidbody.Gravity = 9.81f;

			a.AddComponent(Component_TYPE.LINE_RENDERER);
			b.AddComponent(Component_TYPE.LINE_RENDERER);
			c.AddComponent(Component_TYPE.LINE_RENDERER);

			b.lineRenderer.AddPoint(b.transform.Position);
			a.lineRenderer.AddPoint(a.transform.Position);
			c.lineRenderer.AddPoint(c.transform.Position);

			a.lineRenderer.SetTrail(true);
			b.lineRenderer.SetTrail(true);
			c.lineRenderer.SetTrail(true);

			a.lineRenderer.SetLineColor(Color.Green);
			c.lineRenderer.SetLineColor(Color.Red);
		}

		float time = 0;
		public override void OnUpdate()
		{
			//b.rigidbody.Gravity = 0f;
			Text.SetPosition(a.transform.Position - a.transform.Scale / 4);
			time += Engine.Engine.deltaTime;
			//Debug.Log(Line.lineRenderer.GetPoints().ToString());
			if (time > 0.1)
			{
				
				time = 0;
				a.lineRenderer.UpdateTrail(a.transform.Position);
				b.lineRenderer.UpdateTrail(b.transform.Position);
			}

		}

		public override void OnCollision(Collider other)
		{
			i++;
			
		}

		public override void GetKeyDown(KeyEventArgs key)
		{
			switch(key.KeyCode)
            {
				case Keys.A:
					break;
				case Keys.W :
					break;
				case Keys.S:
					break;
				case Keys.D:
					break;
				default:
					break;
				case Keys.Escape:
					//press escape to close th application
					System.Environment.Exit(0);
					break;
				case Keys.Space:
					break;
			}
		}

		public override void GetKeyUp(KeyEventArgs key)
		{
			//throw new NotImplementedException();
		}

        
    }
}

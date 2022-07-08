using System.Windows.Forms;
using System.Drawing;


using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.Colliders;

namespace EntitledEngine2
{
	class App : Engine.Engine
	{

		public App() : base(new Vector2(528, 550), "Entitled Engine Demo") { }

		Entity a = new Entity("a", EntityType.Physics);
		Entity b = new Entity("b", EntityType.Physics);
		public override void OnDraw()
		{
			
		}

		public override void OnLoad()
		{
			BackgroundColor = Color.Black;

			//setting the components values
			a.transform.Scale = new Vector2(60,60);
			a.SetSprite(new Circle(Color.Blue, ""));
			a.SetCollider(ColliderType.Circle);
			a.rigidbody.Velocity = new Vector2(0,0);
			a.rigidbody.Gravity  = 9.81f;

			b.transform.Position = new Vector2(-50, -50);
			b.transform.Scale = new Vector2(60, 60);
			b.SetSprite(new Circle(Color.Green, ""));
			b.SetCollider(ColliderType.Circle);
			b.rigidbody.Velocity = new Vector2(-10, -10);
			b.rigidbody.Gravity = 9.81f;
		}

		public override void OnUpdate()
		{
			//b.rigidbody.Gravity = 0f;
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

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
		Entity b = new Entity("floor", EntityType.Collider);

		Entity Debugger = new Entity("deugger", EntityType.Sprite);
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

			b.transform.Position = new Vector2(0,500);
			b.transform.Scale = new Vector2(200, 30);
		}

		float i;
		public override void OnUpdate()
		{
			/*i += 0.01f;
			Debugger.transform.Position = a.transform.Position;
			//Debugger.transform.Scale = a.transform.Scale * 1.5f;
			Debugger.transform.Scale.y = a.transform.Scale.xy;
			Debugger.transform.Scale.x = a.transform.Scale.xy;
			//Debugger.transform.Rotate(i);*/
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

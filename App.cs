using System.Windows.Forms;
using System.Drawing;


using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Shapes;

namespace EntitledEngine2
{
	class App : Engine.Engine
	{

		public App() : base(new Vector2(528, 550), "Entitled Engine Demo") { }

		Entity a = new Entity("a");
		Entity b = new Entity("b");
		public override void OnDraw()
		{
			
		}

		public override void OnLoad()
		{
			BackgroundColor = Color.Black;

			//setting the components values
			a.transform.Scale = new Vector2(60,60);
			a.AddComponent(Component_TYPE.SPRITE);
			a.SetSprite(new Circle(Color.Blue, ""));
			a.AddComponent(Component_TYPE.COLLIDER);

			b.transform.Scale = new Vector2(30, 30);
			b.transform.Position = new Vector2(100, 100);
			b.AddComponent(Component_TYPE.SPRITE);
			b.getSprite.SetColor(Color.White);
			b.AddComponent(Component_TYPE.COLLIDER);
		}

		float i;
		float j;
		public override void OnUpdate()
		{
			i += 0.01f;
			j += 0.034f;
			a.transform.Rotate(i);
			b.transform.Rotate(j);
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

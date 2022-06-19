using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using EntitledEngine2.Core.Shapes;
using EntitledEngine2.Engine.Components;
using EntitledEngine2.Core.ECS;
using EntitledEngine2.Core;



namespace EntitledEngine2
{
	class App : EntitledEngine2.Engine.Engine
	{

		public App() : base(new Vector2(528, 550), "Entitled Engine Demo") { }

		Entity e = new Entity("First entity Component system");
		public override void OnDraw()
		{
			//throw new NotImplementedException();
		}

		public override void OnLoad()
		{
			BackgroundColor = Color.Black;
			CameraPosition = new Vector2(256, 256);

			//etting the components values
			e.transform.Scale = new Vector2(30,30);
			

			e.AddComponent(Component_TYPE.SPRITE);
			e.SetSprite(new Circle(Color.Red, "Setted Circle"));

		}

		float i;
		int speed = 5;
		public override void OnUpdate()
		{
			//rotate and move forward
			i += 0.01f;
			e.transform.Rotate(i);
			e.transform.Position += e.transform.GetForwardVector() / 2f;

			//spawn trail
			Entity entity = new Entity("testing obstacle");
			entity.AddComponent(Component_TYPE.SPRITE);
			entity.transform.Position = e.transform.Position;
			
		}

		public override void GetKeyDown(KeyEventArgs key)
		{
			if (key.KeyCode == Keys.A)
            {
				e.transform.Position.x -= speed;
			}
			if (key.KeyCode == Keys.W)
			{
				e.transform.Position.y -= speed;
			}
			if (key.KeyCode == Keys.S)
			{
				e.transform.Position.y += speed;
			}
			if (key.KeyCode == Keys.D)
			{
				e.transform.Position.x += speed;
			}
		}

		public override void GetKeyUp(KeyEventArgs key)
		{
			//throw new NotImplementedException();
		}

	}
}

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


		//Triangle T = new Triangle(new Vector2(200,200),new Vector2(30,30), Color.White,"First Try Inheritance");
		//Plane P = new Plane(new Vector2(400,400), new Vector2(30,30),Color.White, "First try plane");
		//Circle C = new Circle(new Vector2(300,300), 15,Color.White, "circle");

		Entity e = new Entity("First entity Component system");

		public override void OnDraw()
		{
			//throw new NotImplementedException();
		}

		public override void OnLoad()
		{
			BackgroundColor = Color.Black;

			//etting the components values
			e.SetPosition(new Vector2(200,200));
			e.SetScale(new Vector2(30,30));
			e.AddComponent(Component_TYPE.SPRITE);
			e.SetSprite(new Triangle(e.transform.Position, e.transform.Scale, Color.Red, "Setted Triangle"));
			e.transform.Rotate(1f/360 * 50);
		}

		public override void OnUpdate()
		{
			//updateing the entitys position
			e.SetPosition(new Vector2( e.transform.Position.x / 250 + e.transform.Position.x,e.transform.Position.y));
			e.GetSpritePosition();
			//Console.WriteLine(e.transform.Position.ToString());
		}


		public override void GetKeyDown(KeyEventArgs e)
		{
			//throw new NotImplementedException();
		}

		public override void GetKeyUp(KeyEventArgs e)
		{
			//throw new NotImplementedException();
		}

	}
}

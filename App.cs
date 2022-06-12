using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EntitledEngine2.Core.Shapes;

namespace EntitledEngine2
{
	class App : EntitledEngine2.Engine.Engine
	{

		public App() : base(new Vector2(528, 550), "Entitled Engine Demo") { }

		Triangle T = new Triangle(new Vector2(200,200),new Vector2(20,20), "First Try Inheritance");


		public override void OnDraw()
		{
			//throw new NotImplementedException();
		}

		public override void OnLoad()
		{
			//throw new NotImplementedException();
		}

		public override void OnUpdate()
		{
			//throw new NotImplementedException();
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

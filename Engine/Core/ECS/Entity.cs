using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using EntitledEngine2.Engine.Components;
using EntitledEngine2.Core.Shapes;

namespace EntitledEngine2.Core.ECS
{
    /// <summary>
    /// Entity Component System V1.0
    /// </summary>



    public class Entity
    {
        public string name { private set; get; }
        public Transform transform { private set; get; }
        public List<Component> Components = new List<Component>();

        public Entity(string name)
        {
            this.name = name;
            transform = new Transform();
        }

        public void AddComponent(Component_TYPE t)
        {
            switch (t)
            {
                case Component_TYPE.SPRITE:
                    Components.Add(new Plane(transform.Position, transform.Scale, Color.Red, "Default"));
                    break;
                default:
                    break;
            }
        }

		public void DisposeSprite()
		{
			//Sprite _s;
			foreach (Sprite sprite in Components.ToArray())
			{
				sprite.Dispose();

			}
		}

		public void SetSprite(Sprite s) => DisposeSprite();
		

        public void SetPosition(Vector2 v)
        {
            transform.Position = v;
            foreach (Sprite sprite in Components)
            {
                sprite.UpdatePos(v);
				sprite.Rotate(transform.zAxis);
            }
        }

		public void GetSpritePosition()
		{
			foreach (Sprite sprite in Components)
			{
				Console.WriteLine(sprite.GetPosition());
			}
		}

        public void SetScale(Vector2 v)
        {
            transform.Scale = v;
        }

    }
}

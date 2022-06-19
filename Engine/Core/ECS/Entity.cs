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
            Engine.Engine.RegisterSprite(this);
        }

        public void AddComponent(Component_TYPE t)
        {
            switch (t)
            {
                case Component_TYPE.SPRITE:
                    Components.Add(new Plane(Color.Red, "Default"));
                    break;
                default:
                    break;
            }
        }

		public void DisposeSprite()
		{
			foreach (Sprite sprite in Components.ToArray())
			{
                Sprite s = sprite;
                Components.Remove(s);
                return;
			}
        }

		public void SetSprite(Sprite s)
        {
            DisposeSprite();
            Components.Add(s);
        }
		public Sprite[] GetSprite()
        {
            List<Sprite> s_a = new List<Sprite>();
            foreach (Sprite s in Components.ToArray())
            {
                s_a.Add(s);
            }
            return s_a.ToArray();
        }
    }
}

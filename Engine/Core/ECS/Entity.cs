using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using EntitledEngine2.Engine.Components;
using EntitledEngine2.Core.Shapes;
using EntitledEngine2.Engine.Core.Colliders;

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
                case Component_TYPE.COLLIDER:
                    Components.Add(new PlaneCollider(transform.Scale,Vector2.Zero));
                    break;
                default:
                    break;
            }
        }

		public void DisposeComponent(Component_TYPE T)
		{
            switch (T)
            {
                case Component_TYPE.SPRITE:
                    foreach (Sprite sprite in Components.ToArray())
                    {
                        Sprite s = sprite;
                        Components.Remove(s);
                        return;
                    }
                    break;
                case Component_TYPE.COLLIDER:
                    foreach (Collider collider in Components.ToArray())
                    {
                        Collider c = collider;
                        Components.Remove(c);
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
        
		public void SetSprite(Sprite s)
        {
            DisposeComponent(Component_TYPE.SPRITE);
            Components.Add(s);
        }

        /// <summary>
        /// Return an Array of Sprites that are inside the components
        /// </summary>
        /// <returns>Array of Sprite</returns>
        public Sprite[] GetSprites()
        {
            List<Sprite> s_a = new List<Sprite>();

            foreach (Component s in Components.ToArray())
            {
                if(s.isSprite())
                {
                    s_a.Add((Sprite)s);
                }
            }
            return s_a.ToArray();
        }

        /// <summary>
        /// return the first sprite made in components
        /// </summary>
        public Sprite getSprite => GetSprites()[0];

        /// <summary>
        /// Returns the first collider
        /// </summary>
        /// <returns>Colliders</returns>
        public Collider GetCollider()
        {
            List<Collider> ss = new List<Collider>();
            foreach (Component s in Components.ToArray())
            {
                if (s.isCollider())
                {
                    ss.Add((Collider)s);
                }
            }
            return ss[0];
        }
        public void DestroySelf() { Engine.Engine.UnRegisterSprite(this); }
    }
}

using System.Collections.Generic;
using System.Drawing;

using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.Vec2;

using EntitledEngine2.Engine.Components;


namespace EntitledEngine2.Engine.Core.ECS
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
            Engine.RegisterEntity(this);
            Debug.Log($"Created Entity - {name}");
        }

        public void AddComponent(Component_TYPE t)
        {
            switch (t)
            {
                case Component_TYPE.SPRITE:
                    
                    Components.Add(new Plane(Color.Red, "Default"));
                    Debug.Log($"Added default red Plane for - {name}");
                    break;
                case Component_TYPE.COLLIDER:
                    Components.Add(new PlaneCollider(transform.Scale,Vector2.Zero));
                    Debug.Log($"Added default PlaneCollider for - {name}");
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
            Debug.Log($"Changing sprites for {name}");
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
        public void DestroySelf() { Debug.Log($"Destroyed - {name}"); Engine.UnRegisterEntity(this); }
    }
}

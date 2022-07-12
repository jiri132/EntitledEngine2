using System.Collections.Generic;
using System.Drawing;

using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.Physics;
using EntitledEngine2.Engine.Components;


public enum EntityType
{
    Physics, Collider, Sprite, Clean
}

namespace EntitledEngine2.Engine.Core.ECS
{
    /// <summary>
    /// Entity Component System V1.1.2
    /// </summary>
    public class Entity
    {
        #region Publics

        public string name { private set; get; }
        public Transform transform { private set; get; }
        #endregion

        #region Privates
        public SpriteRenderer spriteRenderer { private set; get; }
        public LineRenderer lineRenderer { private set; get; }

        public Rigidbody rigidbody { private set; get; }
        public Collider collider { private set; get; }


        #endregion

        public Entity(string name, EntityType type = EntityType.Clean)
        {
            this.name = name;
            transform = new Transform();

            switch (type)
            {
                case EntityType.Physics:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE_RENDERER);
                    AddComponent(Component_TYPE.COLLIDER);
                    AddComponent(Component_TYPE.RIGIDBODY);
                    break;
                case EntityType.Collider:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE_RENDERER);
                    AddComponent(Component_TYPE.COLLIDER);
                    break;
                case EntityType.Sprite:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE_RENDERER);
                    break;
                case EntityType.Clean:
                    Debug.Log($"no automatic compenet adding for {name}");
                    break;
                default:
                    break;
            }

            Engine.RegisterEntity(this);
            Debug.Log($"Created Entity - {name}");
        }

        public void AddComponent(Component_TYPE t)
        {
            switch (t)
            {
                case Component_TYPE.SPRITE_RENDERER:
                    spriteRenderer = new Plane(Color.Red, "Default");
                    Debug.Log($"Added default red Plane for     - {name}");
                    break;
                case Component_TYPE.COLLIDER:
                    collider = new PlaneCollider(this);
                    Debug.Log($"Added default PlaneCollider for - {name}");
                    break;
                case Component_TYPE.RIGIDBODY:
                    rigidbody = new Rigidbody(this);
                    Debug.Log($"Added default rigidbody for     - {name}");
                    break;
                case Component_TYPE.LINE_RENDERER:
                    lineRenderer = new Line(Color.White);
                    Debug.Log($"Added default LineRenderer for  - {name}");
                    break;  
                default:
                    break;
            }
        }

		public void DisposeComponent(Component_TYPE T)
		{
            switch (T)
            {
                case Component_TYPE.SPRITE_RENDERER:
                    spriteRenderer = null;
                    break;
                case Component_TYPE.COLLIDER:
                    collider = null;
                    break;
                case Component_TYPE.RIGIDBODY:
                    rigidbody = null;
                    break;
                default:
                    break;
            }
        }
        
		public void SetSprite(SpriteRenderer s)
        {
            Debug.Log($"Changing sprites for {name}");
            DisposeComponent(Component_TYPE.SPRITE_RENDERER);
            spriteRenderer = s;
        }
        public void SetCollider(ColliderType type)
        {
            Debug.Log($"Changing collider for {name}");
            DisposeComponent(Component_TYPE.COLLIDER);

            switch (type)
            {
                case ColliderType.Plane:
                    collider = new PlaneCollider(this);
                    if (rigidbody != null)
                    {
                        rigidbody.ownCollider = collider;
                    }
                    break;
                case ColliderType.Circle:
                    collider = new CircleCollider(this);
                    if (rigidbody != null)
                    {
                        rigidbody.ownCollider = collider;
                    }
                    break;
                default:
                    break;
            }

            
        }
        public void SetRigidbody(Rigidbody rb)
        {
            Debug.Log($"Changing rigidbody for {name}");
            DisposeComponent(Component_TYPE.RIGIDBODY);
            rigidbody = rb;
        }


        public SpriteRenderer GetSprite()
        {
            return spriteRenderer;
        }
        public Collider GetCollider()
        {
            return collider;
        }

        public Rigidbody GetRigidbody()
        {
            return rigidbody;
        }

        public void DestroySelf() { Debug.Log($"Destroyed - {name}"); Engine.UnRegisterEntity(this); }
    }
}

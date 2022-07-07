using System.Collections.Generic;
using System.Drawing;

using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.Shapes;
using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Components;
using EntitledEngine2.Engine.Core.Physics;


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
        public string name { private set; get; }
        public Transform transform { private set; get; }

        private Sprite sprite;
        public Rigidbody rigidbody { private set; get; }
        public Collider collider { private set; get; }



        public Entity(string name, EntityType type = EntityType.Clean)
        {
            this.name = name;
            transform = new Transform();

            switch (type)
            {
                case EntityType.Physics:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE);
                    AddComponent(Component_TYPE.COLLIDER);
                    AddComponent(Component_TYPE.RIGIDBODY);
                    break;
                case EntityType.Collider:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE);
                    AddComponent(Component_TYPE.COLLIDER);
                    break;
                case EntityType.Sprite:
                    Debug.Log($"automaticly added compenets for {name}");
                    AddComponent(Component_TYPE.SPRITE);
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
                case Component_TYPE.SPRITE:
                    
                    sprite = new Plane(Color.Red, "Default");
                    Debug.Log($"Added default red Plane for - {name}");
                    break;
                case Component_TYPE.COLLIDER:
                    collider = new PlaneCollider(this);
                    Debug.Log($"Added default PlaneCollider for - {name}");
                    break;
                case Component_TYPE.RIGIDBODY:
                    rigidbody = new Rigidbody(this);
                    Debug.Log($"Added default rigidbody for - {name}");
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
                    sprite = null;
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
        
		public void SetSprite(Sprite s)
        {
            Debug.Log($"Changing sprites for {name}");
            DisposeComponent(Component_TYPE.SPRITE);
            sprite = s;
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


        public Sprite GetSprite()
        {
            return sprite;
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

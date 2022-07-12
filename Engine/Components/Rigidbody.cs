using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.Colliders;
using EntitledEngine2.Engine.Core.ECS;
using EntitledEngine2.Engine.Core.Maths;

namespace EntitledEngine2.Engine.Core.Physics
{
    public class Rigidbody : Component
    {
        #region Rigidbody variables
        //Body
        public Vector2 Velocity = Vector2.Zero;
        public float LossOfEnergy { private set; get; } = 0f;
        public float Mass = 1;
        public float Gravity = 9.81f;
        //Rotation
        public float ZrotationVelocity = 0;
        public bool RotationConstraint = true;

        public Collider ownCollider;
        public Entity ownEntity;
        #endregion

        public Rigidbody(Entity e = null, bool rotationConstraint = true)
        {
            //only thing it needs is its own entity form there it can get everything
            ownEntity = e;

            this.RotationConstraint = rotationConstraint;

            ownCollider = ownEntity.GetCollider();
        }

        public void UpdateBody()
        {
            //add acceleration to velocity and gravity
            ownEntity.transform.Position += Velocity * Engine.deltaTime;

            ownEntity.transform.Rotate(Mathf.DegToRad(ZrotationVelocity));
        }

        public void ChangeLossOFEnergy(float LOE)
        {
            if(LOE > 100 || LOE < 0)
            {
                Debug.Log("Give a number between 0 and 100");
                return;
            }

            LossOfEnergy = LOE;
        }

        

        public Vector2 position => ownEntity.transform.Position;
        public Vector2 scale => ownEntity.transform.Scale;
    }
}

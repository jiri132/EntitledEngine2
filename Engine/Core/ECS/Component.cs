﻿namespace EntitledEngine2.Engine.Core.ECS
{

    public enum Component_TYPE
    {
        SPRITE, COLLIDER, RIGIDBODY
    }

    public abstract class Component
    {
        public abstract bool isSprite();
        public abstract bool isCollider();
        public abstract bool isRigidbody();

    }
}

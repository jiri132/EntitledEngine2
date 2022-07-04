﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitledEngine2.Core;
using EntitledEngine2.Core.Shapes;

namespace EntitledEngine2.Core.ECS
{

    public enum Component_TYPE
    {
        SPRITE, COLLIDER
    }

    public abstract class Component
    {
        public abstract bool isSprite();
        public abstract bool isCollider();

    }
}

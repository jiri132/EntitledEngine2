using EntitledEngine2.Core.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.ECS
{
    public static class Destructor 
    {
        public static void Destruct(Entity e) { Engine.UnRegisterSprite(e); }
    }
}

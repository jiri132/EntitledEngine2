using EntitledEngine2.Engine.Core.Vec2;
using EntitledEngine2.Engine.Core.Maths;

namespace EntitledEngine2.Engine.Core.UI
{
    public enum UI_TYPE { TEXT };

    public abstract class UI
    {
        public abstract UI_TYPE GetType();
        public abstract Text getText();
    }
}

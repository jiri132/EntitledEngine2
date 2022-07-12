using EntitledEngine2.Engine.Core.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core.UI
{
    public class Text : UI
    {
        public string text { set; get; } = "<DEFAULT>";
        public Vector2 clampedPosition { get => CalculateClampedPosition(); }
        public Vector2 positionWorldSpace { private set; get; } = Vector2.Zero;
        public Vector2 offsetFromCamera { private set; get; } = Vector2.Zero;
        public bool isWorldSpace { private set; get; } = false;

        public Text() { Engine.RegisterUI(this); }
        public Text(string text) { this.text = text; }

        public Text(string text,Vector2 offset)
        {
            this.text = text;
            this.offsetFromCamera = offset;
            isWorldSpace = false;

            Engine.RegisterUI(this);
        }
        public Text(string text,Vector2 positionWorldSpace, bool isWorldSpace)
        {
            this.text = text;
            this.positionWorldSpace = positionWorldSpace;
            this.isWorldSpace = isWorldSpace;

            Engine.RegisterUI(this);
        }



        public void ChangeOffset(Vector2 offsetFromCamera)
        {
            this.offsetFromCamera = offsetFromCamera;
        } 
        public void SetPosition(Vector2 positionWorldSpace)
        {
            this.positionWorldSpace = positionWorldSpace;
        }

        private Vector2 CalculateClampedPosition()
        {
            if (isWorldSpace) { return positionWorldSpace; }

            Vector2 position = offsetFromCamera - Engine.CameraPosition * -1;

            return position;
        }

        public override UI_TYPE GetType()
        {
            return UI_TYPE.TEXT;
        }

        public override Text getText()
        {
            return this;
        }
    }
}

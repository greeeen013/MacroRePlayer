using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRePlayer
{

    interface IInputEvent
    {
        string Type { get; }
        void draw();
    }

    class DelayEvent : IInputEvent
    {
        public string Type => "DelayEvent";
        public int Duration;

        public void draw() { }
    }

    class MouseDownEvent : IInputEvent
    {
        public string Type => "MouseDown";
        public int X { get; set; }
        public int Y { get; set; }
        public string Button { get; set; }

        public void draw() { }
    }

    class MouseUpEvent : IInputEvent
    {
        public string Type => "MouseUp";
        public int X { get; set; }
        public int Y { get; set; }
        public string Button { get; set; }

        public void draw() { }
    }

    class KeyDownEvent : IInputEvent
    {
        public string Type => "KeyDown";
        public string Key { get; set; }

        public void draw() { }
    }

    class KeyUpEvent : IInputEvent
    {
        public string Type => "KeyUp";
        public string Key { get; set; }

        public void draw() { }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRePlayer
{
    class InputEvent
    {
        public string EventType { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public string Key { get; set; }
        public int? Duration { get; set; }
    }
}

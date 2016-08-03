using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Animation_Editor
{
    [Serializable]
    public class Frame
    {
        public string name;
        public Bitmap img;
        public Rectangle screenRect;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animation_Editor
{
    [Serializable]
    public class Layer
    {
        public List<Frame> camada_1 = new List<Frame>();
        public List<Frame> camada_2 = new List<Frame>();
        public List<Frame> camada_3 = new List<Frame>();
    }
}

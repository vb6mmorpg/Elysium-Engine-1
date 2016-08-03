/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.GameFunction
{
    public class ResourceFunction
    {
        public static Dictionary<string, ResourceItem> resourceItem = new Dictionary<string,ResourceItem>();

        public static void LoadResource()
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory + @"\Data\Resource");
            foreach (string f in files)
            {
                string[] tempStr = f.Split('\\');
                string[] tempExt = tempStr[tempStr.GetUpperBound(0)].Split('.');

                resourceItem.Add(tempExt[0], new ResourceItem());
                resourceItem[tempExt[0]].texture = GameTexture.TextureFromBitmap(f);
            }
          
        }

        public class ResourceItem
        {
           
            public Texture texture;
            public Size size;
        }
    }
}
*/
/*using System;
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
    public class MapFunction
    {
        public static List<MapItem> layer_1 = new List<MapItem>();
        public static List<MapItem> layer_2 = new List<MapItem>();
        public static List<MapItem> layer_3 = new List<MapItem>();
        public static List<MapItem> layer_4 = new List<MapItem>();

        public class MapItem
        {
            public int index;
            public string name;
            public Point coord;
        }

        public static void ReadMap(int num)
        {
            FileStream fStream;
            BinaryReader reader;
            int count;

            fStream = new FileStream(Environment.CurrentDirectory + @"\Data\Map\Map" + num + ".mapx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new BinaryReader(fStream);

            count = reader.ReadInt32();

            if (count > 0)
            {
                for (int n = 0; n < count; n++)
                {
                    layer_1.Add(new MapItem());
                    layer_1[n].name = reader.ReadString();
                    layer_1[n].coord.X = reader.ReadInt32();
                    layer_1[n].coord.Y = reader.ReadInt32();
                }
            }

            count = reader.ReadInt32();

            if (count > 0)
            {
                for (int n = 0; n < count; n++)
                {
                    layer_2.Add(new MapItem());
                    layer_2[n].name = reader.ReadString();
                    layer_2[n].coord.X = reader.ReadInt32();
                    layer_2[n].coord.Y = reader.ReadInt32();
                }
            }

            count = reader.ReadInt32();

            if (count > 0)
            {
                for (int n = 0; n < count; n++)
                {
                    layer_3.Add(new MapItem());
                    layer_3[n].name = reader.ReadString();
                    layer_3[n].coord.X = reader.ReadInt32();
                    layer_3[n].coord.Y = reader.ReadInt32();
                }
            }

            count = reader.ReadInt32();

            if (count > 0)
            {
                for (int n = 0; n < count; n++)
                {
                    layer_4.Add(new MapItem());
                    layer_4[n].name = reader.ReadString();
                    layer_4[n].coord.X = reader.ReadInt32();
                    layer_4[n].coord.Y = reader.ReadInt32();
                }
            }

            reader.Close();
            fStream.Close();
            fStream.Dispose();
        }

        public static void RenderLayers_Above()
        {
            for (int n = 0; n < layer_3.Count; n++) { DrawImage(ResourceFunction.resourceItem[layer_3[n].name].texture, layer_3[n].coord.X, layer_3[n].coord.Y); }

            for (int n = 0; n < layer_4.Count; n++) { DrawImage(ResourceFunction.resourceItem[layer_4[n].name].texture, layer_4[n].coord.X, layer_4[n].coord.Y); }
        }

        public static void RenderLayers_Under()
        {
            for (int n = 0; n < layer_1.Count; n++) { DrawImage(ResourceFunction.resourceItem[layer_1[n].name].texture, layer_1[n].coord.X, layer_1[n].coord.Y); }

            for (int n = 0; n < layer_2.Count; n++) { DrawImage(ResourceFunction.resourceItem[layer_2[n].name].texture, layer_2[n].coord.X, layer_2[n].coord.Y); }
        }
        public static void DrawImage(Texture texture, int x, int y)
        {
            GameCore.spriteDevice.Begin(SpriteFlags.AlphaBlend);
            GameCore.spriteDevice.Draw2D(texture, new PointF(0, 0), 0F, new PointF(x, y), Color.White);
            GameCore.spriteDevice.End();
        }
    }
}
*/
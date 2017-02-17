using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.EngineWindow {
    public class WindowShortCut {
        private const int MAX_SLOT = 12;

        private static EngineShortCut[] ShortCut = new EngineShortCut[MAX_SLOT];        

        public static void Initialize() {
            const int X = 285, Y = 600;

            for (var index = 0; index < MAX_SLOT; index++) {
                ShortCut[index] = new EngineShortCut(false);
                ShortCut[index].BorderRect = new SharpDX.Rectangle(0, 0, 40, 40);
                ShortCut[index].SourceRect = new SharpDX.Rectangle(0, 0, 40, 40);
                ShortCut[index].Position = new SharpDX.Point(X + (index * 36), Y);
            }

            EngineShortCut.StaticTexture = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\slot.png", 40, 40);

        }

        public static void Draw() {
            for (var index = 0; index < MAX_SLOT; index++) {
                ShortCut[index].Draw(EngineShortCut.StaticTexture);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Elysium_Diamond.Common;

namespace Elysium_Diamond.DirectX {
    public class EngineSkillShortCut : EngineObject {

        public EngineSkillShortCut(int width, int height) {
            Texture = EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\slot.png", width, height);
        }

        public void Draw(int x, int y) {
            EngineCore.SpriteDevice.Draw(Texture, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3(x, y, 0));
        }
    }
}


/*
        y = 521;
            x = 285;
            for (var n = 0; n < 12; n++) {
                EngineCore.SpriteDevice.Draw(slot, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3(x + (n * 36), y, 0));
                EngineCore.SpriteDevice.Draw(blessingstone, Color.White, new Rectangle(0, 0, 32, 32), new Vector3(0, 0, 0), new Vector3(x + 4 + (n * 36), y + 4, 0));
            }

            y = 560;
            x = 285;
            for (var n = 0; n < 12; n++) {
                EngineCore.SpriteDevice.Draw(slot, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3(x + (n * 36), y, 0));
                EngineCore.SpriteDevice.Draw(superiorheal, Color.White, new Rectangle(0, 0, 32, 32), new Vector3(0, 0, 0), new Vector3(x + 4 + (n * 36), y + 4, 0));
            }

            y = 600;
            x = 285;    
            for (var n = 0; n < 12; n++) {
                EngineCore.SpriteDevice.Draw(slot, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3(x + (n * 36), y, 0));
                EngineCore.SpriteDevice.Draw(powerattack, Color.White, new Rectangle(0, 0, 32, 32), new Vector3(0, 0, 0), new Vector3(x + 4 + (n * 36), y + 4, 0));
            } */
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineShortCut : EngineObject {
       
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ObjectID { get; set; }

        /// <summary>
        /// Tipo de item.
        /// </summary>
        public int ObjectType { get; set; }

        /// <summary>
        /// Textura estatica.
        /// </summary>
        public static Texture StaticTexture;

        public EngineShortCut(bool textureload) : base() {
            if (!textureload) return;
            Texture = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\slot.png", 40, 40);
        }

        public void Draw(int x, int y) {
            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(Texture, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3(x, y, 0));
            EngineCore.SpriteDevice.End();
        }
    }
}

/* public void Draw(int x, int y) {
    for (var index = 0; index < MAX_SLOT; index++) {
        EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
        EngineCore.SpriteDevice.Draw(Texture, Color.White, new Rectangle(0, 0, 40, 40), new Vector3(0, 0, 0), new Vector3, y, 0));
        EngineCore.SpriteDevice.End();
    }
} */
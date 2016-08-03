using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.Resource
{
    public class ResourceSprite {
        /// <summary>
        /// Guarda a textura e o número da sprite
        /// </summary>
        public class SpriteTexture {
            /// <summary>
            /// Número de Identificação
            /// </summary>
            public int ID { get; set; }
           
            /// <summary>
            /// Textura
            /// </summary>
            public Texture Texture { get; set; }

            /// <summary>
            /// Construtor
            /// </summary>
            /// <param name="id"></param>
            /// <param name="texture"></param>
            public SpriteTexture(int id, Texture texture) {
                ID = id;
                Texture = texture;
            }
        }

        /// <summary>
        /// Lista de Sprites
        /// </summary>
        public static HashSet<SpriteTexture> Sprite { get; set; }

        /// <summary>
        /// Realiza a busca pelo número da sprite
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Texture FindByID(int id) {
            var find_texture = from sData in Sprite
                             where sData.ID.Equals(id)
                             select sData;

            return find_texture.FirstOrDefault().Texture;
        }

        /// <summary>
        /// Carrega todas as sprites 
        /// </summary>
        public static void Initialize() {
            Sprite = new HashSet<SpriteTexture>();

            const int max = 70;

            for (int n = 1; n < max; n++) { 
                Sprite.Add(new SpriteTexture(n, EngineTexture.TextureFromFile(Settings.GamePath + @"\Data\Graphics\Sprite\" + n + ".png"))); 
            }
        }
    }
}

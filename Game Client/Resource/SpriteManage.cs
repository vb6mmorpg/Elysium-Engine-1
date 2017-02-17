using System.Collections.Generic;
using System.Linq;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.Resource
{
    public class SpriteManage {
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
                Sprite.Add(new SpriteTexture(n, EngineTexture.TextureFromFile($"{Configuration.GamePath}\\Data\\Graphics\\Sprite\\{n}.png"))); 
            }
        }
    }
}

using SharpDX.Direct3D9;

namespace Elysium_Diamond.Resource {
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
}

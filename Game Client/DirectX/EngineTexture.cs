using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SharpDX;
using SharpDX.Direct3D9;

// Refatorado 2015-08-13

namespace Elysium_Diamond.DirectX
{
    public static class EngineTexture {
        /// <summary>
        /// Carrega a textura a partir de um arquivo.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file) {  
            var img = Image.FromFile(file);

            var width = img.Width;
            var height = img.Height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

           return Texture.FromFile(EngineCore.DirectXDevice, file, width, height, 0, Usage.None, Format.Unknown, Pool.Managed, Filter.None, Filter.None, 0);
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo e passa sua resolução.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, out Size2 size) {
            var img = Image.FromFile(file);

            var width = img.Width;
            var height = img.Height;

            size.Width = width;
            size.Height = height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {       
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

            return Texture.FromFile(EngineCore.DirectXDevice, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);     
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo com o tamanho definido.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <param name="width">Comprimento</param>
        /// <param name="height">Altura</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, int width, int height) {
            return Texture.FromFile(EngineCore.DirectXDevice, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);
        }
        
        /// <summary>
        /// Carrega a textura a partir de um arquivo com o tamanho definido e cor de transparência.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <param name="width">Comprimento</param>
        /// <param name="height">Altura</param>
        /// <param name="color">Cor de transparência</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, int width, int height, SharpDX.Color color) {
            return Texture.FromFile(EngineCore.DirectXDevice, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, color.ToAbgr());
        } 

        /// <summary>
        /// Carrega a textura a partir de uma imagem.
        /// </summary>
        /// <param name="img">Imagem</param>
        /// <returns></returns>
        public static Texture TextureFromImage(Image img) {
            var width = img.Width;
            var height = img.Height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

            return Texture.FromMemory(EngineCore.DirectXDevice, buffer, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);
        }
    }
   
}

// return Texture.FromFile(EngineCore.DirectXDevice, file, D3DX.DefaultNonPowerOf2, D3DX.DefaultNonPowerOf2, 1, Usage.None, Format.Unknown, Pool.Managed, Filter.None, Filter.None, 0);
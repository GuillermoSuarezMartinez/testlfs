using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Métodos genéricos para el trabajo con ficheros multimedia   
    /// </summary>
    public static class OMultimedia
    {
        /// <summary>
        /// Copia una carpeta
        /// </summary>
        /// <param name="sourceFileName">Ruta origen</param>
        /// <param name="destFileName">Ruta destino</param>
        /// <param name="ImageFormat">Formato de la imagen</param>
        /// <param name="quality">calidad</param>
        public static bool ConversionFicheroImagen(string sourceFileName, string destFileName, ImageFormat imageFormat, long quality)
        {
            bool resultado = false;
            try
            {
                // Codec
                ImageCodecInfo selectedCodec = null;
                bool codecFound = false;
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.FormatID == imageFormat.Guid)
                    {
                        selectedCodec = codec;
                        codecFound = true;
                        break;
                    }
                }

                if (codecFound)
                {
                    // Codec parameters
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                    //encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionRle);

                    using (Bitmap bmp = new Bitmap(sourceFileName))
                    {
                        bmp.Save(destFileName, selectedCodec, encoderParameters);
                    }

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Comun, "ConversionFicheroImagen", exception);
            }
            return resultado;
        }
    }
}
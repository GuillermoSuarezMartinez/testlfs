//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aiba�ez
// Created          : 22-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Orbita.VA.Comun
{
    /* Provides methods for creating and updating bitmaps with raw image data. */
    public static class BitmapFactory
    {
        /* Returns the corresponding pixel format of a bitmap. */
        private static PixelFormat GetFormat(int profundidad)
        {
            switch (profundidad)
            {
                case 1:
                default:
                    return PixelFormat.Format8bppIndexed;
                case 3:
                    return PixelFormat.Format24bppRgb;
                case 4:
                    return PixelFormat.Format32bppRgb;
            }
        }

        /* Returns if the bitmap is in color. */
        public static int GetProfundidad(PixelFormat pixelFormat)
        {
            int bitsPerPixel = ((int)pixelFormat & 0xff00) >> 8;
            int bytesPerPixel = (bitsPerPixel + 7) / 8;

            return bytesPerPixel;
        }

        /* Returns if the bitmap is in color. */
        public static bool GetColor(PixelFormat pixelFormat)
        {
            return GetProfundidad(pixelFormat) > 1;
        }

        /* Calculates the length of one line in byte. */
        private static int GetStride(int width, int profundidad)
        {
            return width * profundidad;
        }

        /* Compares the properties of the bitmap with the supplied image data. Returns true if the properties are compatible. */
        public static bool IsCompatible(Bitmap bitmap, int width, int height, int profundidad)
        {
            if (bitmap == null
                || bitmap.Height != height
                || bitmap.Width != width
                || bitmap.PixelFormat != GetFormat(profundidad)
             )
            {
                return false;
            }
            return true;
        }

        /* Compares the properties of the bitmap with the supplied image data. Returns true if the properties are compatible. */
        public static bool IsCompatible(Bitmap bitmap1, Bitmap bitmap2)
        {
            if (bitmap1 == null
                || bitmap2 == null
                || bitmap1.Height != bitmap2.Height
                || bitmap1.Width != bitmap2.Width
                || bitmap1.PixelFormat != bitmap2.PixelFormat)
            {
                return false;
            }
            return true;
        }


        /* Creates a new bitmap object with the supplied properties. */
        public static void CreateBitmap(out Bitmap bitmap, int width, int height, int profundidad)
        {
            bitmap = new Bitmap(width, height, GetFormat(profundidad));

            if (bitmap.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ColorPalette colorPalette = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    colorPalette.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = colorPalette;
            }
        }

        /* Copies the raw image data to the bitmap buffer. */
        public static void UpdateBitmap(Bitmap bitmap, byte[] buffer, int width, int height, int profundidad)
        {
            /* Check if the bitmap can be updated with the image data. */
            if (!IsCompatible(bitmap, width, height, profundidad))
            {
                throw new Exception("Cannot update incompatible bitmap.");
            }

            /* Lock the bitmap's bits. */
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            /* Get the pointer to the bitmap's buffer. */            
            IntPtr ptrBmp = bmpData.Scan0;
            /* Compute the width of a line of the image data. */
            int imageStride = GetStride(width, profundidad);
            /* If the widths in bytes are equal, copy in one go. */
            if (imageStride == bmpData.Stride)
            {
                System.Runtime.InteropServices.Marshal.Copy(buffer, 0, ptrBmp, bmpData.Stride * bitmap.Height );
            }
            else /* The widths in bytes are not equal, copy line by line. This can happen if the image width is not divisible by four. */
            {
                for (int i = 0; i < bitmap.Height; ++i)
                {
                    Marshal.Copy(buffer, i * imageStride, new IntPtr(ptrBmp.ToInt64() + i * bmpData.Stride), width);
                }
            }
            /* Unlock the bits. */
            bitmap.UnlockBits(bmpData);
        }

        /* Copies the raw image data to the bitmap buffer. */
        public static void CreateOrUpdateBitmap(ref Bitmap bitmap, byte[] buffer, int width, int height, int profundidad)
        {
            /* Check if the image is compatible with the currently used bitmap. */
            bool needToCreate = (bitmap == null) || (!BitmapFactory.IsCompatible(bitmap, width, height, profundidad));
            if (needToCreate)
            {
                /* A new bitmap is required. */
                BitmapFactory.CreateBitmap(out bitmap, width, height, profundidad);
                BitmapFactory.UpdateBitmap(bitmap, buffer, width, height, profundidad);
            }
            else
            {
                /* Update the bitmap with the image data. */
                BitmapFactory.UpdateBitmap(bitmap, buffer, width, height, profundidad);
            }   
        }

        public static void ExtractBufferArray(Bitmap bitmap, out byte[] buffer)
        {
            /* Lock the bitmap's bits. */
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            /* Get the pointer to the bitmap's buffer. */
            IntPtr ptrBmp = bmpData.Scan0;
            /* Compute the width of a line of the image data. */
            int profundidad = GetProfundidad(bitmap.PixelFormat);
            int imageStride = GetStride(bitmap.Width, profundidad);
            int numBytes = imageStride * bitmap.Height;
            buffer = new byte[numBytes];
            /* If the widths in bytes are equal, copy in one go. */
            if (imageStride == bmpData.Stride)
            {
                System.Runtime.InteropServices.Marshal.Copy(ptrBmp, buffer, 0, bmpData.Stride * bitmap.Height);
            }
            else /* The widths in bytes are not equal, copy line by line. This can happen if the image width is not divisible by four. */
            {
                for (int i = 0; i < bitmap.Height; ++i)
                {
                    Marshal.Copy(new IntPtr(ptrBmp.ToInt64() + i * bmpData.Stride), buffer, i * imageStride, bitmap.Width);
                }
            }
            /* Unlock the bits. */
            bitmap.UnlockBits(bmpData);
        }
    }
}

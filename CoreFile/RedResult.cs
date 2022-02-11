using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Core
{
    public static class Red_Result
    {
        #region 24bit

            public static Bitmap BlendImage(this Bitmap baseImage, Bitmap overlayImage)
            {

                BitmapData baseImageData = baseImage.LockBits(new Rectangle(0, 0, baseImage.Width, baseImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                byte[] baseImageBuffer = new byte[baseImageData.Stride * baseImageData.Height];

                Marshal.Copy(baseImageData.Scan0, baseImageBuffer, 0, baseImageBuffer.Length);

                BitmapData overlayImageData = overlayImage.LockBits(new Rectangle(0, 0, overlayImage.Width, overlayImage.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                byte[] overlayImageBuffer = new byte[overlayImageData.Stride * overlayImageData.Height];

                Marshal.Copy(overlayImageData.Scan0, overlayImageBuffer, 0, overlayImageBuffer.Length);

                float sourceBlue = 0;
                float sourceGreen = 0;
                float sourceRed = 0;

                float overlayBlue = 0;
                float overlayGreen = 0;
                float overlayRed = 0;

                for (int k = 0; k < baseImageBuffer.Length && k < overlayImageBuffer.Length; k += 4)
                {
                    sourceBlue = baseImageBuffer[k] * (float)1;
                    sourceGreen = baseImageBuffer[k + 1] * (float)1;
                    sourceRed = baseImageBuffer[k + 2] * (float)1;

                    if (overlayImageBuffer[k + 2] > overlayImageBuffer[k + 1] && overlayImageBuffer[k + 2] > overlayImageBuffer[k]/* && overlayImageBuffer[k + 2] > 180*/)
                    {

                        overlayBlue = overlayImageBuffer[k] * (float)1;
                        overlayGreen = overlayImageBuffer[k + 1] * (float)1;
                        overlayRed = overlayImageBuffer[k + 2] * (float)1;

                        sourceBlue = baseImageBuffer[k] * (float)0.35;
                        sourceGreen = baseImageBuffer[k + 1] * (float)0.35;
                        sourceRed = baseImageBuffer[k + 2] * (float)0.35;
                    }
                    else
                    {
                        overlayBlue = 0;
                        overlayRed = 0;
                        overlayGreen = 0;
                    }

                    baseImageBuffer[k] = CalculateColorComponentBlendValue(sourceBlue, overlayBlue);
                    baseImageBuffer[k + 1] = CalculateColorComponentBlendValue(sourceGreen, overlayGreen);
                    baseImageBuffer[k + 2] = CalculateColorComponentBlendValue(sourceRed, overlayRed);
                }

                Bitmap bitmapResult = new Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
                BitmapData resultImageData = bitmapResult.LockBits(new Rectangle(0, 0, bitmapResult.Width, bitmapResult.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                Marshal.Copy(baseImageBuffer, 0, resultImageData.Scan0, baseImageBuffer.Length);

                bitmapResult.UnlockBits(resultImageData);
                baseImage.UnlockBits(baseImageData);
                overlayImage.UnlockBits(overlayImageData);

                return bitmapResult;
            }

            private static byte CalculateColorComponentBlendValue(float source, float overlay)
            {
                float resultValue = 0;
                byte resultByte = 0;

                resultValue = source + overlay;

                if (resultValue > 255)
                {
                    resultByte = 255;
                }
                else if (resultValue < 0)
                {
                    resultByte = 0;
                }
                else
                {
                    resultByte = (byte)resultValue;
                }

                return resultByte;
            }

            public static Bitmap LoadArgbBitmap(this Bitmap filePath, System.Drawing.Size? imageDimensions = null)
            {
                //StreamReader streamReader = new StreamReader(filePath);
                Bitmap fileBmp = filePath;//(Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                                          //streamReader.Close();

                int width = fileBmp.Width;
                int height = fileBmp.Height;

                if (imageDimensions != null)
                {
                    width = imageDimensions.Value.Width;
                    height = imageDimensions.Value.Height;
                }

                if (fileBmp.PixelFormat != PixelFormat.Format32bppArgb || fileBmp.Width != width || fileBmp.Height != height)
                {
                    fileBmp = GetArgbCopy(fileBmp, width, height);
                }

                return fileBmp;
            }

            private static Bitmap GetArgbCopy(Bitmap sourceImage, int width, int height)
            {
                Bitmap bmpNew = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                using (Graphics graphics = Graphics.FromImage(bmpNew))
                {
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), GraphicsUnit.Pixel);
                    graphics.Flush();
                }

                return bmpNew;
            }
        #endregion
    }
}

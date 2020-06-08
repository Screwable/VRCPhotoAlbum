﻿using KoyashiroKohaku.VrcMetaToolSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Gatosyocora.VRCPhotoAlbum.Helpers
{
    public class ImageHelper
    {

        #region BitmapImage
        public static BitmapImage LoadBitmapImage(string filePath)
        {
            var bitmapImage = new BitmapImage();
            var stream = File.OpenRead(filePath);
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            stream.Close();
            stream.Dispose();
            return bitmapImage;
        }

        public static BitmapImage GetThumbnailImage(string filePath, string cashFolderPath)
        {
            var thumbnailImageFilePath = $"{cashFolderPath}/{Path.GetFileName(filePath)}";

            if (!File.Exists(thumbnailImageFilePath))
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var originalImage = Image.FromStream(stream, false, false);
                    var thumbnailImage = originalImage.GetThumbnailImage(originalImage.Width / 8, originalImage.Height / 8, () => { return false; }, IntPtr.Zero);
                    thumbnailImage.Save(thumbnailImageFilePath, ImageFormat.Png);
                    originalImage.Dispose();
                    thumbnailImage.Dispose();
                }
            }
            return LoadBitmapImage(thumbnailImageFilePath);
        }
        #endregion

        #region Bitmap
        public static Bitmap LoadImage(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{filePath} is not found.");
            }

            return new Bitmap(filePath);
        }

        public static void SaveImage(Bitmap image, string filePath)
        {
            if (image is null)
            {
                throw new ArgumentNullException("image is null");
            }
            using (image)
            {
                image.Save(filePath, ImageFormat.Png);
            }
        }

        public static void SaveImage(byte[] imageBuffer, string filePath)
        {
            File.WriteAllBytes(filePath, imageBuffer);
        }
        #endregion

        #region Convert
        public static Bitmap Bytes2Bitmap(byte[] buffer)
        {
            using (var ms = new MemoryStream(buffer))
            {
                var bitmap = new Bitmap(ms);
                ms.Close();
                return bitmap;
            }
        }

        public static byte[] Bitmap2Bytes(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }
        #endregion

        #region ImageProcessing

        public static Bitmap RotateLeft90(string filePath)
        {
            var image = LoadImage(filePath);
            return RotateLeft90(image);
        }

        public static Bitmap RotateRight90(string filePath)
        {
            var image = LoadImage(filePath);
            return RotateRight90(image);
        }

        public static Bitmap RotateLeft90(Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return image;
        }

        public static Bitmap RotateRight90(Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return image;
        }

        public static Bitmap FlipHorizontal(Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate180FlipY);
            return image;
        }

        #endregion

        public static void RotateLeft90AndSave(string filePath, VrcMetaData metaData)
        {
            var image = RotateLeft90(LoadImage(filePath));
            var buffer = VrcMetaDataWriter.Write(Bitmap2Bytes(image), metaData);
            SaveImage(buffer, filePath);
        }

        public static void RotateRight90AndSave(string filePath, VrcMetaData metaData)
        {
            var image = RotateRight90(LoadImage(filePath));
            var buffer = VrcMetaDataWriter.Write(Bitmap2Bytes(image), metaData);
            SaveImage(buffer, filePath);
        }

        public static void FilpHorizontalAndSave(string filePath, VrcMetaData metaData)
        {
            var image = FlipHorizontal(LoadImage(filePath));
            var buffer = VrcMetaDataWriter.Write(Bitmap2Bytes(image), metaData);
            SaveImage(buffer, filePath);
        }
    }
}
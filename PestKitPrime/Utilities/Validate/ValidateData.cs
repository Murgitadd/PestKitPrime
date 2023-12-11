using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PestKitPrime.Utilities.Validate
{
    public static class ValidateData
    {

        public static bool ValidateType(this IFormFile file, string type = "image/")
        {
            return file.ContentType.Contains(type);
        }

        public static bool ValidateSize(this IFormFile file, int limitMb)
        {
            return file.Length > limitMb;
        }

        public static async Task<string> CreateFile(this IFormFile file, string root, params string[] folders)
        {
            string originalFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string guidBasedName = ExtractGuidFileName(originalFileName);
            string fileFormat = Path.GetExtension(originalFileName);
            string finalFileName = guidBasedName + fileFormat;

            string path = root;
            for (int i = 0; i < folders.Length; i++)
            {
                path = Path.Combine(path, folders[i]);
            }

            path = Path.Combine(path, finalFileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return finalFileName;
        }

        public static async Task DeleteFile(this string fileName, string root, params string[] folders)
        {
            string path = root;
            for (int i = 0; i < folders.Length; i++)
            {
                path = Path.Combine(path, folders[i]);
            }

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static string ExtractGuidFileName(string fullFileName)
        {
            int scoreIndex = fullFileName.IndexOf('_');
            return scoreIndex != -1 ? fullFileName.Substring(0, scoreIndex) : fullFileName;

        }
    }
}

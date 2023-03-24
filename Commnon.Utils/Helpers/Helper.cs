using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace Commnon.Utils.Helpers
{
    public static class Helper
    {
        public static bool ValidImageExtencion(string extension)
        {
            bool result = false;

            string[] extensionValid =
            {
                ".jpg",".png",".jpeg",".gif",".bmp"
            };

            for (int i = 0; i < extensionValid.Length - 1; i++)
            {
                if (extension.Equals(extensionValid[i]))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        }

    }
}

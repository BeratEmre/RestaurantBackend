using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.FileHelper
{
    public static class File
    {
        public static string FileSave(IFormFile formFile, string path)
        {
            try
            {
                if (formFile.Length < 0)
                    return "Doya yok";
                var a = Directory.Exists(path);
                string name = Guid.NewGuid().ToString()+formFile.FileName.Substring(formFile.FileName.Length-5,5);
                if (!a)
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileSt = System.IO.File.Create(path + name))
                {
                    formFile.CopyTo(fileSt);
                    fileSt.Flush();
                    return name;
                }
            }
            catch (Exception exp)
            {

                return exp.Message.ToString();
            }
        }
        public static bool FileRemove(string path) { System.IO.File.Delete(path); return !System.IO.File.Exists(path); }
    }
}

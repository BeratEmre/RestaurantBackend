using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
   public static class Messages
    {
        public static string Add(string objectName) { return objectName+" ekleme işlemi başarıyla gerçekleşti."; }
        public static string Update(string objectName) { return objectName+" ürünü başarıyla güncellendi."; }
        public static string GetAll(string objectName) { return objectName+" ürünleri başarıyla getirili."; }
        public static string GetById(string objectName) { return objectName+ " ürünü başarıyla getirili."; }
        public static string GetByIdErr(string objectName) { return objectName+ " ürünü bulunamadı."; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Webthuexe.Models
{
    public class reanamefile
    {
        public reanamefile(string oldFileName,string kh) {
            
            string newFileName = "avatar.jpg";
            string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            // Đường dẫn tuyệt đối đến file cần đổi tên
            string sourceFile = Path.Combine("~/",userFolderPath,"/Content/imguser/"+kh, oldFileName);
    
        // Đường dẫn tuyệt đối đến file mớis
            string destinationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newFileName);

            // Di chuyển và đổi tên file
            File.Move(sourceFile, destinationFile);
        }
    }
}
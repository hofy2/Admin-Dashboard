using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.bl.helper
{
   public static class uploadfilehelper
    {

        public static string uploadfile(string folderpath , IFormFile file)
        {
            try
            {


                // phisical path 

               

                string physicalpath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot", folderpath);
                // get file name

                string filename = Guid.NewGuid() + Path.GetFileName(file.FileName);
              

                // merge phisical path   file name

                string finalpath = Path.Combine(physicalpath, filename);

                // save the file as stream "dataover time " 

                using (var stream = new FileStream(finalpath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return filename; 
            }

            catch( Exception ex)
            {
                return ex.Message; 
            }
        }


        public static string fileremover(string FolderPath, string FileName)
        {
            try
            {

                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderPath, FileName)))
                {
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderPath, FileName));
                }

                return "Removed";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

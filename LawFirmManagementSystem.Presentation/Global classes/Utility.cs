using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Global_classes
{
    public class Utility
    {

        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();

            // return guid after convert it to string.
            return guid.ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string folderPath)
        {
            // Check if folder not exist.
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    // Create folder.
                    Directory.CreateDirectory(folderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Folder creating failed {ex.Message}");
                    return false;
                }
            }
            // return true if folder already exists.
            return true;
        }

        public static string ReplaceFileNameWithGuid(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string extn = fileInfo.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyFileToProjectFilesFolder(ref string sourceFile)
        {
            // The function will copy the image to the project images folder after renaming it
            // with GUID with the same extension, then it will update the source file name with the new name.


            string destinationFolder = System.IO.Directory.GetCurrentDirectory() + @"\LawFirmManagementSystemFiles\";

            if (!CreateFolderIfDoesNotExist(destinationFolder))
                // return false if has exception error.
                return false;

            string destinationFile = destinationFolder + ReplaceFileNameWithGuid(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

    }
}

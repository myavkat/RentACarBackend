using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public static string carImages = "CarImages";
        public static IDataResult<string> AddFile(IFormFile file, string subFolderName)
        {
            if (file == null || file.Length <= 0)
            {
                return new ErrorDataResult<string>("File length less than or equal to zero");
            }
            var folderPath = GetFolderPath(subFolderName);
            CreateDirectoryIfNotExists(folderPath);
            var tempFilePath = Path.GetTempFileName();
            using (FileStream tempFileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                file.CopyTo(tempFileStream);
            }
            var newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullFilePath = folderPath + "/" + newFileName;
            File.Move(tempFilePath, fullFilePath);
            return new SuccessDataResult<string>(newFileName, "File successfully added");
        }
        public static IResult DeleteFile(string fileName, string subFolderName)
        {
            var folderPath = GetFolderPath(subFolderName);
            var completeFilePath = folderPath + "/" + fileName;
            if (!File.Exists(completeFilePath))
            {
                return new ErrorResult("File does not exist");
            }
            File.Delete(completeFilePath);
            return new SuccessResult("File deleted successfully");
        }
        private static string GetFolderPath(string subFolderName)
        {
            return (Environment.CurrentDirectory + "/wwwroot/" + subFolderName);
        }
        private static void CreateDirectoryIfNotExists(string folderPath)
        {

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}

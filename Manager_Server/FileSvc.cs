using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Manager_Server
{
    public class FileSvc : IFileSvc
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filedata"></param>
        /// <returns></returns>
        public UpFileResult UpLoadFile(UpFile filedata)
        {
            UpFileResult result = new UpFileResult();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\File\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fs = new FileStream(path + filedata.FileName, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[filedata.FileSize];
                int count = 0;
                while ((count = filedata.FileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, count);
                }
            }
            result.IsSuccess = true;
            return result;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filedata"></param>
        /// <returns></returns>
        public DownFileResult DownLoadFile(DownFile filedata)
        {
            DownFileResult result = new DownFileResult();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\File\" + filedata.FileName;
            if (!File.Exists(path))
            {
                result.IsSuccess = false;
                result.FileSize = 0;
                result.Message = "服务器不存在此文件";
                result.FileStream = new MemoryStream();
                return result;
            }
            Stream ms = new MemoryStream();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.CopyTo(ms);
            ms.Position = 0;  //重要，不为0的话，客户端读取有问题
            result.IsSuccess = true;
            result.FileSize = ms.Length;
            result.FileStream = ms;
            fs.Flush();
            fs.Close();
            return result;
        }
    }
}

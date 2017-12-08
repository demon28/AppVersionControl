using AppVersionControl.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Winner.Framework.Utils;

namespace AppVersionControl.Api.Models
{
    /// <summary>
    /// 仅拦截APK请求
    /// </summary>
    public class ApkHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.FilePath;
            Uri curl = context.Request.Url;
            string downloadUrl = string.Concat(curl.Scheme, "://", curl.Host, (curl.Port == 80 ? "" : ":" + curl.Port), filename);
            Log.Info($"{curl.AbsoluteUri}已拦截，文件路径{filename}");
            Log.Info($"拼接下载链接：{downloadUrl}");
            Javirs.Common.PerformanceMonitor monitor = new Javirs.Common.PerformanceMonitor();
            monitor.CheckPoint("START COMPUTE FILE HASH");
            string hashCode = ComputeFileHash(filename);
            monitor.CheckPoint("END COMPUTE FILE HASH");
            ApplicationState.State.AppDownload.Countdown(hashCode);
            Log.Info("FILE HASH CODE = " + hashCode);
            Log.Info(monitor.ToString());

            context.Response.ContentType = "application/vnd.android";
            context.Response.WriteFile(filename);
        }
        private static string ComputeFileHash(string filename)
        {
            char second = filename[1];
            string fullpath = filename;
            if (second != ':')
            {
                fullpath = HttpContext.Current.Server.MapPath(filename);
            }
            byte[] allbytes = File.ReadAllBytes(fullpath);
            string hashCode = Winner.Framework.Encrypt.MD5Provider.EncodeFile(new MemoryStream(allbytes));
            return hashCode;
        }


    }
}
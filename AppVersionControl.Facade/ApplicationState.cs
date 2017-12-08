using AppVersionControl.DataAccess;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace AppVersionControl.Facade
{
    /// <summary>
    /// 应用程序状态
    /// </summary>
    public sealed class ApplicationState
    {
        private ApplicationState()
        {
            this.AppDownload = new AppDownloadCount();
        }
        static ApplicationState()
        {
            _state = new ApplicationState();
        }
        private static ApplicationState _state;
        public static ApplicationState State
        {
            get
            {
                return _state;
            }
        }

        public AppDownloadCount AppDownload
        {
            get; set;
        }
    }

    public class AppDownloadCount
    {
        public ConcurrentDictionary<string, int> dictionary;
        public AppDownloadCount()
        {
            dictionary = new ConcurrentDictionary<string, int>();
        }
        /// <summary>
        /// 指定版本下载次数+1
        /// </summary>
        /// <param name="hashCode"></param>
        public void Countdown(string hashCode)
        {
            dictionary.AddOrUpdate(hashCode, 1, (k, v) => { return v + 1; });
        }
        /// <summary>
        /// 将数据持久化到数据库
        /// </summary>
        public void Flush()
        {
            foreach (string key in dictionary.Keys)
            {
                int count = dictionary[key];
                Tvc_Version daVersion = new Tvc_Version();
                bool res = daVersion.CountDownloadTimes(key, count);
                dictionary[key] = 0;
                Log.Info($"HashCode={key},本次程序运行中累计下载量：{count}");
            }
        }
    }
}

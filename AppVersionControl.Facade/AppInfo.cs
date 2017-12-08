using AppVersionControl.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace AppVersionControl.Facade
{
    public class AppInfo
    {
        private static List<AppInfo> all_apps = new List<AppInfo>();
        protected AppInfo()
        {
        }


        private static void LoadData(bool force = false)
        {
            if (all_apps == null)
            {
                all_apps = new List<AppInfo>();
            }
            if (all_apps.Count <= 0 || force)
            {
                all_apps.Clear();
                Tvc_App_InfoCollection daAppCollection = new Tvc_App_InfoCollection();
                daAppCollection.ListAll();
                foreach (Tvc_App_Info mApp in daAppCollection)
                {
                    AppInfo info = new AppInfo
                    {
                        AppName = mApp.En_Name,
                        App_Id = mApp.App_Id,
                        Cn_Name = mApp.Cn_Name,
                        Createtime = mApp.Createtime,
                        Download_Url = mApp.Download_Url,
                        Is_Del = mApp.Is_Del,
                        Secret_Key = mApp.Secret_Key
                    };
                    all_apps.Add(info);
                }
            }
        }

        public static AppInfo Get(string appname)
        {
            LoadData();
            AppInfo app = all_apps.Find(it => appname.Equals(it.AppName, StringComparison.OrdinalIgnoreCase));
            if (app == null)
            {
                LoadData(true);
                app = all_apps.Find(it => appname.Equals(it.AppName, StringComparison.OrdinalIgnoreCase));
            }
            return app;
        }
        public int App_Id { get; set; }
        public string Cn_Name { get; set; }
        public string Secret_Key { get; set; }
        public string Download_Url { get; set; }
        public DateTime Createtime { get; set; }
        public int Is_Del { get; set; }

        [MapMember("EN_NAME")]
        public string AppName { get; set; }
    }
}

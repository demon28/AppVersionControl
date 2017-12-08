using AppVersionControl.DataAccess;
using AppVersionControl.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace AppVersionControl.Facade
{
    public class AppVersion
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Version_Id { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int App_Id { get; set; }
        public string Hash_Code { get; set; }
        public string Download_Url { get; set; }
        public string Version_Code { get; set; }
        public VersionType Version_Type { get; set; }
        public DateTime Create_Time { get; set; }
        public string Release_Note { get; set; }
        public int Is_Force_Upgrade { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int Is_Del { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public long VersionNumber
        {
            get
            {
                Version ver = Version.Parse(this.Version_Code);
                return ver.GetVersionNumber();
            }
        }

    }
    /// <summary>
    /// app版本集合[alpha,beta,release,rc]（不包含已删除的版本）
    /// </summary>
    public class AppVersionCollection
    {
        private List<AppVersion> _verCollection;
        protected AppVersionCollection() { }
        private void Init(bool force = false)
        {
            if (_verCollection == null || force)
            {
                Tvc_VersionCollection daVerCollection = new Tvc_VersionCollection();
                daVerCollection.ListEffectiveAll();
                _verCollection = MapProvider.Map<AppVersion>(daVerCollection.DataTable);
            }
        }
        public static AppVersionCollection SingletonInstance()
        {
            var versionCollection = new AppVersionCollection();
            versionCollection.Init();
            return versionCollection;
        }

        public List<AppVersion> FindAll(Predicate<AppVersion> match)
        {
            var result = _verCollection.FindAll(match);
            if (result == null)
            {
                Init(true);
            }
            return _verCollection.FindAll(match);
        }

        public AppVersion Find(Predicate<AppVersion> match)
        {
            var obj = _verCollection.Find(match);
            if (obj == null)
            {
                Init(true);
            }
            return _verCollection.Find(match);
        }
    }
}

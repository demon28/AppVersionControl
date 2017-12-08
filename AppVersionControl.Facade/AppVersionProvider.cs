using AppVersionControl.DataAccess;
using AppVersionControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;

namespace AppVersionControl.Facade
{
    public class AppVersionProvider : FacadeBase
    {
        private string _appName, _userCode, _version;
        public AppVersionProvider(string appname, string userCode, string version)
        {
            this._appName = appname;
            this._userCode = userCode;
            this._version = version;
        }

        public AppVersion GetNewVersion()
        {
            AppInfo appInfo = AppInfo.Get(this._appName);
            if (appInfo == null)
            {
                return null;
            }
            Version version = Version.Parse(this._version);
            VersionType acceptVersion = UserAcceptVersionType(_userCode, appInfo.App_Id);
            acceptVersion = acceptVersion | VersionType.Release;//always contain RELEASE version
            long verNumber = version.GetVersionNumber();
            var collection = AppVersionCollection.SingletonInstance().FindAll(it => it.App_Id == appInfo.App_Id && it.VersionNumber > verNumber && (it.Version_Type & acceptVersion) == it.Version_Type);
            if (collection == null || collection.Count <= 0)
            {
                return null;
            }
            var forceUpgrades = collection.FindAll(it => it.Is_Force_Upgrade == 1);//force upgrade app versions
            var orderedList = collection.OrderByDescending(it => it.VersionNumber);
            AppVersion latestVersion = orderedList.FirstOrDefault();
            if (latestVersion.Is_Force_Upgrade != 1)
            {
                latestVersion.Is_Force_Upgrade = (forceUpgrades != null && forceUpgrades.Count > 0) ? 1 : 0;
            }
            return latestVersion;
        }

        private static VersionType UserAcceptVersionType(string userCode, int appId)
        {
            Tvc_User daUser = new Tvc_User();
            if (!daUser.SelectByUserCode(userCode))
            {
                return VersionType.Release;
            }
            
            Tvc_TesterCollection daTesterCollection = new Tvc_TesterCollection();
            daTesterCollection.ListByApp_Id(appId);
            Tvc_Tester tester = daTesterCollection.Find(it => it.User_Id == daUser.User_Id);
            if (tester == null)
            {
                return VersionType.Release;
            }
            return (VersionType)tester.Version_Type;
        }
    }
}

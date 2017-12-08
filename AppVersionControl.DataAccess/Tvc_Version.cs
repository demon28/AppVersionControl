using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVersionControl.DataAccess
{
    public partial class Tvc_Version
    {
        public bool CountDownloadTimes(string hashCode, int times)
        {
            string sql = $"UPDATE Tvc_Version SET {_DOWNLOAD_TIMES}={_DOWNLOAD_TIMES}+(:COUNT_TIMES) WHERE {_HASH_CODE}=:{_HASH_CODE}";
            AddParameter("COUNT_TIMES", times);
            AddParameter(_HASH_CODE, hashCode);
            return UpdateBySql(sql);
        }
    }
    public partial class Tvc_VersionCollection
    {
        /// <summary>
        /// 查询所有有效的记录（is_del=0）
        /// </summary>
        /// <returns></returns>
        public bool ListEffectiveAll()
        {
            string sql_condition = "IS_DEL=0";
            return ListByCondition(sql_condition);
        }

        public bool ListByAdmin(int? appId)
        {
            string sql = "SELECT TAI.CN_NAME,TV.* FROM TVC_VERSION TV LEFT JOIN TVC_APP_INFO TAI ON TV.APP_ID=TAI.APP_ID WHERE 1=1";
            if (appId.HasValue)
            {
                sql += " AND TV.APP_ID=:APP_ID";
                AddParameter("APP_ID", appId.Value);
            }
            sql += " ORDER BY TV.CREATE_TIME DESC";
            return ListBySql(sql);
        }
    }
}

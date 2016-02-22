using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Emiips.DbClient;

namespace PMA.Db
{
    class WhnrContext
    {
        /// <summary>
        /// Isoms数据库
        /// </summary>
        private static DbContext _db;

        public static DbContext Db
        {
            get
            {
                if (_db == null || !_db.IsOpened())
                {
                    if (!InitDbContext())
                    {
                        return null;
                    }
                }
                return WhnrContext._db;
            }
        }
        /// <summary>
        /// 重新连接数据库
        /// </summary>
        /// <returns></returns>
        public static bool InitDbContext()
        {
            try
            {
                _db = DbFactory.GetInstance(DbFactoryEnum.SqlServer);
                _db.ConnectString = ConfigurationManager.AppSettings["ConnectString"];
                _db.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

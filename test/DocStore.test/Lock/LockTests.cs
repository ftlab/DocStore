using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using DocStore.MsSql;
using DocStore.Core.Lock;
using DocStore.test.Properties;

namespace DocStore.test.Lock
{
    [TestClass]
    public class LockTests
    {
        [TestMethod]
        public void LOCK_Sql()
        {
            using (var conn = new SqlConnection(Resources.DbConn))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var l = new SqlLock(tran))
                    {
                        var result = l.GetLock(
                            resource: "r1",
                            mode: LockMode.Shared,
                            timeout: default(TimeSpan));
                    }
                }
            }
        }

        [TestMethod]
        public void LOCK_Db()
        {
            using (var conn = new SqlConnection(Resources.DbConn))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var l = new DbLock(tran))
                    {
                        var result = l.GetLock(
                            resource: "r1",
                            mode: LockMode.Shared,
                            timeout: default(TimeSpan));
                    }
                }
            }
        }
    }
}

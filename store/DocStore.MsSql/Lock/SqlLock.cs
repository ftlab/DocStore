using DocStore.Core.Lock;
using System;
using System.Data.SqlClient;
using System.Data;

namespace DocStore.MsSql
{
    /// <summary>
    /// Механизм получения блокировки на MS SQL
    /// </summary>
    public class SqlLock : DbLock
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="tran">транзакция</param>
        public SqlLock(SqlTransaction tran) : base(tran) { }

        /// <summary>
        /// Транзакция
        /// </summary>
        public new SqlTransaction Tran => (SqlTransaction)base.Tran;

        /// <summary>
        /// Соединение к БД
        /// </summary>
        public new SqlConnection Conn => (SqlConnection)base.Conn;

        /// <summary>
        /// Получить блокировку
        /// </summary>
        /// <param name="resource">ресурс</param>
        /// <param name="mode">режим</param>
        /// <param name="owner">владелец</param>
        /// <param name="timeout">таймаут</param>
        /// <returns>результат</returns>
        public override LockResult GetLock(
            string resource
            , LockMode mode
            , string owner = null
            , TimeSpan? timeout = default(TimeSpan?))
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            using (var cmd = Conn.CreateCommand())
            {
                cmd.Transaction = Tran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_getapplock";

                cmd.Parameters.AddWithValue("Resource", resource);
                cmd.Parameters.AddWithValue("LockMode", mode.ToString());
                if (owner != null)
                    cmd.Parameters.AddWithValue("LockOwner", owner);
                if (timeout != null)
                    cmd.Parameters.AddWithValue("LockTimeout", timeout.Value.TotalMilliseconds);

                return (LockResult)cmd.ExecuteNonQuery();
            }
        }
    }
}

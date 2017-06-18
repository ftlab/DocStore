using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DocStore.Censor.Model
{
    public class DataReaderBuilder<T>
    {
        private readonly Dictionary<string, MemberInfo> _maps = new Dictionary<string, MemberInfo>();

        public DataReaderBuilder<T> AddMap(string destination, MemberInfo source)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (_maps.ContainsKey(destination)) throw new ArgumentException(nameof(destination));
            if ((source is FieldInfo || source is PropertyInfo) == false) throw new ArgumentException(nameof(source));

            _maps.Add(destination, source);

            return this;
        }

        public DataReaderBuilder<T> AddMap(MemberInfo source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return AddMap(source.Name, source);
        }

        public DataReaderBuilder<T> AddMap(string destination, string source)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (source == null) throw new ArgumentNullException(nameof(source));

            var type = typeof(T);
            var property = type.GetProperty(source);
            if (property != null)
                return AddMap(destination, property);
            var field = type.GetField(source);
            if (field != null)
                return AddMap(destination, field);

            throw new ArgumentException(nameof(source));
        }

        public DataReaderBuilder<T> AddMap(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return AddMap(source, source);
        }

        public DataReaderBuilder<T> AddMap<P>(string destination, Expression<Func<T, P>> source)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (source == null) throw new ArgumentNullException(nameof(source));

            var member = GetMember(source);
            if (member != null) return AddMap(destination, member);

            throw new ArgumentException(nameof(source));
        }

        public DataReaderBuilder<T> AddMap<P>(Expression<Func<T, P>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var member = GetMember(source);
            if (member != null) return AddMap(member);

            throw new ArgumentException(nameof(source));
        }

        public IDataReader Create(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return new DataReader(items);
        }

        private static MemberInfo GetMember<P>(Expression<Func<T, P>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            MemberExpression member;
            if (source.Body.NodeType == ExpressionType.Convert)
                member = ((UnaryExpression)source.Body).Operand as MemberExpression;
            else
                member = source.Body as MemberExpression;

            return member?.Member;
        }

        private class DataReader : IDataReader
        {
            public DataReader(IEnumerable<T> items)
            {

            }

            object IDataRecord.this[int i] => throw new NotImplementedException();

            object IDataRecord.this[string name] => throw new NotImplementedException();

            int IDataReader.Depth => throw new NotImplementedException();

            bool IDataReader.IsClosed => throw new NotImplementedException();

            int IDataReader.RecordsAffected => throw new NotImplementedException();

            int IDataRecord.FieldCount => throw new NotImplementedException();

            void IDataReader.Close()
            {
                throw new NotImplementedException();
            }

            bool IDataRecord.GetBoolean(int i)
            {
                throw new NotImplementedException();
            }

            byte IDataRecord.GetByte(int i)
            {
                throw new NotImplementedException();
            }

            long IDataRecord.GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }

            char IDataRecord.GetChar(int i)
            {
                throw new NotImplementedException();
            }

            long IDataRecord.GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }

            IDataReader IDataRecord.GetData(int i)
            {
                throw new NotImplementedException();
            }

            string IDataRecord.GetDataTypeName(int i)
            {
                throw new NotImplementedException();
            }

            DateTime IDataRecord.GetDateTime(int i)
            {
                throw new NotImplementedException();
            }

            decimal IDataRecord.GetDecimal(int i)
            {
                throw new NotImplementedException();
            }

            double IDataRecord.GetDouble(int i)
            {
                throw new NotImplementedException();
            }

            Type IDataRecord.GetFieldType(int i)
            {
                throw new NotImplementedException();
            }

            float IDataRecord.GetFloat(int i)
            {
                throw new NotImplementedException();
            }

            Guid IDataRecord.GetGuid(int i)
            {
                throw new NotImplementedException();
            }

            short IDataRecord.GetInt16(int i)
            {
                throw new NotImplementedException();
            }

            int IDataRecord.GetInt32(int i)
            {
                throw new NotImplementedException();
            }

            long IDataRecord.GetInt64(int i)
            {
                throw new NotImplementedException();
            }

            string IDataRecord.GetName(int i)
            {
                throw new NotImplementedException();
            }

            int IDataRecord.GetOrdinal(string name)
            {
                throw new NotImplementedException();
            }

            DataTable IDataReader.GetSchemaTable()
            {
                throw new NotImplementedException();
            }

            string IDataRecord.GetString(int i)
            {
                throw new NotImplementedException();
            }

            object IDataRecord.GetValue(int i)
            {
                throw new NotImplementedException();
            }

            int IDataRecord.GetValues(object[] values)
            {
                throw new NotImplementedException();
            }

            bool IDataRecord.IsDBNull(int i)
            {
                throw new NotImplementedException();
            }

            bool IDataReader.NextResult()
            {
                throw new NotImplementedException();
            }

            bool IDataReader.Read()
            {
                throw new NotImplementedException();
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~DataReader() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            void IDisposable.Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}

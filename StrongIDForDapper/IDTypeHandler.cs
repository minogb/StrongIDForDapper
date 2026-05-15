
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Strong.ID {
    public class GenericIDTypeHandler<T,J> : SqlMapper.TypeHandler<GenericID<T,J>> where J : IComparable {
        public override void SetValue(IDbDataParameter parameter, GenericID<T,J> value) {
            parameter.Value = value.Value;
        }
        public override GenericID<T, J> Parse(object value) {
            return new GenericID<T, J>((J)value);
        }
    }
    internal class IDTypeHandler<T> : SqlMapper.TypeHandler<ID<T>>{
        public override void SetValue(IDbDataParameter parameter, ID<T> value) {
            parameter.Value = value.Value;
        }
        public override ID<T> Parse(object value) {
            return new ID<T>((int)value);
        }
    }
    internal class BigIDTypeHandler<T> : SqlMapper.TypeHandler<BigID<T>> {
        public override void SetValue(IDbDataParameter parameter, BigID<T> value) {
            parameter.Value = value.Value;
        }
        public override BigID<T> Parse(object value) {
            return new BigID<T>((BigInteger)value);
        }
    }
    internal class LooseIDTypeHandler<T> : SqlMapper.TypeHandler<LooseID<T>> {
        public override void SetValue(IDbDataParameter parameter, LooseID<T> value) {
            parameter.Value = value.Value;
        }
        public override LooseID<T> Parse(object value) {
            return new LooseID<T>((string)value);
        }
    }
    public static class StrongIDMapper {
        public static void AddStrongIDTypeHandlers<T>() {
            SqlMapper.AddTypeHandler(new IDTypeHandler<T>());
        }
        public static void AddStrongBigIDTypeHandlers<T>() {
            SqlMapper.AddTypeHandler(new BigIDTypeHandler<T>());
        }
        public static void AddStrongLooseIDTypeHandlers<T>() {
            SqlMapper.AddTypeHandler(new LooseIDTypeHandler<T>());
        }
        public static void AddStrongGenericIDTypeHandlers<T,J>() where J : IComparable {
            SqlMapper.AddTypeHandler(new GenericIDTypeHandler<T,J>());
        }
    }
}

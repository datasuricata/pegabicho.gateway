using pegabicho.domain.Entities.Base;
using System;
using System.Linq.Expressions;

namespace pegabicho.infra.Specs.Base {
    public abstract class SpecBase<T> where T : EntityBase {
        public static Func<T, bool> ActiveRecord(Func<T, bool> where) {
            return x => !x.IsDeleted;
        }
        public static Expression<Func<T,bool>> eActiveRecord(Func<T, bool> where) {
            return x => !x.IsDeleted;
        }
    }
}

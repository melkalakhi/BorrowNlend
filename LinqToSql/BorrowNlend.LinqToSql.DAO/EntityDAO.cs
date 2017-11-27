using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using System.Collections;

namespace BorrowNlend.LinqToSql.DAO
{
    public abstract class Entity<T> : IEntity<T> where T :  EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        public abstract int Add(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public abstract void Update(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public abstract void Delete(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        public void SubmitChanges()
        {
            Context.Instance.SubmitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator<T> GetEnumerator();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

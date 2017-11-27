using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using System.Collections;

namespace BorrowNlend.LinqToSql.DAO
{
    public interface IEntity<T> : IEnumerable<T> where T : EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        int Add(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        void Update(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        void Delete(T entityDto);

        /// <summary>
        /// 
        /// </summary>
        void SubmitChanges();

    }
}

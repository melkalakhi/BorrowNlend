using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.DataSet.Typed.DAO.Generic.Contract;
using System.Data;
using System.Data.Common;
using System.ComponentModel;

namespace BorrowNlend.DataSet.Typed.DAO.Generic
{
    public abstract class EntityDAO<T> : IEntityDAO<T> where T : EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        public abstract int Add(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public abstract void Delete(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public abstract void Update(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public abstract T GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<T> GetAll();

    }
}

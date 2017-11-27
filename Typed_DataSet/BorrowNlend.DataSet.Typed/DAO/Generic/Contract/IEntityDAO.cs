using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using BorrowNlend.DataSet.DTO;
using System.Data;

namespace BorrowNlend.DataSet.Typed.DAO.Generic.Contract
{
    public interface IEntityDAO<T>
        where T : EntityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        int Add(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

    }
}

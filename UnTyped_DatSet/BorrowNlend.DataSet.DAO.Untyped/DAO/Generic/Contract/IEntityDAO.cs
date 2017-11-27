using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using BorrowNlend.DataSet.DTO;
using System.Data;

namespace BorrowNlend.DataSet.DAO.Generic.Contract
{
    public interface IEntityDAO<T1, T2>
        where T1 : EntityDTO
        where T2 : DbCommandBuilder, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        T1 Add(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T1 GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<T1> GetAll();

    }
}

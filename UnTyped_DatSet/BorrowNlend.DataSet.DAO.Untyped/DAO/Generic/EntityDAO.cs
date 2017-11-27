using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.DataSet.DAO.Context;
using BorrowNlend.DataSet.DAO.Generic.Contract;

namespace BorrowNlend.DataSet.DAO.Generic
{
    public abstract class EntityDAO<T1,T2> : IEntityDAO<T1, T2> 
        where T1 : EntityDTO 
        where T2 : DbCommandBuilder, new()
    {
        /// <summary>
        /// 
        /// </summary>
        protected abstract Context.Context Context { get; }

        /// <summary>
        /// 
        /// </summary>
        protected abstract string TableName { get; }

        /// <summary>
        /// 
        /// </summary>
        protected DataTable DataTable 
        {
            get
            {
                return Context.DataSet.Tables[TableName];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract DbDataAdapter DataAdapter { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public abstract T1 Add(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public abstract void Delete(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public abstract void Update(T1 entityDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T1 GetById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IList<T1> GetAll();

        /// <summary>
        /// 
        /// </summary>
        protected void SaveChanges()
        {
            try
            {
                DataAdapter.Update(Context.DataSet, TableName);
                DataTable.AcceptChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        protected virtual DataRow GetDataRowById(int Id)
        {
            try
            {

                IEnumerable<DataRow> dataRowEnumerable = DataTable.AsEnumerable();
                DataRow dataRow = dataRowEnumerable.First(dr => (dr.RowState != DataRowState.Deleted) && (dr.RowState != DataRowState.Detached) && ((int)dr["ID"] == Id));
                return dataRow;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

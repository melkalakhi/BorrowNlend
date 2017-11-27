using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using System.Data.Common;
using BorrowNlend.DataSet.DAO.Generic;

namespace BorrowNlend.DataSet.DAO.Context.Sql.Generic
{
    public abstract class SqlEntityDAO<T1, T2>  : EntityDAO<T1, T2>
        where T1 : EntityDTO
        where T2 : DbCommandBuilder, new()
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// 
        protected override Context Context
        {
            get { return ContextFactory.CreateContext(ContextType.SQL); }
        }
    }
}

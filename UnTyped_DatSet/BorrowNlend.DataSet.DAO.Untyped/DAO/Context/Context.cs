using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace BorrowNlend.DataSet.DAO.Context
{
    public abstract class Context
    {

        /// <summary>
        /// 
        /// </summary>
        ///
        protected string connectionString;
        protected abstract string ConnectionString { get;  }

        /// <summary>
        /// 
        /// </summary>
        public System.Data.DataSet DataSet { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public DbDataAdapter PersonDataAdapter { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public DbDataAdapter OperationDataAdapter { get; protected set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DAO.Context.Sql;

namespace BorrowNlend.DataSet.DAO.Context
{
    public class ContextFactory
    {
        public static Context CreateContext(ContextType contextType)
        {
            try
            {
                Context context = null;

                switch (contextType)
                {
                    case ContextType.SQL:
                        context = SqlContext.Instance;
                        break;
                    case ContextType.ORACLE :
                        break;
                    case ContextType.ODBC:
                        break;
                    case ContextType.OLE:
                        break;
                    default:
                        break;
                }

                return context;
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.LinqToSql.Dbml;

namespace BorrowNlend.LinqToSql.DAO
{
    public sealed class Context : BorrowNlendDataClassesDataContext
    {
        private Context() : base()
        {
            Log = Console.Out;
        }

        private static Context _Instance;
        public static Context Instance 
        {
            get
            {
                _Instance = _Instance ?? new Context();
                return _Instance;
            }
        }
    }
}

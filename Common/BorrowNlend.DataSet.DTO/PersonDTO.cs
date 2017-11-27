using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorrowNlend.DataSet.DTO
{
    public class PersonDTO : EntityDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}

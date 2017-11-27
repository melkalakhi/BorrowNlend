using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO.Csts;

namespace BorrowNlend.DataSet.DTO
{
    public class OperationDTO : EntityDTO
    {
        public double Amount { get; set; }

        public OperationType Type { get; set; }

        public PersonDTO Person { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using BorrowNlend.DataSet.DTO;
using System.Data;
using BorrowNlend.DataSet.DAO.Context.Sql.Generic;
using BorrowNlend.DataSet.DAO.Generic;
using BorrowNlend.DataSet.DTO.Csts;

namespace BorrowNlend.DataSet.DAO
{
    public class OperationDAO : SqlEntityDAO<OperationDTO, SqlCommandBuilder>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Operation"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DbDataAdapter DataAdapter
        {
            get { return Context.OperationDataAdapter; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static EntityDAO<DTO.OperationDTO, SqlCommandBuilder> instance;
        public static EntityDAO<DTO.OperationDTO, SqlCommandBuilder> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OperationDAO();
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private OperationDAO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public override OperationDTO Add(OperationDTO operationDTO)
        {
            try
            {
                DataRow dataRow = DataTable.NewRow();
                dataRow["Amount"] = operationDTO.Amount;
                dataRow["Type"] = operationDTO.Type;
                dataRow["Person_ID"] = operationDTO.Person.ID;
                DataTable.Rows.Add(dataRow);
                SaveChanges();
                operationDTO.ID = (int)dataRow["ID"];
                return operationDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public override void Delete(OperationDTO operationDTO)
        {
            try
            {
                DataRow dataRow = GetDataRowById(operationDTO.ID);
                if (dataRow != null)
                {
                    dataRow.Delete();
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(OperationDTO operationDTO)
        {
            try
            {
                DataRow dataRow = GetDataRowById(operationDTO.ID);
                if (dataRow != null)
                {
                    dataRow["Amount"] = operationDTO.Amount;
                    dataRow["Type"] = operationDTO.Type;
                    dataRow["Person_ID"] = operationDTO.Person.ID;
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override OperationDTO GetById(int Id)
        {
            try
            {
                OperationDTO operationDTO = null;
                DataRow dataRow = GetDataRowById(Id);
                if (dataRow != null)
                {
                    operationDTO = new OperationDTO()
                    {
                        ID = (int)dataRow["ID"],
                        Amount = (double)dataRow["Amount"],
                        Type = (OperationType)(short)dataRow["Type"]
                    };

                    int personId = (int)dataRow["Person_ID"];
                    PersonDTO personDTO = PersonDAO.Instance.GetById(personId);
                    operationDTO.Person = personDTO;
                }
                return operationDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IList<OperationDTO> GetAll()
        {
            try
            {

                IEnumerable<DataRow> dataRowEnumerable = DataTable.AsEnumerable();
                //IEnumerable<OperationDTO> operationDtoEnumerable = dataRowEnumerable.
                //    Where(dataRow => dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached).
                //    Select(
                //    delegate(DataRow dataRow)
                //    {
                //        OperationDTO operationDTO = new OperationDTO()
                //        {
                //            ID = (int)dataRow["ID"],
                //            Amount = (double)dataRow["Amount"],
                //            Type = (OperationType)(short)dataRow["Type"]
                //        };
                //        int personId = (int)dataRow["Person_ID"];
                //        PersonDTO personDTO = PersonDAO.Instance.GetById(personId);
                //        operationDTO.Person = personDTO; 
                //        return operationDTO;
                //    });
                IEnumerable<OperationDTO> operationDtoEnumerable = dataRowEnumerable.
                    Where(dataRow => dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached).
                    Select(
                    (dataRow) =>
                    {
                        OperationDTO operationDTO = new OperationDTO()
                        {
                            ID = (int)dataRow["ID"],
                            Amount = (double)dataRow["Amount"],
                            Type = (OperationType)(short)dataRow["Type"]
                        };
                        int personId = (int)dataRow["Person_ID"];
                        PersonDTO personDTO = PersonDAO.Instance.GetById(personId);
                        operationDTO.Person = personDTO;
                        return operationDTO;
                    }
                    );

                operationDtoEnumerable = operationDtoEnumerable.Where(operationDTO => operationDTO != null);

                return operationDtoEnumerable.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

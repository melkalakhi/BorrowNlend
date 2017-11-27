using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.Typed.Model.BorrowNlendDataSetTableAdapters;
using BorrowNlend.DataSet.Typed.Model;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.DataSet.Typed.DAO.Generic;
using BorrowNlend.DataSet.DTO.Csts;

namespace BorrowNlend.DataSet.Typed.DAO
{
    public class OperationDAO : EntityDAO<OperationDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        private OperationTableAdapter _OperationTableAdapter;
        private OperationTableAdapter OperationTableAdapter
        {
            get 
            {
                _OperationTableAdapter = _OperationTableAdapter ?? new OperationTableAdapter();
                return _OperationTableAdapter;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private BorrowNlendDataSet.OperationDataTable _OperationDataTable;
        private BorrowNlendDataSet.OperationDataTable OperationDataTable
        {
            get
            {
                _OperationDataTable = _OperationDataTable ?? new BorrowNlendDataSet.OperationDataTable();
                return _OperationDataTable;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static EntityDAO<OperationDTO> instance;
        public static EntityDAO<OperationDTO> Instance
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
        /// <param name="entityDTO"></param>
        /// <returns></returns>
        public override int Add(OperationDTO operationDTO)
        {
            try
            {
                int Id = OperationTableAdapter.Insert(operationDTO.Amount, (short)operationDTO.Type, operationDTO.Person.ID);
                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public override void Delete(OperationDTO operationDTO)
        {
            try
            {
                OperationTableAdapter.Delete(operationDTO.ID, operationDTO.Amount, (short)operationDTO.Type, operationDTO.Person.ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDTO"></param>
        public override void Update(OperationDTO operationDTO)
        {
            try
            {
                OperationTableAdapter.Update(operationDTO.Amount, (short)operationDTO.Type, operationDTO.Person.ID, operationDTO.ID);
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
        public override OperationDTO GetById(int Id)
        {
            try
            {
                OperationTableAdapter.Fill(OperationDataTable);
                BorrowNlendDataSet.OperationRow operationRow = OperationDataTable.First(opRow => opRow.ID == Id);

                OperationDTO operationDTO = new OperationDTO() 
                { 
                    ID = operationRow.ID, 
                    Amount = operationRow.Amount, 
                    Type = (OperationType)operationRow.Type, 
                    Person = PersonDAO.Instance.GetById(operationRow.Person_ID)
                };

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
        public override IEnumerable<OperationDTO> GetAll()
        {
            try
            {
                OperationTableAdapter.Fill(OperationDataTable);
                IEnumerable<OperationDTO> operationDTOs = OperationDataTable.Select(operationRow => new OperationDTO()
                {
                    ID = operationRow.ID,
                    Amount = operationRow.Amount,
                    Type = (OperationType)operationRow.Type,
                    Person = PersonDAO.Instance.GetById(operationRow.Person_ID)
                });
                return operationDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.LinqToSql.Dbml;
using BorrowNlend.DataSet.DTO.Csts;

namespace BorrowNlend.LinqToSql.DAO
{
    public class OperationDAO : Entity<OperationDTO>
    {

        /// <summary>
        /// 
        /// </summary>
        private static OperationDAO _Instance;
        public static OperationDAO Instance
        {
            get
            {
                _Instance = _Instance ?? new OperationDAO();
                return _Instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public override int Add(OperationDTO operationDto)
        {
            try
            {
                Operation operation = new Operation();
                operation.Amount = operationDto.Amount;
                operation.Type = (short)operationDto.Type;
                operation.Person_ID = operationDto.Person.ID;
                Context.Instance.Operation.InsertOnSubmit(operation);
                SubmitChanges();
                return operation.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityDto"></param>
        public override void Update(OperationDTO operationDto)
        {
            try
            {
                Operation operation = Context.Instance.Operation.First(op => op.ID == operationDto.ID);
                if (operation != null)
                {
                    operation.ID = operationDto.ID;
                    operation.Amount = operationDto.Amount;
                    operation.Type = (short)operationDto.Type;
                    operation.Person_ID = operationDto.Person.ID;
                    SubmitChanges();
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
        /// <param name="entityDto"></param>
        public override void Delete(OperationDTO operationDto)
        {
            Operation operation = null;

            try
            {
                operation = Context.Instance.Operation.First(op => op.ID == operationDto.ID);
                if (operation != null)
                {
                    Context.Instance.Operation.DeleteOnSubmit(operation);
                    SubmitChanges();
                }
            }
            catch (Exception)
            {

                try
                {
                    if (operation != null)
                    {
                        Context.Instance.Operation.InsertOnSubmit(operation);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<OperationDTO> GetEnumerator()
        {
            OperationDTO operationDto = null;
            foreach (Operation operation in Context.Instance.Operation)
            {
                operationDto = new OperationDTO();
                operationDto.ID = operation.ID;
                operationDto.Amount = operation.Amount;
                operationDto.Type = (OperationType)operation.Type;
                operationDto.Person = PersonDAO.Instance.First(personDto => personDto.ID == operation.Person_ID);

                yield return operationDto;
            }
        }
    }
}

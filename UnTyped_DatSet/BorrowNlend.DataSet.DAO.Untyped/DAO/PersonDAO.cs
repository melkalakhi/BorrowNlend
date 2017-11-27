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

namespace BorrowNlend.DataSet.DAO
{
    public class PersonDAO : SqlEntityDAO<PersonDTO, SqlCommandBuilder>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Person"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DbDataAdapter DataAdapter
        {
            get { return Context.PersonDataAdapter; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static EntityDAO<PersonDTO, SqlCommandBuilder> instance;
        public static EntityDAO<PersonDTO, SqlCommandBuilder> Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PersonDAO();
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private PersonDAO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personDTO"></param>
        public override PersonDTO Add(PersonDTO personDTO)
        {
            try
            {
                DataRow dataRow = DataTable.NewRow();
                dataRow["Name"] = personDTO.Name;
                dataRow["Email"] = personDTO.Email;
                dataRow["Address"] = personDTO.Address;
                DataTable.Rows.Add(dataRow);
                SaveChanges();
                personDTO.ID = (int)dataRow["ID"];
                return personDTO;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personDTO"></param>
        public override void Delete(PersonDTO personDTO)
        {
            try
            {
                DataRow dataRow = GetDataRowById(personDTO.ID);
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
        /// <param name="personDTO"></param>
        public override void Update(PersonDTO personDTO)
        {
            try
            {
                DataRow dataRow = GetDataRowById(personDTO.ID);
                if (dataRow != null)
                {
                    dataRow["Name"] = personDTO.Name;
                    dataRow["Email"] = personDTO.Email;
                    dataRow["Address"] = personDTO.Address;
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
        public override DTO.PersonDTO GetById(int Id)
        {
            try
            {
                PersonDTO personDTO = null;
                DataRow dataRow = GetDataRowById(Id);
                if (dataRow != null)
                {
                    personDTO = new PersonDTO { 
                        ID = (int)dataRow["ID"], 
                        Name = (string)dataRow["Name"], 
                        Email = (string)dataRow["Email"], 
                        Address = (string)dataRow["Address"]};
                }
                return personDTO;
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
        public override IList<PersonDTO> GetAll()
        {
            try
            {
                IEnumerable<DataRow> dataRowEnumerable = DataTable.AsEnumerable();
                IEnumerable<PersonDTO> personDtoEnumerable = dataRowEnumerable.
                    Where(dataRow => dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached).
                    Select(dataRow => new PersonDTO
                    {
                        ID = (int)dataRow["ID"],
                        Email = (string)dataRow["Email"],
                        Address = (string)dataRow["Address"]
                    });
                
                return personDtoEnumerable.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

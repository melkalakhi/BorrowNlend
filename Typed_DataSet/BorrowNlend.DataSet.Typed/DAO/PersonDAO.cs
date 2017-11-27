using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.Typed.DAO.Generic;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.DataSet.Typed.Model;
using BorrowNlend.DataSet.Typed.Model.BorrowNlendDataSetTableAdapters;
using System.Data;
using System.ComponentModel;

namespace BorrowNlend.DataSet.Typed.DAO
{
    public class PersonDAO : EntityDAO<PersonDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        private PersonTableAdapter _DataAdapter;
        private PersonTableAdapter DataAdapter
        {
            get 
            {
                _DataAdapter = _DataAdapter ?? new PersonTableAdapter();
                return _DataAdapter;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private BorrowNlendDataSet.PersonDataTable _DataTable;
        private BorrowNlendDataSet.PersonDataTable DataTable
        {
            get 
            {
                _DataTable = _DataTable ?? new BorrowNlendDataSet.PersonDataTable();
                return _DataTable; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static EntityDAO<PersonDTO> instance;
        public static EntityDAO<PersonDTO> Instance
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
        /// <param name="personDTO"></param>
        /// <returns></returns>
        public override int Add(PersonDTO personDTO)
        {
            try
            {
                int id = DataAdapter.Insert(personDTO.Name, personDTO.Email, personDTO.Address);
                return id;
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
                DataAdapter.Delete(personDTO.ID);
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
                DataAdapter.Update(personDTO.Name, personDTO.Email, personDTO.Address, personDTO.ID);
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
        public override PersonDTO GetById(int Id)
        {
            try
            {
                DataAdapter.Fill(DataTable);
                BorrowNlendDataSet.PersonRow personRow = DataTable.First(row => row.ID == Id);
                return new PersonDTO 
                { 
                    ID = personRow.ID, 
                    Address = personRow.Address, 
                    Email = personRow.Email, 
                    Name = personRow.Name 
                };
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
        public override IEnumerable<PersonDTO> GetAll()
        {
            try
            {
                DataAdapter.Fill(DataTable);
                IEnumerable<PersonDTO> personDTOs = DataTable.Select(personRow => new PersonDTO
                {
                    ID = personRow.ID,
                    Address = personRow.Address,
                    Email = personRow.Email,
                    Name = personRow.Name
                });

                return personDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

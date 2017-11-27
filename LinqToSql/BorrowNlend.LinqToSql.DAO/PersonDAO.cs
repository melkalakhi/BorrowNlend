using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.LinqToSql.Dbml;
using System.Data.Linq;

namespace BorrowNlend.LinqToSql.DAO
{
    public class PersonDAO : Entity<PersonDTO>
    {

        /// <summary>
        /// 
        /// </summary>
        private static PersonDAO _Instance;
        public static PersonDAO Instance
        {
            get
            {
                _Instance = _Instance ?? new PersonDAO();
                return _Instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personDto"></param>
        public override int Add(PersonDTO personDto)
        {
            try
            {
                Person person = new Person();
                person.Name = personDto.Name;
                person.Address = personDto.Address;
                person.Email = personDto.Email;
                Context.Instance.Person.InsertOnSubmit(person);
                SubmitChanges();
                return person.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personDto"></param>
        public override void Update(PersonDTO personDto)
        {
            try
            {
                Person person = Context.Instance.Person.First(p => p.ID == personDto.ID);
                if (person != null)
                {
                    person.Name = personDto.Name;
                    person.Address = personDto.Address;
                    person.Email = personDto.Email;
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
        /// <param name="personDto"></param>
        public override void Delete(PersonDTO personDto)
        {
            Person person = null;
            try
            {
                person = Context.Instance.Person.First(p => p.ID == personDto.ID);
                if (person != null)
                {
                    Context.Instance.Person.DeleteOnSubmit(person);
                    SubmitChanges();
                }
            }
            catch (Exception)
            {
                try
                {
                    if (person != null)
                    {
                        Context.Instance.Person.InsertOnSubmit(person);
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
        public override IEnumerator<PersonDTO> GetEnumerator()
        {
            PersonDTO personDto = null;

            foreach (Person person in Context.Instance.Person)
            {
                personDto = new PersonDTO();
                personDto.ID = person.ID;
                personDto.Name = person.Name;
                personDto.Address = person.Address;
                personDto.Email = person.Email;

                yield return personDto;
            }
        }
    }
}

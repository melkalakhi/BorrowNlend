using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.LinqToSql.DAO;
using NUnit.Framework;

namespace BorrowNlend.LinqToSql.Test
{
    public class PersonTest
    {
        [TestCase("Mohammed ELKALAKHI", "DB My Bouchaib Rue 3 N 19 CD Casablanca", "mohammed.elkalakhi@gmail.com", "ELKALAKHI Mohammed", "DB My Bouchaib Rue 3 N 19 CD, Casablanca, Maroc", "melkalakhi@alliativ.com")]
        public void TestPerson(string Name, string Address, string Email, string NewName, string NewAddress, string NewEmail)
        {
            int count = PersonDAO.Instance.Count();

            // Ajouter une personne
            PersonDTO personDTO = new PersonDTO();
            personDTO.Name = Name;
            personDTO.Address = Address;
            personDTO.Email = Email;
            PersonDAO.Instance.Add(personDTO);

            // La liste des personne
            Assert.AreEqual(count + 1, PersonDAO.Instance.Count());

            // Récupérer par ID
            int Id = PersonDAO.Instance.ElementAt(count).ID;
            personDTO = PersonDAO.Instance.First(p => p.ID == Id);
            Assert.NotNull(personDTO);

            // Mettre à jour la personne
            personDTO.Name = NewName;
            personDTO.Address = NewAddress;
            personDTO.Email = NewEmail;
            PersonDAO.Instance.Update(personDTO);

            // Supprimer la personne
            PersonDAO.Instance.Delete(personDTO);
        }
    }
}

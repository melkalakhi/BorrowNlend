using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BorrowNlend.DataSet.Typed.DAO;
using BorrowNlend.DataSet.DTO;

namespace BorrowNlend.DataSet.Typed.Test
{
    public class PersonTest
    {
        [TestCase("Mohammed ELKALAKHI", "DB My Bouchaib Rue 3 N 19 CD Casablanca", "mohammed.elkalakhi@gmail.com", "ELKALAKHI Mohammed", "DB My Bouchaib Rue 3 N 19 CD, Casablanca, Maroc", "melkalakhi@alliativ.com")]
        public void TestPerson(string Name, string Address, string Email, string NewName, string NewAddress, string NewEmail)
        {
            IEnumerable<PersonDTO> personDTOs = PersonDAO.Instance.GetAll();
            int count = personDTOs != null ? personDTOs.Count() : 0;

            // Ajouter une personne
            PersonDTO personDTO = new PersonDTO();
            personDTO.Name = Name;
            personDTO.Address = Address;
            personDTO.Email = Email;
            personDTO.ID = PersonDAO.Instance.Add(personDTO);

            // La liste des personne
            personDTOs = PersonDAO.Instance.GetAll();
            Assert.NotNull(personDTOs);
            Assert.AreEqual(count + 1, personDTOs.Count());

            // Récupérer par ID
            int Id = personDTOs.ElementAt(count).ID;
            personDTO = PersonDAO.Instance.GetById(Id);
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

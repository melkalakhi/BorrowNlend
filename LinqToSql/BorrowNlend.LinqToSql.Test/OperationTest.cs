using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorrowNlend.DataSet.DTO.Csts;
using NUnit.Framework;
using BorrowNlend.DataSet.DTO;
using BorrowNlend.LinqToSql.DAO;
using System.Data.SqlClient;

namespace BorrowNlend.LinqToSql.Test
{
    public class OperationTest
    {
        [TestCase("Mohammed ELKALAKHI", "DB My Bouchaib Rue 3 N 19 CD Casablanca", "mohammed.elkalakhi@gmail.com", 100.85, OperationType.BORROW,
            "Mehdi ELKALAKHI", "DB My Bouchaib Rue 3 N 19 CD Casablanca", "mehdi.elkalakhi@gmail.com", 258.986, OperationType.LEND)]
        public void TestOperation(string Name1, string Address1, string Email1, double Amount1, OperationType Type1,
            string Name2, string Address2, string Email2, double Amount2, OperationType Type2)
        {

            // Liste initiale des opérations
            int count1 = OperationDAO.Instance.Count();

            // Ajout d'une personne
            PersonDTO personDTO = new PersonDTO();
            personDTO.Name = Name1;
            personDTO.Address = Address1;
            personDTO.Email = Email1;
            personDTO.ID = PersonDAO.Instance.Add(personDTO);

            // Ajout d'une opération
            OperationDTO operationDTO = new OperationDTO();
            operationDTO.Amount = Amount1;
            operationDTO.Type = Type1;
            operationDTO.Person = personDTO;
            OperationDAO.Instance.Add(operationDTO);

            // Récupérer la dérnière opération créee
            // Récupérer la liste de toutes les opérations
            int count2 = OperationDAO.Instance.Count();
            Assert.AreEqual(count2, count1 + 1);
            operationDTO = OperationDAO.Instance.ElementAt(count1);
            Assert.NotNull(operationDTO);

            // Récupérer l'opération par ID
            int operationId = operationDTO.ID;
            operationDTO = OperationDAO.Instance.First(op => op.ID == operationId);
            Assert.NotNull(operationDTO);
            personDTO = operationDTO.Person;
            Assert.NotNull(personDTO);

            // Supprimer la personne
            Assert.Throws<SqlException>(delegate() { PersonDAO.Instance.Delete(personDTO); });
            Assert.Throws<SqlException>(() => PersonDAO.Instance.Delete(personDTO));

            PersonDTO personDTO2 = personDTO;

            // Modification d'une opération
            // Ajout d'une autre personne
            personDTO = new PersonDTO();
            personDTO.Name = Name2;
            personDTO.Address = Address2;
            personDTO.Email = Email2;
            personDTO.ID = PersonDAO.Instance.Add(personDTO);

            operationDTO.Person = personDTO;
            operationDTO.Amount = Amount2;
            operationDTO.Type = Type2;
            OperationDAO.Instance.Update(operationDTO);

            // Supprimer la première personne créee
            PersonDAO.Instance.Delete(personDTO2);

            // Suppression d'une opération
            OperationDAO.Instance.Delete(operationDTO);
            PersonDAO.Instance.Delete(personDTO);
        }

    }
}

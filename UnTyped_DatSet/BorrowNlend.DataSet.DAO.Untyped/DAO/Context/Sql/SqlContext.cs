using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Collections;

namespace BorrowNlend.DataSet.DAO.Context.Sql
{
    public class SqlContext : Context
    {

        /// <summary>
        /// 
        /// </summary>
        protected override string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = @"data source=localhost\sqlexpress;initial catalog=BorrowNlend;user id=sa;password=sasa2015;";
                    //connectionString = @"data source=localhost\sqlexpress;initial catalog=BorrowNlend;user id=sa;password=sa2013;";
                }
                return connectionString;
            }
        }

        private static SqlContext instance;
        public static SqlContext Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlContext();
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private SqlContext() 
        {
            try
            {

                DataSet = new System.Data.DataSet();

                // Créer la table Person dans le DataSet
                PersonDataAdapter = CreateSqlDataAdapter(DataSet, "Person");

                // Créer la table Operation dans le DataSet
                OperationDataAdapter = CreateSqlDataAdapter(DataSet, "Operation");

                // Créer la relation Person/Operation dans le DataSet
                DataColumn personIdDataColumn = DataSet.Tables["Person"].Columns["ID"];
                DataColumn operationIdDataColumn = DataSet.Tables["Operation"].Columns["Person_ID"];
                DataRelation personOperationDataRelation = new DataRelation("Person_Operation", personIdDataColumn, operationIdDataColumn);
                DataSet.Relations.Add(personOperationDataRelation);

                // Modifier l'action du contriante DeleteRule à None
                ConstraintCollection constraintCollection = DataSet.Tables["Operation"].Constraints;
                IEnumerator enumerable = constraintCollection.GetEnumerator();
                enumerable.MoveNext();
                ForeignKeyConstraint foreignKeyConstraint = (ForeignKeyConstraint)enumerable.Current;
                foreignKeyConstraint.DeleteRule = Rule.None;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SqlDataAdapter CreateSqlDataAdapter(System.Data.DataSet dataSet, string tableName)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM " + tableName, ConnectionString);
                dataAdapter.Fill(dataSet, tableName);

                DataColumn dataColumn = dataSet.Tables[tableName].Columns["ID"];
                dataColumn.AutoIncrement = true;
                dataColumn.AutoIncrementStep = -1;
                dataColumn.AutoIncrementSeed = 0;

                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
                SqlCommand sqlCommand = sqlCommandBuilder.GetInsertCommand().Clone();
                sqlCommand.CommandText += " SET @Identity = SCOPE_IDENTITY()";
                SqlParameter sqlParameter = new SqlParameter("@Identity", SqlDbType.Int, 0, "ID");
                sqlParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameter);
                dataAdapter.InsertCommand = sqlCommand;
                //dataAdapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
                dataAdapter.RowUpdated += OnRowUpdated;

                return dataAdapter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
        {
            try
            {
                if (args.StatementType == StatementType.Insert)
                {
                    int newID = (int)(args.Command.Parameters["@Identity"].Value);
                    args.Row["ID"] = newID;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

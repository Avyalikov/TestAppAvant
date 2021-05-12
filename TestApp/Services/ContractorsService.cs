using System.Collections.Generic;
using LiteDB;
using TestApp.Data;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Services
{
    public class ContractorsService : IContractorsService
    {
        private LiteDatabase database;
        private string apiKey;

        public ContractorsService(ITestAppContext context)
        {
            database = context.Database;
            apiKey = context.ApiKey;
        }

        /// <summary>
        /// Get collection Contractors
        /// </summary>
        public IEnumerable<Contractor> FindAll()
        {
            return database.GetCollection<Contractor>("Contractors")
                .FindAll();
        }

        /// <summary>
        /// Private method for getting Contractor by INN
        /// </summary>
        private Contractor FindOne(string inn)
        {
            return database.GetCollection<Contractor>("Contractors").FindOne(x => x.INN.Equals(inn));
        }

        /// <summary>
        /// Checks new contractor through Dadata Api and insert it to DB
        /// </summary>
        public string Insert(Contractor contractor)
        {
            var checkForDuplicate = FindOne(contractor.INN);
            

            if (checkForDuplicate != null)
            {
                return "Такой контрагент уже существует";
            }

            ContractorsChecker checker = new ContractorsChecker(apiKey);
            string result = checker.Suggest(contractor.INN, contractor.KPP);
            if (result == null)
            {
                return "Контрагент с такими реквизитами не найден";
            }
            contractor.Fullname = result;
            database.GetCollection<Contractor>("Contractors").Insert(contractor);
            return "Контрагент успешно сохранён";
        }

        /// <summary>
        /// Method for clean up Contractors collection
        /// </summary>
        public void DropCollection()
        {
            database.DropCollection("Contractors");
        }
    }
}

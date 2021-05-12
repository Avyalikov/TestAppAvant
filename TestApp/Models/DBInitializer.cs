using System.Linq;
using TestApp.Interfaces;

namespace TestApp.Models
{
    public class DBInitializzer
    {
        /// <summary>
        /// Fills empty DB by 3 contractors
        /// </summary>
        public static void Init(IContractorsService contractorsService)
        {
            //contractorsService.DropCollection();
            if (!contractorsService.FindAll().Any())
            {
                contractorsService.Insert(
                    new Contractor
                    {
                        Name = "Contractor1",
                        Type = Contractor.ContractorType.Сompany,
                        KPP = "986523654",
                        INN = "7056235462"
                    });
                contractorsService.Insert(
                    new Contractor
                    {
                        Name = "Contractor2",
                        Type = Contractor.ContractorType.IP,
                        INN = "705623546265"
                    });
                contractorsService.Insert(
                    new Contractor
                    {
                        Name = "Contractor3",
                        Type = Contractor.ContractorType.Сompany,
                        KPP = "972364823",
                        INN = "6352896541"
                    });
            }
        }
    }
}

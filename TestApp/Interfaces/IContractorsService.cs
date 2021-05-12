using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface IContractorsService
    {
        IEnumerable<Contractor> FindAll();
        string Insert(Contractor contractor);
        void DropCollection();
    }
}
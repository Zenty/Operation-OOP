using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Services
{
    public class PlantSortService : IPlantSortService
    {
        public PlantSortService() { }

        public List<Plant> SortByPlantId(List<Plant> list) // Sort by plant Id
        {
            return list.OrderBy(p => p.Id).ToList(); // I use the LINQ method OrderBy to sort my plant list by Id.
        }

        public List<Plant> SortByPlantName(List<Plant> list) // Sort by plant Name
        {
            return list.OrderBy(p => p.Name).ToList(); // I use the LINQ method OrderBy to sort my plant list by Name.
        }

        public List<Plant> SortByPlantAge(List<Plant> list) // Sort by plant Age
        {
            return list.OrderBy(p => p.AgeYears).ToList(); // I use the LINQ method OrderBy to sort my plant list by Age.
        }

        public List<Plant> SortByPlantCareLevel(List<Plant> list) // Sort by plant CareLevel
        {
            return list.OrderBy(p => p.CareLevel).ToList(); // I use the LINQ method OrderBy to sort my plant list by CareLevel.
        }
    }
}

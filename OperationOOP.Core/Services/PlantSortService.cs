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
            throw new NotImplementedException();
        }

        public List<Plant> SortByPlantName(List<Plant> list) // Sort by plant Name
        {
            throw new NotImplementedException();
        }

        public List<Plant> SortByPlantAge(List<Plant> list) // Sort by plant Age
        {
            throw new NotImplementedException();
        }
    }
}

using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface IPlantSortService
    {
        List<Plant> SortByPlantId(List<Plant> list);
        List<Plant> SortByPlantName(List<Plant> list);
        List<Plant> SortByPlantAge(List<Plant> list);
        List<Plant> SortByPlantCareLevel(List<Plant> list);
    }
}

using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Plant> Plants { get; set; }
        List<Bamboo> Bamboos { get; set; }
        List<Bonsai> Bonsais { get; set; }
        List<Lily> Lilies { get; set; }
        List<Lotus> Lotuses { get; set; }

    }

    public class Database : IDatabase
    {
        public List<Plant> Plants { get; set; } = new List<Plant>();
        public List<Bamboo> Bamboos { get; set; } = new List<Bamboo>();
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<Lily> Lilies { get; set; } = new List<Lily>();
        public List<Lotus> Lotuses { get; set; } = new List<Lotus>();
    }
}

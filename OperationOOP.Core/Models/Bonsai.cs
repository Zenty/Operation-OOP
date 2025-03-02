using System.Text.Json.Serialization;

namespace OperationOOP.Core.Models;
public class Bonsai : Plant
{
    public BonsaiStyle Style { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))] // To Show the text in Swagger.
public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

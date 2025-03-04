namespace OperationOOP.Api.Endpoints;
public class CreateLotus : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/plants/lotuses", Handle)
        .WithTags("Lotus EndPoints")
        .WithSummary("Lotus flowers");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        CareLevel CareLevel
        );
    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        // Create a new Lotus
        var lotus = new Lotus();

        lotus.Id = db.Lotuses.Count != 0
            ? db.Lotuses.Max(lotus => lotus.Id) + 1
            : 1;
        lotus.Name = request.Name;
        lotus.Species = request.Species;
        lotus.AgeYears = request.AgeYears;
        lotus.LastWatered = request.LastWatered;
        lotus.LastPruned = request.LastPruned;
        lotus.CareLevel = request.CareLevel;

        db.Lotuses.Add(lotus);

        // Create a new Plant (Lotus)
        var plant = new Lotus();

        plant.Id = db.Plants.Count != 0
            ? db.Plants.Max(plant => plant.Id) + 1
            : 1;
        plant.Name = request.Name;
        plant.Species = request.Species;
        plant.AgeYears = request.AgeYears;
        plant.LastWatered = request.LastWatered;
        plant.LastPruned = request.LastPruned;
        plant.CareLevel = request.CareLevel;

        db.Plants.Add(plant);

        return TypedResults.Ok(new Response(lotus.Id));
    }
}


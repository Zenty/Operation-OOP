namespace OperationOOP.Api.Endpoints;
public class CreateBamboo : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/plants/bamboos", Handle)
        .WithSummary("Bamboo trees");

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
        // Create a new Bamboo
        var bamboo = new Bamboo();

        bamboo.Id = db.Bamboos.Count != 0
            ? db.Bamboos.Max(bamboo => bamboo.Id) + 1
            : 1;
        bamboo.Name = request.Name;
        bamboo.Species = request.Species;
        bamboo.AgeYears = request.AgeYears;
        bamboo.LastWatered = request.LastWatered;
        bamboo.LastPruned = request.LastPruned;
        bamboo.CareLevel = request.CareLevel;

        db.Bamboos.Add(bamboo);

        // Create a new Plant (Bamboo)
        var plant = new Bamboo();

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

        return TypedResults.Ok(new Response(bamboo.Id));
    }
}


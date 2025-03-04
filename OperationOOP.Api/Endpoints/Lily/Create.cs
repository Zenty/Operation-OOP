namespace OperationOOP.Api.Endpoints;
public class CreateLily : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/plants/lilies", Handle)
        .WithTags("Lily EndPoints")
        .WithSummary("Lily flowers");

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
        // Create a new Lily
        var lily = new Lily();

        lily.Id = db.Lilies.Count != 0
            ? db.Lilies.Max(lily => lily.Id) + 1
            : 1;
        lily.Name = request.Name;
        lily.Species = request.Species;
        lily.AgeYears = request.AgeYears;
        lily.LastWatered = request.LastWatered;
        lily.LastPruned = request.LastPruned;
        lily.CareLevel = request.CareLevel;

        db.Lilies.Add(lily);

        // Create a new Plant (Lily)
        var plant = new Lily();

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

        return TypedResults.Ok(new Response(lily.Id));
    }
}


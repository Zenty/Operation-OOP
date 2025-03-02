namespace OperationOOP.Api.Endpoints;
public class CreateLily : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/lilies", Handle)
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
        db.Plants.Add(lily);

        return TypedResults.Ok(new Response(lily.Id));
    }
}


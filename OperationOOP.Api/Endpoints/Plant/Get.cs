namespace OperationOOP.Api.Endpoints;
public class GetPlant : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/plants/{id}", Handle)
        .WithSummary("Plants");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        CareLevel CareLevel
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var plant = db.Plants.Find(plant => plant.Id == request.Id);

        // map plant to response dto
        var response = new Response(
            Id: plant.Id,
            Name: plant.Name,
            Species: plant.Species,
            AgeYears: plant.AgeYears,
            LastWatered: plant.LastWatered,
            LastPruned: plant.LastPruned,
            CareLevel: plant.CareLevel
            );

        return response;
    }
}
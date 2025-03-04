namespace OperationOOP.Api.Endpoints;
public class GetLily : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/plants/lilies/{id}", Handle)
        .WithTags("Lily EndPoints")
        .WithSummary("Lily flowers");

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
        var lily = db.Lilies.Find(lily => lily.Id == request.Id);

        // map lily to response dto
        var response = new Response(
            Id: lily.Id,
            Name: lily.Name,
            Species: lily.Species,
            AgeYears: lily.AgeYears,
            LastWatered: lily.LastWatered,
            LastPruned: lily.LastPruned,
            CareLevel: lily.CareLevel
            );

        return response;
    }
}
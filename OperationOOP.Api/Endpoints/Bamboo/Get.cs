namespace OperationOOP.Api.Endpoints;
public class GetBamboo : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/plants/bamboos/{id}", Handle)
        .WithTags("Bamboo EndPoints")
        .WithSummary("Bamboo trees");

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
        var bamboo = db.Bamboos.Find(bamboo => bamboo.Id == request.Id);

        // map bamboo to response dto
        var response = new Response(
            Id: bamboo.Id,
            Name: bamboo.Name,
            Species: bamboo.Species,
            AgeYears: bamboo.AgeYears,
            LastWatered: bamboo.LastWatered,
            LastPruned: bamboo.LastPruned,
            CareLevel: bamboo.CareLevel
            );

        return response;
    }
}
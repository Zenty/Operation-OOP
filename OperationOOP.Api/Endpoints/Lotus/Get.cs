namespace OperationOOP.Api.Endpoints;
public class GetLotus : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/plants/lotuses/{id}", Handle)
        .WithTags("Lotus EndPoints")
        .WithSummary("Lotus flowers");

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
        var lotus = db.Lotuses.Find(lotus => lotus.Id == request.Id);

        // map lotus to response dto
        var response = new Response(
            Id: lotus.Id,
            Name: lotus.Name,
            Species: lotus.Species,
            AgeYears: lotus.AgeYears,
            LastWatered: lotus.LastWatered,
            LastPruned: lotus.LastPruned,
            CareLevel: lotus.CareLevel
            );

        return response;
    }
}
namespace OperationOOP.Api.Endpoints;
public class GetAllLotuses : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lotuses", Handle)
        .WithSummary("Lotus flowers");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.Lotuses
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned
            )).ToList();
    }
}
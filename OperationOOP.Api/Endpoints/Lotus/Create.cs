namespace OperationOOP.Api.Endpoints;
public class CreateLotus : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/lotuses", Handle)
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
        db.Plants.Add(lotus);

        return TypedResults.Ok(new Response(lotus.Id));
    }
}


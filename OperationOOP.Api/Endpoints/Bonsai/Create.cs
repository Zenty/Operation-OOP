namespace OperationOOP.Api.Endpoints;
public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/plants/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
        );
    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        // Create a new Bonsai
        var bonsai = new Bonsai();

        bonsai.Id = db.Bonsais.Count != 0
            ? db.Bonsais.Max(bonsai => bonsai.Id) + 1
            : 1;
        bonsai.Name = request.Name;
        bonsai.Species = request.Species;
        bonsai.AgeYears = request.AgeYears;
        bonsai.LastWatered = request.LastWatered;
        bonsai.LastPruned = request.LastPruned;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        db.Bonsais.Add(bonsai);

        // Create a new Plant (Bonsai)
        var plant = new Bonsai();

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

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}


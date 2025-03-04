﻿namespace OperationOOP.Api.Endpoints;

public class GetSortedByName: IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/plants/sort/name", Handle)
        .WithTags("Plant Sort EndPoints")
        .WithSummary("Plants sorted by Name");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        CareLevel CareLevel
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return [.. db.Plants
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                Species: item.Species,
                AgeYears: item.AgeYears,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned,
                CareLevel: item.CareLevel
            ))
            .OrderBy(p => p.Name)];
    }
}
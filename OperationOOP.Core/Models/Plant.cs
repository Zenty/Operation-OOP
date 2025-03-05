﻿using System.Text.Json.Serialization;

namespace OperationOOP.Core.Models;

public class Plant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public CareLevel CareLevel { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))] // To Show the text in Swagger.
public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master
}
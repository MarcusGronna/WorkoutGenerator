using WorkoutGenerator.Core;
using System;
using System.IO;
using System.Text.Json;

string filePath = PathHelper.DataFile("exercises.json");
Console.WriteLine($"Full path to data file:\n{filePath}");


string content = File.ReadAllText(filePath);
using JsonDocument doc = JsonDocument.Parse(content);
string prettyJson = JsonSerializer.Serialize(
    doc.RootElement,
    new JsonSerializerOptions { WriteIndented = true }
);

Console.WriteLine("=== FORMATTED JSON ===\n");
Console.WriteLine(prettyJson);
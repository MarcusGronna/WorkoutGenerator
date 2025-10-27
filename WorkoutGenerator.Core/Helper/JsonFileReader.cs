using System.Text.Json;

namespace WorkoutGenerator.Core;

public static class JsonFileReader
{
    public static List<Exercise> ReadExercises(string filePath)
    {
        if (!File.Exists(filePath)) { throw new FileNotFoundException($"File not found: {filePath}"); }

        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<List<Exercise>>(json, options);
    }
}
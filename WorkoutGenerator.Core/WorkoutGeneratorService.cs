namespace WorkoutGenerator.Core;

public class WorkoutGeneratorService(string filePath)
{
    private readonly string _filePath = filePath;

    public Workout BuildWorkout(string muscleGroup, GoalType goalType, int count = 4)
    {
        var allExercises = JsonFileReader.ReadExercises(_filePath);

        var filtered = allExercises
            .Where(e => e.MuscleGroup.Equals(muscleGroup))
            .Take(count)
            .ToList();

        var workout = WorkoutFactory.GenerateWorkout(filtered, muscleGroup, goalType);

        return workout;
    }

    public List<string> GetAvailableMuscleGroups()
    {
        var all = JsonFileReader.ReadExercises(_filePath);
        return all
            .Select(e => e.MuscleGroup)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}
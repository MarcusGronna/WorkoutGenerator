using WorkoutGenerator.Core;

namespace WorkoutGenerator.Tests;

public class WorkoutFactoryTests
{
    [Fact]
    public void GenerateWorkout_ReturnsExpectedNumberOfExercises()
    {
        // Arrange
        var mockExercises = new List<Exercise>
        {
            new Exercise { Name = "Push-Up", MuscleGroup = "UpperBody", Difficulty = "Easy" },
            new Exercise { Name = "Squat", MuscleGroup = "LowerBody", Difficulty = "Easy" }
        };

        var factory = new WorkoutFactory();

        // Act
        var workout = factory.CreateWorkout(mockExercises, "UpperBody", 1);

        // Assert
        Assert.Single(workout.Exercises);

    }
}
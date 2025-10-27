using Xunit;
using WorkoutGenerator.Core;

namespace WorkoutGenerator.Tests;

public class WorkoutFactoryTests
{
    // [Fact]
    // public void CreateFactory_ReturnsFactoryÓbject()
    // {
    //     // Act 
    //     var factory = new WorkoutFactory();

    //     // Assert
    //     Assert.NotNull(factory);
    // }

    // [Fact]
    // public void CreateWorkout_ReturnsWorkoutInstance()
    // {
    //     // Arrange
    //     var exercises = new List<Exercise>
    //     {
    //         new Exercise { Name = "Push-Up", MuscleGroup = "UpperBody", Difficulty = "Beginner" }
    //     };

    //     var factory = new WorkoutFactory();

    //     // Act
    //     var result = factory.CreateWorkout(exercises, "UpperBody", "Styrka");

    //     // Assert
    //     Assert.NotNull(result);
    //     Assert.IsType<Workout>(result);
    // }

    // [Fact]
    // public void GenerateWorkout_ReturnsExpectedNumberOfExercises()
    // {
    //     // Arrange
    //     var mockExercises = new List<Exercise>
    //     {
    //         new Exercise { Name = "Push-Up", MuscleGroup = "UpperBody", Difficulty = "Easy" },
    //         new Exercise { Name = "Squat", MuscleGroup = "LowerBody", Difficulty = "Easy" }
    //     };

    //     var factory = new WorkoutFactory();

    //     // Act
    //     var workout = factory.CreateWorkout(mockExercises, "UpperBody", "Hypertrophy");

    //     // Assert
    //     Assert.Single(workout.Exercises);
    // }
}
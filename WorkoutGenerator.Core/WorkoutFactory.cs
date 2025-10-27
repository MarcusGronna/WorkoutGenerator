namespace WorkoutGenerator.Core;

public class WorkoutFactory
{
    public Workout GenerateWorkout(List<Exercise> exercises, string muscleGroup, GoalType goalType)
    {
        var workout = Workout.Create(exercises, muscleGroup, goalType);

        switch (goalType)
        {
            case GoalType.Strength:
                workout.Repetitions = 6;
                break;
            case GoalType.Hypertrophy:
                workout.Repetitions = 15;
                break;
            default:
                workout.Repetitions = 10;
                break;
        }

        return workout;
    }
}

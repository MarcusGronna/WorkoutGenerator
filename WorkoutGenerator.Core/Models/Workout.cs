namespace WorkoutGenerator.Core;

public class Workout
{
    public List<Exercise> Exercises { get; set; }
    public string MuscleGroup { get; set; }
    public GoalType GoalType { get; set; }
    public int Repetitions { get; set; } = 0;

    private Workout() { }

    public static Workout Create(List<Exercise> exercises, string muscleGroup, GoalType goalType)
    {
        var w = new Workout();

        w.Exercises = exercises;
        w.MuscleGroup = muscleGroup;
        w.GoalType = goalType;

        return w;
    }
}
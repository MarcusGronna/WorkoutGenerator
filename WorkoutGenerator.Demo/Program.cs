using WorkoutGenerator.Core;
using System;
using System.IO;

Console.Title = "Workout Generator";
string filePath = Path.Combine(AppContext.BaseDirectory, "data", "exercises.json");
var service = new WorkoutGeneratorService(filePath);

// === 1. Muscle group selection ===
var muscleGroups = service.GetAvailableMuscleGroups();
int selectedIndex = 0;
ConsoleKey key;

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("=== WORKOUT GENERATOR ===\n");
    Console.ResetColor();

    Console.WriteLine("Select muscle group (use ↑ / ↓ and press Enter):\n");


    for (int i = 0; i < muscleGroups.Count; i++)
    {
        if (i == selectedIndex)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine($"> {muscleGroups[i]}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"  {muscleGroups[i]}");
        }
    }

    key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.UpArrow && selectedIndex > 0) selectedIndex--;
    else if (key == ConsoleKey.DownArrow && selectedIndex < muscleGroups.Count - 1) selectedIndex++;

} while (key != ConsoleKey.Enter);

string selectedGroup = muscleGroups[selectedIndex];

// === 2. Goal type selection ===
var goalOptions = new[] { GoalType.Strength, GoalType.Hypertrophy };
int goalIndex = 0;

do
{
    Console.Clear();
    Console.WriteLine($"Selected group: {selectedGroup}\n");
    Console.WriteLine("Select goal type (use ↑ / ↓ and press Enter):\n");

    for (int i = 0; i < goalOptions.Length; i++)
    {
        if (i == goalIndex)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine($"> {goalOptions[i]}");
            Console.ResetColor();

        }
        else
        {
            System.Console.WriteLine($"  {goalOptions[i]}");
        }
    }

    key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.UpArrow && goalIndex > 0) goalIndex--;
    else if (key == ConsoleKey.DownArrow && goalIndex < goalOptions.Length - 1) goalIndex++;
} while (key != ConsoleKey.Enter);

GoalType selectedGoal = goalOptions[goalIndex];

// === 3. Number of exercises ===
Console.Clear();
Console.WriteLine($"Selected: {selectedGroup} ({selectedGoal})");
Console.Write("\nHow many exercises? ");
int.TryParse(Console.ReadLine(), out int count);
if (count <= 0) count = 4;

// === 4. Generate workout ===
var workout = service.BuildWorkout(selectedGroup, selectedGoal, count);

// === 5. Display in table ===
Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("=== GENERATED WORKOUT ===\n");
Console.ResetColor();

Console.WriteLine($"Muscle Group : {workout.MuscleGroup}");
Console.WriteLine($"Goal Type    : {workout.GoalType}");
Console.WriteLine($"Repetitions  : {workout.Repetitions}\n");

PrintTable(workout.Exercises);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nWorkout successfully generated!");
Console.ResetColor();


static void PrintTable(List<Exercise> exercises)
{
    int col1 = Math.Max("Exercise".Length, exercises.Max(e => e.Name.Length)) + 2;
    int col2 = 12;
    int col3 = 14;
    int col4 = 16;

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{Pad("Exercise", col1)}{Pad("Muscle", col2)}{Pad("Equipment", col3)}{Pad("Difficulty", col4)}");
    Console.ResetColor();

    Console.WriteLine(new string('-', col1 + col2 + col3 + col4));

    foreach (var e in exercises)
    {
        Console.WriteLine($"{Pad(e.Name, col1)}{Pad(e.MuscleGroup, col2)}{Pad(e.Equipment, col3)}{Pad(e.Difficulty, col4)}");
    }
}

static string Pad(string text, int width) => text.Length >= width ? text[..(width - 1)] + "..." : text.PadRight(width);

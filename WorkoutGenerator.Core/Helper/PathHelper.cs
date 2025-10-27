namespace WorkoutGenerator.Core;

public static class PathHelper
{
    public static string BaseDir => AppContext.BaseDirectory;
    public static string DataDir => Path.Combine(BaseDir, "data");
    public static string DataFile(string fileName) => Path.Combine(DataDir, fileName);
}
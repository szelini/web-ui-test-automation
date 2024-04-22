namespace TestAutomationFramework.Core.Utilities
{
    public class FolderMaintainer
    {
        public static void PreviousFileClener(string filepath, string filename)
        {
            if (File.Exists(Path.Combine(filepath, filename)))
            {
                File.Delete(Path.Combine(filepath, filename));
            }
        }

        public static void DirectoryCreator(string filepath)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
        }
    }
}

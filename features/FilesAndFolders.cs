public class FilesAndFolders
{
    // get the application directory path and remove the bin\Debug\net10.0\ part
    private static readonly string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\net10.0\", "");
    private static readonly string DATA_DIRECTORY = Path.Combine(BASE_DIRECTORY, "data");
    private static readonly string LOGS_DIRECTORY = Path.Combine(BASE_DIRECTORY, "logs");

    // method to create log directory and files each time app starts
    private static void LogAppStart()
    {
        try
        {
            Directory.CreateDirectory(LOGS_DIRECTORY);
            int count = Directory.EnumerateFiles(LOGS_DIRECTORY).Count();
            count = count == 0 ? 1 : count + 1;
            string time = $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss-tt}";
            string logFile = Path.Combine(LOGS_DIRECTORY, $"app-start-{time}.log");
            string content = $"{Guid.NewGuid()} App started at {time} - for #{count}\n";
            File.WriteAllText(logFile, content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to read and display files info in the data directory
    // using directory.EnumerateFiles() and LINQ query syntax
    public static void ListFilesInfoInDataDirectory()
    {
        LogAppStart();
        try
        {
            string[] files = [..
                from file in Directory.EnumerateFiles(DATA_DIRECTORY)
                let fileInfo = new FileInfo(file)
                let fileName = fileInfo.FullName[(DATA_DIRECTORY.Length+1)..]
                let fileSize = fileInfo.Length / 1024
                let createdAt = fileInfo.LastWriteTime
                orderby fileInfo.LastWriteTime descending
                select $"({fileName})\t\t({fileSize}KB)\t\t({createdAt})"
            ];
            Console.WriteLine("---------------------");
            Console.WriteLine("Files in the data directory");
            Console.WriteLine("---------------------");
            Console.WriteLine($"files count: {files.Length}");
            Console.WriteLine("---------------------");
            foreach (var fileInfo in files)
                Console.WriteLine(fileInfo);
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}

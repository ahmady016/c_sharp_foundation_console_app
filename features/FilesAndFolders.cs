public class FilesAndFolders
{
    // get the application directory path and remove the bin\Debug\net10.0\ part
    public static readonly string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\net10.0\", "");

    // method to read and display files info in the data directory
    // using directory.EnumerateFiles() and LINQ query syntax
    public static void ListFilesInfoInDataDirectory()
    {
        try
        {
            string dataDirectory = Path.Combine(BASE_DIRECTORY, "data");
            string[] files = [..
                from file in Directory.EnumerateFiles(dataDirectory)
                let fileInfo = new FileInfo(file)
                let fileName = fileInfo.FullName[(dataDirectory.Length+1)..]
                let fileSize = fileInfo.Length / 1024
                let createdAt = fileInfo.LastWriteTime
                orderby fileInfo.LastWriteTime descending
                select $"({fileName}) - ({fileSize}KB) - ({createdAt})"
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

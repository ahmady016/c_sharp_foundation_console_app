public class FilesAndFolders
{
    // get the application directory path and remove the bin\Debug\net10.0\ part
    private static readonly string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\net10.0\", "");
    private static readonly string DATA_DIRECTORY = Path.Combine(BASE_DIRECTORY, "data");
    private static readonly string LOGS_DIRECTORY = Path.Combine(BASE_DIRECTORY, "logs");
    private static readonly string ARCHIVE_DIRECTORY = Path.Combine(BASE_DIRECTORY, "archive");

    // method to create log directory and files each time app starts
    public static void LogAppStart()
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

    // method to copy, move files
    // accept the source path and the destination path
    // and the copy or move operation type as input
    private static void CopyOrMoveFiles(
        string srcPath,
        string destPath,
        string operationType = "copy"
    )
    {
        try
        {
            File.Copy(srcPath, destPath, overwrite: true);
            if(operationType == "move")
                File.Delete(srcPath);
            string operation = operationType == "copy" ? "copied" : "moved";
            string srcPathName = srcPath[BASE_DIRECTORY.Length..];
            string destPathName = destPath[BASE_DIRECTORY.Length..];
            Console.WriteLine($"{srcPathName} has been {operation} to {destPathName} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to demonstrate copy and move files
    public static void CopyAndMoveFiles()
    {
        string srcFileName, operationType, srcPath, destPath, userResponse;
        try
        {
            do
            {
                // get the source file name with extension from user
                Console.Write("Enter the source file name with extension: ");
                srcFileName = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(srcFileName))
                    throw new ArgumentNullException("you must enter the source file name with extension");

                // get the operation type from user
                Console.Write("Enter the operation type (copy or move): ");
                operationType = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(operationType))
                    throw new ArgumentNullException("you must enter the operation type");
                if (operationType != "copy" && operationType != "move")
                    throw new ArgumentException("invalid operation type");

                // copy programming_roadmap.txt file from data directory to archive directory
                srcPath = Path.Combine(DATA_DIRECTORY, srcFileName);
                destPath = Path.Combine(ARCHIVE_DIRECTORY, srcFileName);
                CopyOrMoveFiles(srcPath, destPath, operationType);

                // get user response to continue or quit
                Console.Write("Press Enter to quit or any other key to continue: ");
                userResponse = Console.ReadLine() ?? string.Empty;
            } while (userResponse != string.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to rename a file
    // accept the file name and the new file name
    // simply move the file to the same directory but with a new name
    private static void RenameFile(string filePath, string newFileName)
    {
        if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(newFileName))
            throw new ArgumentException("you must enter the file path and the new file name");
        if (!File.Exists(filePath))
            throw new ArgumentException("the file does not exist");
        try
        {
            string directory = Path.GetDirectoryName(filePath) ?? DATA_DIRECTORY;
            string newFilePath = Path.Combine(directory, newFileName);
            File.Move(filePath, newFilePath);
            Console.WriteLine($"{Path.GetFileName(filePath)} has been renamed to {Path.GetFileName(newFilePath)} successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to renaming all files in the data directory
    // to convert file names to lower case and replace spaces or dashes with underscores
    // using LINQ query syntax
    public static void RenameFilesInDataDirectory()
    {
        try
        {
            List<FileInfo> files = [..
                from file in Directory.EnumerateFiles(DATA_DIRECTORY)
                select new FileInfo(file)
            ];
            Console.WriteLine("---------------------");
            Console.WriteLine("Renaming All Files in the data directory");
            Console.WriteLine("---------------------");
            Console.WriteLine($"files count: {files.Count}");
            Console.WriteLine("---------------------");
            foreach (var fileInfo in files)
            {
                string newFileName = fileInfo.Name.ToLower().Replace(" ", "_").Replace("-", "_");
                RenameFile(fileInfo.FullName, newFileName);
            }
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to create new log file with the given content
    // accept content and the log file name is generated automatically
    private static void LogToFile(string content)
    {
        try
        {
            string time = $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss-tt}";
            string logFile = Path.Combine(LOGS_DIRECTORY, $"file-changed-{time}.log");
            File.WriteAllText(logFile, content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    // method to watch the data folder for new files
    public static void WatchDataDirectory()
    {
        try
        {
            // create a file system watcher
            using var watcher = new FileSystemWatcher(DATA_DIRECTORY, "*.*");
            // configure the file system watcher
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.CreationTime;
            watcher.EnableRaisingEvents = true;
            // create the file system watcher handler
            static void watcher_handler(object? sender, FileSystemEventArgs e)
            {
                string content = $"({Path.GetFileName(e.FullPath)}) file {e.ChangeType} at {DateTime.Now:yyyy-mm-dd hh:mm:ss tt}";
                Console.WriteLine(content);
                LogToFile(content);
            }
            // register the file system watcher handler to watcher events
            watcher.Created += watcher_handler;
            watcher.Renamed += watcher_handler;
            watcher.Changed += watcher_handler;
            watcher.Deleted += watcher_handler;
            // hold the application
            Console.WriteLine("---------------------");
            Console.WriteLine("Watching Data Directory for Files Changes");
            Console.WriteLine("---------------------");
            Console.WriteLine("Press Any Key to Exit");
            Console.WriteLine("---------------------");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to read data from text file
    // accept the file path and return the file content as list of string line by line
    private static List<string> ReadLinesFromTextFile(string filePath)
    {
        if(string.IsNullOrEmpty(filePath))
            throw new ArgumentException("you must enter the file path");
        if (!File.Exists(filePath))
            throw new ArgumentException("the file does not exist");

        string line;
        List<string> lines = [];
        using var reader = new StreamReader(filePath);
        while(!reader.EndOfStream)
        {
            line = reader.ReadLine()?.Trim() ?? string.Empty;
            if(!string.IsNullOrEmpty(line) )
                lines.Add(line);
        }

        return lines;
    }

    // method to write data to text file that accept the file path
    // if the file path does not exist, create it and write the data to it
    // if the file path exists, append the data to it
    // the content is a list of lines
    private static void WriteLinesToTextFile(string filePath, List<string> content)
    {
        if(string.IsNullOrEmpty(filePath))
            throw new ArgumentException("you must enter the file path");
        if(content.Count == 0)
            throw new ArgumentException("you must enter the file content");

        if (!File.Exists(filePath))
            File.Create(filePath).Close();

        using var writer = new StreamWriter(filePath, append: true);
        foreach (string line in content)
            writer.WriteLine(line);
        Console.WriteLine($"The given content has been written to {Path.GetFileName(filePath)} successfully.");
    }

    // method to demonstrate reading and writing to a text file
    // collect the file name from the user and combine it with the data directory path
    // ask the user to enter the operation type (read or write)
    // if the operation type is read, read the file content and print it to the console
    // if the operation type is write,
    // loop to collect the file content from the user line by line until the user enters an empty line
    // and finally write the file content to the file
    public static void ReadOrWriteToTextFile()
    {
        string filePath, fileName, operationType, lineInput, userResponse;
        List<string> lines = [];
        try
        {
            do
            {
                // get the file name with extension from user
                Console.Write("Enter the file name with extension: ");
                fileName = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(fileName))
                    throw new ArgumentNullException("you must enter the file name with extension");

                // get the operation type from user
                Console.Write("Enter the operation type (read or write): ");
                operationType = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(operationType))
                    throw new ArgumentNullException("you must enter the operation type");
                if (operationType != "read" && operationType != "write")
                    throw new ArgumentException("invalid operation type");

                // combine the file name with the data directory path
                filePath = Path.Combine(DATA_DIRECTORY, fileName);

                switch(operationType)
                {
                    // read the file content and print it to the console
                    case "read":
                        lines = ReadLinesFromTextFile(filePath);
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Reading ({Path.GetFileName(filePath)}) Content:");
                        Console.WriteLine("---------------------");
                        foreach (string line in lines)
                            Console.WriteLine(line);
                        break;
                    // loop to collect the file content from the user line by line until the user enters an empty line
                    case "write":
                        do
                        {
                            Console.Write("Enter a line (press Enter to stop): ");
                            lineInput = Console.ReadLine()?.Trim() ?? string.Empty;
                            if (!string.IsNullOrEmpty(lineInput))
                                lines.Add(lineInput);
                        } while (lineInput != string.Empty);
                        WriteLinesToTextFile(filePath, lines);
                        break;
                }
                Console.Write("Do you want to continue? (y/n): ");
                userResponse = Console.ReadLine()?.Trim() ?? string.Empty;
            } while (userResponse != "n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}

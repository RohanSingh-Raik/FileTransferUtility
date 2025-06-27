
string host = "ftp://127.0.0.1";
string username = "FTPTest";
string password = "test";
string localFolderPath = @"C:\Users\RohanSingh\Desktop\FDA forms";
string remoteFolderPath = "/OUTFOLDER";

try
{
    using (var ftpService = new FTPService(host, username, password))
    {
        ftpService.UploadFiles(localFolderPath, remoteFolderPath);
        Console.WriteLine("Files uploaded successfully.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred during FTP upload:");
    Console.WriteLine(ex.Message);
}

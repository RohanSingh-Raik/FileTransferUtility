

string host = "ftp.example.com";
string username = "your-ftp-username";
string password = "your-ftp-password";
string localFolderPath = @"C:\MyLocalFiles";
string remoteFolderPath = "/remote/target/folder";

try
{
    using (var ftpService = new FTPService(host, username, password))
    {
        ftpService.UploadFiles(localFolderPath, remoteFolderPath);
        Console.WriteLine("Files uploaded successfully.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred during FTP upload:");
    Console.WriteLine(ex.Message);
}

using FluentFTP;

public class FTPService : IDisposable
{
    private readonly FtpClient? _ftpClient;
    private bool disposedValue;

    public FTPService(string Host, string UserName, string Password)
    {
        try
        {
            _ftpClient = new FtpClient(Host, UserName, Password);
            _ftpClient.Connect();
            Console.WriteLine("FTP Client connected successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

   

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _ftpClient?.Disconnect();
                _ftpClient?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void UploadFiles(string inputFolderPath, string targetFolderPath)
    {
        try
        {
            foreach (string filePath in Directory.GetFiles(inputFolderPath))
            {
                string fileName = Path.GetFileName(filePath);
                string targetPath = Path.Combine(targetFolderPath, fileName).Replace("\\", "/");
                Console.WriteLine($"Uploading: {fileName}");

                _ftpClient?.UploadFile(filePath, targetPath);

                Console.WriteLine($"Uploaded: {fileName}");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
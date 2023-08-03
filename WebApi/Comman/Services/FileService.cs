namespace WebApi.Comman.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string?> SaveFile(IFormFile file)
    {
        if (file.Length <= 0 || file is null) return null;

        var fileNime = Guid.NewGuid() + file.FileName;
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileNime);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return fileNime;
    }
}

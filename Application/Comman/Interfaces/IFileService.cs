using Microsoft.AspNetCore.Http;

namespace Application.Comman.Interfaces;

public interface IFileService
{
    public Task<string?> SaveFile(IFormFile file);
}

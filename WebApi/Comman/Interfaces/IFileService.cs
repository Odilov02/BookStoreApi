﻿namespace WebApi.Comman.Interfaces
{
    public interface IFileService
    {
        public Task<string?> SaveFile(IFormFile file);
    }
}

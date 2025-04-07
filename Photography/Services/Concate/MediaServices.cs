using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Photography.Databases;
using Photography.Models;
using Photography.Services.Abstract;

namespace Photography.Services.Concate
{
    public class MediaServices : IMediaServies
    {
        private readonly AppDbContext _appDbContext;
        public MediaServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
    }
}

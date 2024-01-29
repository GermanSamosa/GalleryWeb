using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebGallery.Models;

namespace WebGallery.Data
{
    public class WebGalleryContext : DbContext
    {
        public WebGalleryContext (DbContextOptions<WebGalleryContext> options)
            : base(options)
        {
        }

        public DbSet<WebGallery.Models.Piece> Piece { get; set; } = default!;
    }
}

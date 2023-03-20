﻿using Microsoft.EntityFrameworkCore;
using ZikaZika.Shared.Models;

namespace ZikaZika.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
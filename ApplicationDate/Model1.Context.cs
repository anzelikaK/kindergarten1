﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kindergarten.ApplicationDate
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kindergartenEntities : DbContext
    {
        private static kindergartenEntities _context;
        public static kindergartenEntities GetContext()
        {
            if (_context == null)
                _context = new kindergartenEntities();
            return _context;
        }
        public kindergartenEntities()
            : base("name=kindergartenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Child> Child { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<MedicalCard> MedicalCard { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vaccination> Vaccination { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
    }
}

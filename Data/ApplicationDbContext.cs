//adding support package for basic c# entities
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//adding support for entity frame
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//adding support for export class in this case Message data model class.
using MessageApp.Data;

namespace MessageApp.Data{
    public class ApplicationDbContext : DbContext{
        
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options){}
        #endregion Constructor

        #region Methods
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>().ToTable("Message"); //set table name to message 
            modelBuilder.Entity<Message>().Property(i => i.Id).ValueGeneratedOnAdd(); // set auto-generate Id value

            //no other relationship are present
        }
        #endregion Methods

        #region Properties
        //get and set messages.
        public DbSet<Message> Messages {get; set;}

        #endregion Properties
    }
}
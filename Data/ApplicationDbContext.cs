using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Message.Data;

namespace Message.Data{
    public class ApplicationDbContext : DbContext{
        
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options){

        }
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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking; 

namespace MessageApp.Data{
    public static class DbSeeder{

       #region Public methods
        public static void Seed(ApplicationDbContext dbConext){
            //create default messages if there are none
            if(!dbConext.Messages.Any()) CreateMessages(dbConext);
        }
       #endregion Public methods

       #region Seed methods
        private static void CreateMessages(ApplicationDbContext dbConext){
            //local variable
            DateTime createdDate = new DateTime(2014, 03, 01, 12, 30, 00);

            //create 3 sample messages
            #if DEBUG
            int num = 5; //number of automatic messages needed.

            //create a list of 5 messages
            for ( int i = 0; i<=num; i++){
                CreateMessage(dbConext, i, createdDate.AddDays(-i));
            }
            #endif

            //create message 1
            EntityEntry<Message> m1 = dbConext.Messages.Add( new Message{
                Content = "Remember to be the best you can ",
                DateCreated = createdDate,
                Status = 0
            });

            //create message 2
            EntityEntry<Message> m2 = dbConext.Messages.Add(new Message{
                Content = "logic and all of abstraction loves you",
                DateCreated = new DateTime(2015, 02, 02, 12 , 20, 00),
                Status = 0
            });
            dbConext.SaveChanges();
            
        }
       #endregion Seed methods

       #region utility method
       private static void CreateMessage(ApplicationDbContext dbContext, int num, DateTime createdDate){
            //create a sample message
            var message = new Message(){
                Content = "sample message " + num,
                DateCreated = createdDate,
                Status = 0
            };
            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
        }
       #endregion utility method
    }
}
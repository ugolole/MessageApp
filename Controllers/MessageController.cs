//adding support basic C# class and objects like list and linq
using System;
using System.Linq;
using System.Collections.Generic;

//adding packages for MVC support like controllers and Json support
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//adding packags for previously created class like viewmodle and data model
using MessageApp.ViewModels;
using MessageApp.Data;

//adding support to allow sending of Json object to client side
using Mapster;

namespace MessageApp.Controllers{

    [Route("api/[controller]")]
    public class MessageController : Controller{
        
        #region Private fields
        private ApplicationDbContext DbContext;
        #endregion Private fields


        #region Constructor
        //constructor that instantiats application DbContext class.
        public MessageController(ApplicationDbContext context){
            //instantiate applicationDbContext through DI
            DbContext = context;
        }
        #endregion Constructor


        #region RESTful methods
        //get a single message based on the id of the message.
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            //get the values from the database
            var message = DbContext.Messages.Where(i => i.Id == id).FirstOrDefault();

            //send the values to the client side as json object.
            return new JsonResult(message.Adapt<MessageViewModel>(), new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            });
        }

        //get a list of all message arranged by order of data created.
        [HttpGet("All")]
        public IActionResult all(){
            //get the values from the database.
            var latest = DbContext.Messages
                .OrderBy(m => m.DateCreated)
                .ToArray();
            //send the values to the cleint side.
            return new JsonResult(latest.Adapt<MessageViewModel[]>(), new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            });
        }

        //add a new message to the application server side
        [HttpPut]
        public IActionResult Put([FromBody]MessageViewModel model){
            //return a generic HTTP status 500 (server error )
            //if the pay load is invalid
            if(model == null ) return new StatusCodeResult(500);

            //mapping the message to the model
            var message = model.Adapt<Message>();

            //set data received from model into the mapped variable
            model.Content = message.Content;
            model.DateCreated = DateTime.Now;
            model.Status = message.Status;

            //add the mapped variable into the dbContext.
            DbContext.Messages.Add(message);

            //persist the data into the database 
            DbContext.SaveChanges();

            //return the newly add message to the client side 
            return new JsonResult(message.Adapt<MessageViewModel>(), new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            });
        }
        
        //delete a message based on id 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id ){
            
            //get the message to be deleted based on it's id
            var message = DbContext.Messages.Where(i => i.Id == id ).FirstOrDefault();

            //handle request for non existing message.
            if(message == null)
                return NotFound(
                    new {
                        Error = String.Format("Message with Id {0} not found",id)
                    }
                );
            //remove the message from the database.
            DbContext.Messages.Remove(message);

            //save the change to the database instance.
            DbContext.SaveChanges();

            //return ok result.
            return new OkResult();
        }
        #endregion RESTful methods
    }
}
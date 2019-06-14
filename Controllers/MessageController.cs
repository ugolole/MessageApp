//adding support basic C# class and objects like list and linq
using System;
using System.Linq;
using System.Collections.Generic;

//adding packages for MVC support like controllers and Json support
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//adding packags for previously created class like viewmodle and data model
using Message.ViewModels;
using Message.Data;

//adding support to allow sending of Json object to client side
using Mapster;

namespace Message.Controllers{

    [Route("api/[controller]")]
    public class MessageController : Controller{
        
        #region Private fields
        private ApplicationDbContext DbContext;
        #endregion Private fields


        #region Constructor
        public MessageController(ApplicationDbContext context){
            //instantiate applicationDbContext through DI
            DbContext = context;
        }
        #endregion Constructor


        #region RESTful methods
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var message = DbContext.Messages.Where(i => i.Id == id).FirstOrDefault();

            return new JsonResult(message.Adapt<MessageViewModel>(), new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            });
        }
        #endregion RESTful methods
    }
}
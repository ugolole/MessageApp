using System;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MessageApp.ViewModels{
    public class MessageViewModel{

    #region constructor
    public MessageViewModel(){}
    #endregion constructor

    #region properties
        //Id for current message view
        public int Id{get; set;}
        
        
        //Message storeed 
        public string Content {get; set;}
        
        
        //Date created for current message
        public DateTime DateCreated{get; set;}


        //status of the message 
        [DefaultValue(0)]
        public int status {get; set;}
    #endregion properties
    }
}
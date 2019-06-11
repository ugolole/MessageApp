using System;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Message.ViewModels{
    public class MessageViewModel{

    #region constructor
    public MessageViewModel(){}
    #endregion constructor

    #region properties
        //Id for current message view
        public int Id{get; set;}

        //Date created for current message
        public DateTime DateCreated{get; set;}

        //Message storeed 
        public string Message {get; set;}

        //status of the message 
        public int status {get; set;}

    #endregion properties
    }
}
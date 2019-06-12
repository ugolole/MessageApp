using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Message.Data{
    public class Message{

        #region Constructor
        public Message(){}
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public string Content{get; set;}

        [Required]
        public DateTime DateCreated{get; set;}

        [Required]
        public int Status {get; set;}

        #endregion Properties

        //no lazy load properties required for the moment 
        //because no sub-section of the database table exist.
    }
}
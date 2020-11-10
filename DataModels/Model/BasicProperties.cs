using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model
{
    public class BasicProperties
    {
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifieBy { get; set; }
    }
}

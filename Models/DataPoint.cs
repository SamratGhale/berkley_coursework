using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
namespace berkeley_college.Models
{
    public class DataPoint
    {
        //Explicitly setting the name to be used while serializing to JSON.
        public double X { get; set; }

        //Explicitly setting the name to be used while serializing to JSON.
        public string Y { get; set;  }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Reservation
    {
        public int Rsid { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
    }
    public class JsonClass
    {
        public int code { get; set; }
        public int dmsg { get; set; }
       // public List<Reservation> list { get; set; }

    }
    public class JsonClass2
    {
        public int code { get; set; }
        public int dmsg { get; set; }
        public Hashtable list { get; set; }

    }



}
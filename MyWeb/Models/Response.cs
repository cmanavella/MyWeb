using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Response
    {
        public bool Valida { get; set; }
        public object Modelo { get; set; }
        public String Error { get; set; }
    }
}
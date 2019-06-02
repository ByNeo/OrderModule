using System;
using System.Collections.Generic;
using System.Text;

namespace WebMVC.Models
{
    public class Result
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }


    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}

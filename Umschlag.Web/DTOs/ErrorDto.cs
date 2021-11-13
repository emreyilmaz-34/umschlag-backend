using System;
using System.Collections.Generic;

namespace Umschlag.Web.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<String>();
        }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}

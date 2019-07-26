using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Domain.Events
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }

        public ErrorResponseModel(string message) => Message = message;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Validate
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
    public class ErrorHandler
    {
        public void CheckStatus(List<Validate> Status)
        {
            switch (Status[0].Status)
            {
                case 0:
                    return;
                case 1:
                    throw new InvalidOperationException(Status[0].Message);
                default:
                    break;
            }
            // Else write data to the log and return.
        }

    }
}

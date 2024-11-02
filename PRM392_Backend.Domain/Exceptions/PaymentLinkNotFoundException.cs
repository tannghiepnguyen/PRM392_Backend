using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Exceptions
{
    public class PaymentLinkNotFoundException : NotFoundException
    {
        public PaymentLinkNotFoundException(string message) : base(message) { }
    }
}

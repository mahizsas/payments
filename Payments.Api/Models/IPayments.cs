using System;
using System.Collections.Generic;

namespace Payments.Api.Models
{
    public interface IPayments
    {
        IEnumerable<Payment> Get();
        Payment Get(Guid id);
        void Add(Payment payment);
    }
}
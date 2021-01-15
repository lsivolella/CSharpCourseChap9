using System;
using System.Collections.Generic;
using System.Text;

namespace Cap09.Exercise03.Entities.Enums
{
    enum OrderStatus : int
    {
        PendingPayment = 0,
        ProcessingPayment = 1,
        OrderShipped = 2,
        OrderDelivered = 3
    }
}

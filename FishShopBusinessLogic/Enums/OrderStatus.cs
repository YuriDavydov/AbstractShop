using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Enums
{
    /// <summary>
    /// статус готовности консервов
    /// </summary>
    public enum OrderStatus
    {
        Created,
        Accepted,        InProgress,        Finish,        Paid,
    }
}

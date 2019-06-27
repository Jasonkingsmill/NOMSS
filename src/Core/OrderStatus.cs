using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrderStatus
    {
        private OrderStatus(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static OrderStatus New => new OrderStatus("New");
        public static OrderStatus Pending => new OrderStatus("Pending");
        public static OrderStatus Fulfilled => new OrderStatus("Fulfilled");
        public static OrderStatus Error_Unfulfillable => new OrderStatus("Error: Unfulfillable");

        public override bool Equals(object obj)
        {
            return obj is OrderStatus status &&
                   Value == status.Value;
        }

        public static implicit operator string(OrderStatus status)
        {
            return status.Value;
        }

        public static implicit operator OrderStatus(string status)
        {
            return new OrderStatus(status);
        }
    }
}

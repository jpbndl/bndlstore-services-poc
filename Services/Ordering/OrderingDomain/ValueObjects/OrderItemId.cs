﻿namespace OrderingDomain.ValueObjects
{
    public record OrderItemId
    {
        public Guid Value { get; }

        private OrderItemId(Guid value) => Value = value;

        public static OrderItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            if (value == Guid.Empty)

            {
                throw new DomainException("OrderItemId value cannot be an empty GUID.");
            }   
            return new OrderItemId(value);
        }
    }
}

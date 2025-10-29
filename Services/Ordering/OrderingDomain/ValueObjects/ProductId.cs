namespace OrderingDomain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }

        private ProductId(Guid value) => Value = value;

        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            if (value == Guid.Empty)
            {
                throw new DomainException("ProductId value cannot be an empty GUID.");
            }   
            return new ProductId(value);
        }
    }
}

namespace OrderingDomain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}

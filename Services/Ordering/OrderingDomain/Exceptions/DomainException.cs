namespace OrderingDomain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string massage) : base($"Domain Exception: \"{massage}\" throws from Domain Layer.")
        {
        }
    }
}

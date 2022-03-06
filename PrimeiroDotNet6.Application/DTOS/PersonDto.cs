namespace PrimeiroDotNet6.Application
{
    public class PersonDto // class responsável pra transito de dados entre o mundo externo e a nossa app
    {
        public int? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Document { get; private set; }
        public string? Phone { get; private set; }
    }
}
namespace WebAPIDemo
{
    public class NameService
    {
        private string[] Names { get; set; }
        = new[]
        {
            "John",
            "Jim",
            "Maria",
            "Yana"
        };

        private Random random = new Random();

        public string GetRandomName()
        {
            return Names[random.Next(Names.Length)];
        }
    }
}

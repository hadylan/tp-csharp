namespace Program
{
    class Program
    {
        // Define a dictionary with some key-value pairs.
        Dictionary<int, Character> characters = new Dictionary<int, Character>()
        {
            {0, new Vampire(1)},
        };

        Random random = new Random();

        public int roll() {
            int randomInt = random.Next(1, 100);
            return randomInt;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine();
            Console.WriteLine("---------- START ----------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------- END ---------- \n");
        }
    }
}
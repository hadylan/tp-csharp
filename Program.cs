namespace Program
{
    class Program
    {
        // Define a dictionary with some key-value pairs.
        Dictionary<int, Character> characters = new Dictionary<int, Character>()
        {
            {0, new Vampire(1)},
            {1, new Guardian(2)},
            {2, new Berserker(3)},
            {3, new SuicideBomber(4)}
        };

        int turn = 1;

        public void PlayTurn() {
            List<int> keyCharactersList = new List<int>(characters.Keys);
            int alivePlayersCount = characters.Count();

            Console.WriteLine($"Nouveau tour, il s'agit du tour n°{turn} \n");
            Console.WriteLine($"Joueurs en jeu : {alivePlayersCount} \n");

            foreach (KeyValuePair<int, Character> player in characters) {
                Random rnd = new Random();
                int randomKeyTarget = keyCharactersList[rnd.Next(keyCharactersList.Count)];
                Character target = characters[randomKeyTarget];
                
                if (target == player.Value) {
                    while(target == player.Value) {
                        target = characters[keyCharactersList[rnd.Next(keyCharactersList.Count)]];
                    }
                }
                /* Console.WriteLine($"Player: {player}");
                Console.WriteLine($"Target: {target} \n"); */
                
                while(player.Value.CurrentAttackNumber > 0) {
                    player.Value.Attack(target);
                }
                
            }

            foreach (KeyValuePair<int, Character> character in characters) {
                if (character.Value.IsDead()) {
                    characters.Remove(character.Key);
                } else {
                    if (character.Value is Robot) {
                        character.Value.Power += (character.Value.Power / 2);
                    }
                    character.Value.CurrentAttackNumber++;
                }
            }
            turn++;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine();
            Console.WriteLine("---------- START ----------");
            Console.WriteLine();

            while(p.characters.Count() > 1) {
                p.PlayTurn();
            }

            if (p.characters.Count() == 1) {
                List<Character> keyCharactersList = new List<Character>(p.characters.Values);
                Console.WriteLine($"La partie prend fin, un survivant fait son apparition. Il s'agit du {keyCharactersList[0]}");
            }

            Console.WriteLine();
            Console.WriteLine("---------- END ---------- \n");
        }
    }
}
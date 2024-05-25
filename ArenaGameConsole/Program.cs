using ArenaGameEngine;

using ArenaGameEngine; // Make sure you have this using directive

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void OnGameEvent(GameEvent gameEvent)
        {
            switch (gameEvent.EventType)
            {
                case GameEventType.Round:
                    
                    Console.WriteLine($"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage!");
                    if (!gameEvent.Defender.IsAlive)
                    {
                        Console.WriteLine($"{gameEvent.Defender.Name} has been defeated!");
                    }
                    break;

                case GameEventType.BattleEnd:
                    Console.WriteLine();
                    Console.WriteLine($"Battle ended. Winner is: {gameEvent.Winner?.Name}");
                    Console.WriteLine();
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero[] heroes = {
                new Knight("Sir John"),
                new Rogue("Slim Shady"),
                new Priest("Therois Priest"),
                new Druid("Druid Balnazzar")
            };

            
            Arena arena = new Arena(heroes);
            arena.EventListener = new ConsoleGameEventListener();

            
            Hero champion = arena.StartTournament();

            
            Console.WriteLine($"{champion.Name} is the champion!");
            Console.ReadLine(); 
        }
    }
}

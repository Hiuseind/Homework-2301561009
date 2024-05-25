using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // The GameEvent class (or struct) should be defined in your project
    public class GameEvent
    {
        public GameEventType EventType { get; }
        public Hero Attacker { get; }
        public Hero Defender { get; }
        public int Damage { get; }
        public Hero Winner { get; }
        public Hero Loser { get; }

        
        public GameEvent(GameEventType eventType, Hero attacker, Hero defender, int damage)
        {
            EventType = eventType;
            Attacker = attacker;
            Defender = defender;
            Damage = damage;
        }

        
        public GameEvent(GameEventType eventType, Hero winner, Hero loser)
        {
            EventType = eventType;
            Winner = winner;
            Loser = loser;
        }
    }

    
    public enum GameEventType
    {
        BattleEnd,
        Round
    }

    public interface IGameEventListener
    {
        void OnGameEvent(GameEvent gameEvent);
    }

    
    public class GameEventListener : IGameEventListener
    {
        public virtual void OnGameEvent(GameEvent gameEvent)
        {
            switch (gameEvent.EventType)
            {
                case GameEventType.Round:
                    Console.WriteLine(gameEvent.Defender.IsAlive
                        ? $"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage! {gameEvent.Defender.Name} has {gameEvent.Defender.Health} health remaining."
                        : $"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage! {gameEvent.Defender.Name} has been defeated!");
                    break;

                case GameEventType.BattleEnd:
                    Console.WriteLine($"\nBattle ended. Winner is: {gameEvent.Winner.Name}\n");
                    break;
            }
        }
    }
}

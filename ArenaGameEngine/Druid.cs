using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Druid: Hero
    {
        public Druid (string name) : base(name)
        {
            Health = 850; 
            Strength = 120;
        }

        public override void TakeDamage(int incomingDamage)
        {
            
            if (Random.Shared.Next(5) == 0) 
            {
                incomingDamage /= 2;
            }

            base.TakeDamage(incomingDamage);
        }
    }
}

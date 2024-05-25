using System;

namespace ArenaGameEngine
{
    public class Priest : Hero
    {
        public int Mana { get; private set; } = 200;  
        public int ArcaneCharges { get; private set; } = 0; 
        public bool HasArcaneShield { get; private set; } = false;

        public Priest(string name) : base(name) { }

        public override int Attack()
        {
            if (ArcaneCharges >= 3) 
            {
                ArcaneCharges = 0; 
                int blastDamage = base.Attack() * 6;  
                return blastDamage;
            }
            else if (Mana >= 60) 
            {
                Mana -= 50;
                int missilesDamage = base.Attack() * 2;
                ArcaneCharges++; 
                return missilesDamage;
            }
            else if (!HasArcaneShield) 
            {
                HasArcaneShield = true;
                return 0; 
            }
            else 
            {
                Mana += 40; 
                return base.Attack();
            }
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (HasArcaneShield)
            {
                incomingDamage = 0; 
                HasArcaneShield = false; 
            }
            else
            {
                base.TakeDamage(incomingDamage);
                if (Mana < 200) Mana += 30; 
            }
        }
    }
}



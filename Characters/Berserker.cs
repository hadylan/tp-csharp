using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Berserker : Character
    {
        public Berserker(int id) : base(id)
        {
            Power = 100;
            Defense = 100;
            Initiative = 80;
            Damages = 20;
            MaximumLife = 300;
            CurrentLife = 300;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }

        public override void Attack(Character cible)
        {
            Power += (MaximumLife - CurrentLife);
            if (CurrentLife < MaximumLife / 2)
            {
                TotalAttackNumber = 4;
            }
            base.Attack(cible);
            return;
        }
    }
}

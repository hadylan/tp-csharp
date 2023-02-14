using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class SuicideBomber : Character
    {
        public SuicideBomber(int id) : base(id)
        {
            Power = 50;
            Defense = 125;
            Initiative = 20;
            Damages = 75;
            MaximumLife = 500;
            CurrentLife = 500;
            TotalAttackNumber = 6;
            CurrentAttackNumber = 6;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Lich : Character
    {
        public Lich(int id) : base(id)
        {
            Power = 75;
            Defense = 125;
            Initiative = 80;
            Damages = 50;
            MaximumLife = 125;
            CurrentLife = 125;
            TotalAttackNumber = 3;
            CurrentAttackNumber = 3;
            GodlessDamages = true;
        }
    }
}

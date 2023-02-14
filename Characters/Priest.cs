using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Priest : Character
    {
        public Priest(int id) : base(id)
        {
            Power = 75;
            Defense = 125;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
            IsBlessed = true;
            HolyDamages = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Ghoul : Character
    {
        public Ghoul(int id) : base(id)
        {
            Power = 50;
            Defense = 80;
            Initiative = 120;
            Damages = 30;
            MaximumLife = 250;
            CurrentLife = 250;
            TotalAttackNumber = 5;
            CurrentAttackNumber = 5;
        }
    }
}

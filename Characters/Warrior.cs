using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Warrior : Character
    {
        public Warrior(int id) : base(id)
        {
            Power = 100;
            Defense = 100;
            Initiative = 50;
            Damages = 100;
            MaximumLife = 200;
            CurrentLife = 200;
            TotalAttackNumber = 2;
            CurrentAttackNumber = 2;
        }
    }
}

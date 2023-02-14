using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Zombie : Character
    {
        public Zombie(int id) : base(id)
        {
            Power = 100;
            Defense = 0;
            Initiative = 20;
            Damages = 60;
            MaximumLife = 1000;
            CurrentLife = 1000;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }
    }
}

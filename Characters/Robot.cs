using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Robot : Character
    {
        public Robot(int id) : base(id)
        {
            Power = 10;
            Defense = 100;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 200;
            CurrentLife = 200;
            TotalAttackNumber = 1;
            CurrentAttackNumber = 1;
        }
    }
}

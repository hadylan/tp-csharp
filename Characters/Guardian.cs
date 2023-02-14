using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSHARP.Characters
{
    internal class Guardian : Character
    {
        public Guardian(int id) : base(id)
        {
            Power = 50;
            Defense = 150;
            Initiative = 50;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            TotalAttackNumber = 3;
            CurrentAttackNumber = 3;
            HolyDamages = true;
        }
    }
}

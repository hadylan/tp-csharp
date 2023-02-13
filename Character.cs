public class Character
{
    public int CurrentLife { get; set; }
    public int Damages { get; set; }
    public int Id { get; set; }
    public int Power { get; set; }
    public int Defense { get; set; }
    public bool IsCursed { get; set; }
    public bool IsBlessed { get; set; }
    public int Initiative { get; set; }
    public int MaximumLife { get; set; }
    public int CurrentAttackNumber { get; set; }
    public int TotalAttackNumber { get; set; }
    public int StunTurn { get; set; }
    public bool HolyDamages { get; set; }
    public bool GodlessDamages { get; set; }

    // Constructor
    public Character(int id) {
        Id = id;
        StunTurn = 0;
        IsBlessed = false;
        IsCursed = false;
        HolyDamages = false;
        GodlessDamages = false;
    }

    // Methods

    public bool IsDead() {
        return CurrentLife <= 0;
    }

    public void TryToStun(Character target, int damageReceived) {
        int percentChanceToStun = (damageReceived - target.CurrentLife) *2 / (target.CurrentLife + damageReceived);
        Random rnd = new Random();
        int randomInt = rnd.Next(0, 101);

        if (randomInt <= percentChanceToStun) {
            int stunTurnAmount = rnd.Next(0, 3);
            target.StunTurn = stunTurnAmount;
            Console.Write($"L'attaque a étourdi la cible pendant {stunTurnAmount} tours.");
        }
    }

    public virtual dynamic Attack(Character target) {
        if (this.CurrentAttackNumber >= 1) {
            if (this.StunTurn == 0) {
                // Define rolls and margin values
                int targetDefenseRoll = target.Defense + target.Roll();
                int attackerPowerRoll = this.Power + Roll();
                int attackMargin = attackerPowerRoll - targetDefenseRoll;

                if (attackMargin > 0) {
                    this.CurrentAttackNumber--;

                    // Define damages received by target
                    int damages = attackMargin * this.Power / 100;
                    if (this.GodlessDamages & target.IsBlessed || this.HolyDamages && target.IsCursed) {
                        damages += damages;
                    }
                    
                    // Attack
                    target.CurrentLife -= damages;

                    if (this is Vampire) {
                        this.CurrentLife += damages / 2;
                    }

                    if (target.IsDead()) {
                        Console.Write($"Attaque réussie, inflige {damages} dommages et tue la cible.");
                        return target;
                    } else {
                        TryToStun(target, damages);
                        if (target is Warrior) {
                            target.StunTurn += 1;
                        }
                        Console.Write($"Attaque réussie, inflige {damages} dommages.");
                        return true;
                    }

                } else {
                    if (this is SuicideBomber) {
                        Console.Write("Attaque ratée! contre-attaque impossible contre un Kamikaze");
                    } else if (!(target is Zombie) || !(target is SuicideBomber)) {
                        return target.CounterAttack(this, attackMargin);
                    } else  {
                        Console.Write("Attaque ratée! contre-attaque impossible avec ce personnage.");
                    }
                }
            } else {
                Console.Write("Impossible de d'attaquer car le personnage est étourdi.");
                return false;
            }
        } else {
            Console.Write("Impossible de d'attaquer car le personnage ne possède plus assez d'attaque.");
            return false;
        }
    }

    public dynamic CounterAttack(Character target, int attackMargin) {
        if (this.CurrentAttackNumber >= 1) {
            if (this.StunTurn == 0) {
                this.CurrentAttackNumber--;

                // Define damages received by target
                int damages = attackMargin * -1;

                if (this is Guardian) {
                    damages += damages;
                }

                // Apply damages and try stun target
                target.CurrentLife -= damages;

                if (target.IsDead()) {
                    Console.Write($"Contre-attaque inflige {damages} dommages et tue la cible.");
                    return target;
                } else {
                TryToStun(target, attackMargin);
                }
                
                return true;
            } else {
                // Attacker stun
                Console.Write("Impossible de contre-attaquer car le personnage est étourdi.");
                return false;
            }
        } else {
            // Attacker not enough currentAttackNumber
            Console.Write("Impossible de contre-attaquer car le personnage ne possède plus assez d'attaque.");
            return false;
        }
    }

    public int Roll() {
        if (this is Robot) {
            return 50;
        };
        Random random = new Random();
        return random.Next(0, 101);
    }
}

public class Warrior : Character
{
    public Warrior(int id) :base(id)
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

public class Guardian : Character
{
    public Guardian(int id) :base(id)
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

public class Berserker : Character
{
    public Berserker(int id) :base(id)
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

    public override dynamic Attack(Character cible)
    {
        Power += (MaximumLife - CurrentLife);
        if (CurrentLife < MaximumLife / 2) {
            TotalAttackNumber = 4;
        }
        return base.Attack(cible);
    }
}

public class Zombie : Character
{
    public Zombie(int id) :base(id)
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

public class Robot : Character
{
    public Robot(int id) :base(id)
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

public class Lich : Character
{
    public Lich(int id) :base(id)
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

public class Ghoul : Character
{
    public Ghoul(int id) :base(id)
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

public class Vampire : Character
{
    public Vampire(int id) :base(id)
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

public class SuicideBomber : Character
{
    public SuicideBomber(int id) :base(id)
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

public class Priest : Character
{
    public Priest(int id) :base(id)
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
using TP_CSHARP.Characters;
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
            Console.Write($"L'attaque a étourdi la cible pendant {stunTurnAmount} tours. \n");
        }
    }

    public virtual void Attack(Character target) {
        Console.Write($"{this} attaque {target} \n\n");

        if (this.CurrentAttackNumber >= 1) {
            // enough currentAttack, attacker can attack

            this.CurrentAttackNumber--;

            if (this.StunTurn == 0) {
                // attacker is not stunned, he can attack
                // Define rolls and margin values
                int targetDefenseRoll = target.Defense + target.Roll();
                int attackerPowerRoll = this.Power + Roll();
                int attackMargin = attackerPowerRoll - targetDefenseRoll;

                /* Console.WriteLine($"attackerPowerRoll {attackerPowerRoll}");
                Console.WriteLine($"targetDefenseRoll {targetDefenseRoll} \n\n"); */

                if (attackMargin > 0) {

                    // Define damages received by target
                    int damages = attackMargin * this.Power / 100;
                    if (this.GodlessDamages & target.IsBlessed || this.HolyDamages && target.IsCursed) {
                        damages += damages;
                    }
                    
                    // Attack the target
                    target.CurrentLife -= damages;

                    if (target is Warrior) {
                        target.CurrentAttackNumber = 0;
                    }

                    if (this is Vampire && this.CurrentLife < this.MaximumLife) {
                        // vampire heals half of the damage inflicted
                        this.CurrentLife += damages / 2;
                    }

                    if (target.IsDead()) {
                        Console.Write($"Attaque réussie, inflige {damages} dommages et tue la cible. \n");
                    } else {
                        // if received damages is higher than the remaining life of the target, he can be stunned.
                        if (damages > target.CurrentLife) {
                            if (target is Warrior) {
                                target.StunTurn += 1;
                            } else {
                                TryToStun(target, damages);
                            }
                        }
                        Console.Write($"Attaque réussie, inflige {damages} dommages. \n");
                    }
                } else {
                    // attack blocked
                    if (target is SuicideBomber || target is Zombie) {
                        Console.Write("Attaque ratée! contre-attaque impossible avec ce personnage! \n\n");
                    } else {
                        // counter-attack
                        Console.Write("Attaque ratée, l'adversaire contre-attaque! \n\n");
                        target.CounterAttack(this, attackMargin);
                    }
                }
                return;
            } else {
                // attacker is stun, he can't attack
                Console.Write("Impossible de d'attaquer car le personnage est étourdi. \n");
                return;
            }
        } else {
            // not enough currentAttackNumber, attacker can't fight
            Console.Write("Impossible d'attaquer car le personnage ne possède plus assez d'attaque. \n");
            return;
        }
    }

    public void CounterAttack(Character target, int attackMargin) {
        if (this.CurrentAttackNumber >= 1) {
            if (this.StunTurn == 0) {
                this.CurrentAttackNumber--;

                // Define damages received by target
                int damages = attackMargin * -1;

                // counterattack bonus is doubled
                if (this is Guardian) {
                    damages += damages;
                }

                // Apply damages and try stun target
                target.CurrentLife -= damages;

                if (target.IsDead()) {
                    Console.Write($"Contre-attaque inflige {damages} dommages et tue la cible. \n");
                    return;
                } else {
                    Console.WriteLine($"Contre-attaque inflige {damages} dommages, il lui reste {target.CurrentLife} points de vie. \n\n");
                    TryToStun(target, attackMargin);
                }
                
                return;
            } else {
                // Attacker stun
                Console.Write("Impossible de contre-attaquer car le personnage est étourdi. \n");
                return;
            }
        } else {
            // Attacker not enough currentAttackNumber
            Console.Write("Impossible de contre-attaquer car le personnage ne possède plus assez d'attaque. \n");
            return;
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
# CS 271: Object Oriented Programming at NMSU-A

---

Professor:
    Ayman Alzaid - alzaida@nmsu.edu

Main Developers:
    Zachary A. Carmichael - https://github.com/Smooken-Development
    Shabhan Andrew George - https://github.com/dravidian117

Contributers:
    Michael Gremse	  - https://github.com/1201-Gremse-Michael
    Jason Edgington       - https://github.com/jedge09

---

Description:

     This program was an attempt at creating a turn-based RPG with 8-bit 2D graphics.
While the logic and pseudo code were all worked out to build a functioning demo, 
complications with learning Unity within such a short time frame ended up stopping our
program dead in the tracks.

     The program features 4 main bards: a cleric (healer), a sorcerer (AOE), troubadour 
(rogue), and cellist (tank). The program would feature a main menu (start game, edit 
game saves, and lore), procedural dungeon generation (a text box that would display an
entry from a table of room descriptors), and a random number of enemies between 1-4 with
a boss every 10 floors.

     The inventory would store items like potions or charms that would heal or give buffs
to the player party. The party would all level up at the same time with each of the four
bards having a unique skill. The pseudocode is located down below. While we weren't able
to complete all of our intended features, it was still a highly beneficial learning
opportunity, and we all learned a little more about object orientated programming.

     The final program ended up with a main skeleton character that would be supported by
the 4 bards to give him buffs as he fought goblins and monsters.

---

Psuedo Code:

Class Hero:
    Attributes: Name, Health, Attack, Defense, Inventory
    Methods: UseSkill(), LevelUp(), GainExperience(), UseItem()


Class Cleric: Hero
    UseSkill():
        Heal another player for random amount in range
        Set SkillCoolDown to 2


Class Sorcerer: Hero
    UseSkill():
        Deals AOE damage to all nearby enemies
        Set SkillCoolDown to 5


Class Troubadour: Hero
    UseSkill():
        Create smoke screen
        Allows Troubadour to take two turns until the effect ends
        Set SkillCoolDown to 4


Class Cellist: Hero
    UseSkill():
        Blocks all damage for a player in a single turn
        Set SkillCoolDown to 3


public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Level { get; set; }
    public Enemy(string name, int health, int attack, int level)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Level = level;
    }
    public virtual void AttackPlayer(Hero target)
    {
        // FINISH ME:
        Console.WriteLine($"{Name} attacks player for {Attack} points of damage!");
        target.Health -= Attack;
    }
}


Class Enemy
    Attributes: Name, Health, Attack, Level
    Methods: AttackPlayer()


Class Boss: Enemy
    AttackPlayer():
        Increase damage output based on level
    AOEAttack():
        Attack all players at the same time
    TreasureDrop():
        Random index for random loot





Start Program
    Initialize Game State
    Display Main Menu
End Program

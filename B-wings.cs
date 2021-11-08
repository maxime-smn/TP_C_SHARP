using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    class B_wings
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public static B_wings Bwings(Weapon weapon)
        {
            Random rnd = new Random();
            B_wings bwings = new B_wings() { Name = "B-wings", Structure = 30 };
            Bwings.Weapons.Add(weapon.Name = "Hammer", weapon.Type = EWeaponType.Explosive, weapon.MinDamage = 1, weapon.MaxDamage = 8, weapon.Reloadtime = 1.5);
        }
    }
}
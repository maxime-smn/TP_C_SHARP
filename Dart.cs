using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    class Dart
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public static Dart Dart(Weapon weapon)
        {
            Random rnd = new Random();
            Dart dart = new Dart() { Name = "Dart", Structure = 10, Shield = 3 };
            Dart.Weapons.Add(weapon.Name = "Laser", weapon.Type = EWeaponType.Direct, weapon.MinDamage = 2, weapon.MaxDamage = 3, weapon.Reloadtime = 1);
            return dart;
        }

    }
}

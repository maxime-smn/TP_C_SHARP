using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Models
{
    class ViperMKII
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public static ViperMKII viperMKII(Weapon weapon)
        {
            Random rnd = new Random();
            ViperMKII viperMKII = new ViperMKII() { Name = "ViperMKII", Structure = 10, Shield = 15 };
            viperMKII.Weapons.Add(weapon.Name = "Mitrailleuse", weapon.Type = EWeaponType.Direct, weapon.MinDamage = 2, weapon.MaxDamage = 3, weapon.Reloadtime = 1);
            viperMKII.Weapons.Add(weapon.Name = "EMG", weapon.Type = EWeaponType.Explosive, weapon.MinDamage = 1, weapon.MaxDamage = 7, weapon.Reloadtime = 1.5);
            viperMKII.Weapons.Add(weapon.Name = "Missile", weapon.Type = EWeaponType.Guided, weapon.MinDamage = 4, weapon.MaxDamage = 100, weapon.Reloadtime = 4);
        }
}

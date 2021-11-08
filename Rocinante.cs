using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Models
{
    class Rocinante
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public static Rocinante rocinante(Weapon weapon)
        {
            Random rnd = new Random();
            Rocinante rocinante = new Rocinante() { Name = "Rocinante", Structure = 3, Shield = 5 };
            rocinante.Weapons.Add(weapon.Name = "Torpille", weapon.Type = EWeaponType.Guided, weapon.MinDamage = 3, weapon.MaxDamage = 3, weapon.Reloadtime = 2);
        }
    }
}

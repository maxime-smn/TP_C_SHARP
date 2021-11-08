using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public abstract class Spaceship : IEquatable<Spaceship>
    {
        public Guid Id { get; } = new Guid();
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public bool IsDestroyed { get; private set; } = false;
        public int MaxWeapons { get; } = 3;
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public double AverageDamages => (Weapons.Sum(x => x.MinDamage) + Weapons.Sum(x => x.MaxDamage)) / 2;

        public Spaceship(){ }

        public void AddWeapon(Weapon weapon)
        {
            // test si l'arme provien bien de l'armurerie mais c'est quasiment impossible avec les visibilités utilisées
            if (!Armory.IsWeaponFromArmory(weapon)) { throw new ArmoryException(); }
            // évite de dépasser le nombre maximum d'arme sur le vaisseau
            if (Weapons.Count < MaxWeapons) { Weapons.Add(weapon); }
            else { throw new Exception(Name + " : Max Weapons on ship"); }
        }
        public void RemoveWeapon(Weapon oWeapon)
        {
            if (Weapons.Contains(oWeapon)) { Weapons.Remove(oWeapon); }
        }
        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        public void ViewShip()
        {
            Console.WriteLine("===== INFOS VAISSEAU =====");
            Console.WriteLine("Nom : " + Name);
            Console.WriteLine("Points de vie : " + Structure);
            Console.WriteLine("Bouclier : " + Shield);
            ViewWeapons();
            Console.WriteLine("Dommages moyens: " + AverageDamages );
            Console.WriteLine();
        }
        public void ViewWeapons()
        {
            foreach (var item in Weapons)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// Permet de construire un vaisseau par defaut avec une structure de 10 pts et 10 pts de bouclier
        /// Ajoute le maximum d'arme provenant au hasard de l'armurerie
        /// </summary>
        /// <returns>Un vaisseau par defaut</returns>
        public static Spaceship DefaultSpaceship()
        {
            Random rnd = new Random();
            Spaceship ship = new Spaceship() { Name = "Viper MKII", Structure = 10, Shield = 10 };
            while (ship.Weapons.Count < ship.MaxWeapons)
            {
                try {
                    ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
                } catch(Exception e) { Console.WriteLine(e.Message); }
            }
            try {
                ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
            } catch (Exception e) { Console.WriteLine(e.Message); }
            return ship;
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Spaceship);
        }

        public bool Equals(Spaceship other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public double save_structure_without_repair(Spaceship other)
        {
            double now_health_structure;
            return now_health_structure = Structure;

        }

        public double save_shield_without_repair(Spaceship other)
        {
            double now_health_shield;
            return now_health_shield = Shield;
        }

       /* public double Damage_by_shoot (Weapon other)
        {
            double total_hit;
            do
                if (other.goodshoot == true)
                {
                    if (Shield > 0)
                    {

                    }
                }
                
        }*/

    }
}

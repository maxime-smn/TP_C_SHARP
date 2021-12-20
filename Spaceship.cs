using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Models.SpaceShips
{
    public abstract class Spaceship : IEquatable<Spaceship>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public bool IsDestroyed => CurrentShield + CurrentStructure <= 0;
        public int MaxWeapons { get; } = 3;
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public double AverageDamages => (Weapons.Sum(x => x.MinDamage) + Weapons.Sum(x => x.MaxDamage)) / 2;
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer { get; private set; }

        public Spaceship(string name, double structure, double shield, bool belongsPlayer) 
        {
            Name = name;
            Structure = structure;
            CurrentStructure = structure;
            Shield = shield;
            CurrentShield = shield;
            BelongsPlayer = belongsPlayer;
        }

        public void TakeDamages(double damages)
        {
            Console.WriteLine(Name + " encaisse " + damages + " de dommages");
            if (CurrentShield >= damages )
            {
                CurrentShield -= damages;
            }
            else 
            {
                CurrentStructure -= (damages - CurrentShield);
                CurrentShield = 0;
            } 
            Console.WriteLine("Boucliers restants : " + CurrentShield);
            Console.WriteLine("Structure restante : " + CurrentStructure);
            if (IsDestroyed) { Console.WriteLine(Name + " est détruit !"); }
        }

        public void RepairShield(double repair)
        {
            CurrentShield += repair;
            if (CurrentShield > Shield) { CurrentShield = Shield; }
        }

        public void ShootTarget(Spaceship target)
        {
            //on cherche toutes les armes qui sont rechargées
            List<Weapon> temp = Weapons.Where(x => x.IsReload).ToList();
            if (temp.Count == 0) 
            {
                Console.WriteLine("Le " + Name + " n'a pas d'armes rechargées");
                return ; 
            }
            //on cherche l'arme rechargée avec le plus de dommage moyen
            Weapon w = temp.Where(x => x.AverageDamage == temp.Max(y => y.AverageDamage)).FirstOrDefault();
            //on l'utilise
            Console.WriteLine(Name + " tire sur " + target.Name + " avec l'arme " + w.ToString());
            target.TakeDamages(w.Shoot());
        }

        public void ReloadWeapons()
        {
            foreach (var item in Weapons)
            {
                item.TimeBeforReload--;
            }
        }

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
        //public static Spaceship DefaultSpaceship()
        //{
        //    Random rnd = new Random();
        //    Spaceship ship = new Spaceship() { Name = "Viper MKII", Structure = 10, Shield = 10 };
        //    while (ship.Weapons.Count < ship.MaxWeapons)
        //    {
        //        try {
        //            ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
        //        } catch(Exception e) { Console.WriteLine(e.Message); }
        //    }
        //    try {
        //        ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
        //    } catch (Exception e) { Console.WriteLine(e.Message); }
        //    return ship;
        //}

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


    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace SpaceInvadersArmory
{
    public class Armory
    {
        #region Patern singleton
        //implémentation thread safe du patern singleton
        private static readonly Lazy<Armory> lazy =
        new Lazy<Armory>(() => new Armory());

        public static Armory Instance { get { return lazy.Value; } }

        private Armory() { Init(); }
        #endregion Patern singleton

        private List<WeaponBlueprint> blueprints = new List<WeaponBlueprint>();
        //empèche une autre entité de modifier la liste de shémas en renvoyant une liste de clone et non les shéma réelement présent dans l'armurerie
        public static List<WeaponBlueprint> Blueprints { get { return Instance.blueprints.Select(a => (WeaponBlueprint)a.Clone()).ToList(); } } 
        
        private void Init()
        {
            blueprints.Add(new WeaponBlueprint { Name = "Laser", Type = EWeaponType.Direct, MinDamage = 2, MaxDamage = 3, ReloadTime = 4 });
            blueprints.Add(new WeaponBlueprint { Name = "Hammer", Type = EWeaponType.Explosive, MinDamage = 1, MaxDamage = 8, ReloadTime = 1.5 });
            blueprints.Add(new WeaponBlueprint { Name = "Torpille", Type = EWeaponType.Guided, MinDamage = 3, MaxDamage = 3, ReloadTime = 2 });
            blueprints.Add(new WeaponBlueprint { Name = "Mitrailleuse", Type = EWeaponType.Direct, MinDamage = 6, MaxDamage = 8, ReloadTime = 1 });
            blueprints.Add(new WeaponBlueprint { Name = "EMG", Type = EWeaponType.Explosive, MinDamage = 15, MaxDamage = 37, ReloadTime = 3 });
            blueprints.Add(new WeaponBlueprint { Name = "Missile", Type = EWeaponType.Direct, MinDamage = 7, MaxDamage = 100, ReloadTime = 4 });
        }

        public static void ViewArmory()
        {
            Console.WriteLine("=====            Armurerie            =====");
            Console.WriteLine("===== Liste des shémas de constrution =====");
            foreach (var item in Instance.blueprints)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Seule méthode permetant de créer un shéma d'arme
        /// </summary>
        /// <param name="name">Le nom du shéma</param>
        /// <param name="type">Le type d'arme</param>
        /// <param name="minDamage">Les dommage minimum par defaut de l'arme</param>
        /// <param name="maxDamage">Les domage maximum par defaut de l'arme</param>
        /// <returns>Le shéma d'arme créé et ajouté à l'armurerie</returns>
        public static WeaponBlueprint CreatBlueprint(string name, EWeaponType type, double minDamage, double maxDamage)
        {
            WeaponBlueprint blueprint = new WeaponBlueprint { Name = name, Type = type, MinDamage = minDamage, MaxDamage = maxDamage };
            Instance.blueprints.Add(blueprint);
            return blueprint;
        }

        /// <summary>
        /// La seule méthode pour créer une arme
        /// </summary>
        /// <param name="blueprint">Le shéma provenant de l'armurie et qui défini les caractéristiques de base de l'arme</param>
        /// <returns>Une arme utilisable sur un vaisseau</returns>
        public static Weapon CreatWeapon(WeaponBlueprint blueprint)
        {
            Weapon weapon = new Weapon(blueprint);
            if (!IsWeaponFromArmory(weapon)) { throw new ArmoryException(); }
            return weapon;
        }

        public static bool IsWeaponFromArmory(Weapon weapon)
        {
            return Instance.blueprints.Contains(weapon.Blueprint);
        }

        public void TopFiveWeapon(WeaponBlueprint weapon)
        {
            Blueprints.OrderBy(blueprints => blueprints.averagedamage()).Take(5);//Trie du TOP 5 des armes avec les dégats moyens.
            Blueprints.OrderBy(blueprints => blueprints.MinDamage).Take(5);//Trie des 5 armes avec le dégat minimum.
        }
    }
}

using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class Dart : Spaceship
    {
        
        public Dart(bool belongsPlayer) : base("Dart", 10, 3, belongsPlayer)
        {
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "Laser").FirstOrDefault()));
            foreach (var weapon in Weapons)
            {
                if(weapon.Type == EWeaponType.Direct)
                {
                    weapon.TimeBeforReload = 1;
                    weapon.ReloadTime = 1;
                }
            }
        }
    }
}

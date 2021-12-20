using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class B_Wings : Spaceship
    {
        public B_Wings(bool belongsPlayer) : base("B-Wings", 30, 0, belongsPlayer)
        {
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "Hammer").FirstOrDefault()));
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Explosive)
                {
                    weapon.TimeBeforReload = 1;
                    weapon.ReloadTime = 1;
                }
            }
        }
    }
}

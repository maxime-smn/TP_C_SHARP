using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII(bool belongsPlayer) : base("ViperMKII", 10, 15, belongsPlayer) 
        {
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "Mitrailleuse").FirstOrDefault()));
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "EMG").FirstOrDefault()));
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "Missile").FirstOrDefault()));
        }
    }
}
using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class Rocinante : Spaceship
    {
        public Rocinante(bool belongsPlayer) : base("Rocinante", 3, 5, belongsPlayer)
        {
            AddWeapon(Armory.CreatWeapon(Armory.Blueprints.Where(x => x.Name == "Torpille").FirstOrDefault()));
        }
    }
}

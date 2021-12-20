using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis(bool belongsPlayer) : base("Tardis", 1, 0, belongsPlayer)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            Random r = new Random();
            int indexA = r.Next(0, spaceships.Count), indexB = r.Next(0, spaceships.Count);
            Spaceship tmp = spaceships[indexA];
            spaceships[indexA] = spaceships[indexB];
            spaceships[indexB] = tmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SpaceShips
{
    public class F_18 : Spaceship, IAbility
    {
        public F_18(bool belongsPlayer) : base("F-18", 15, 0, belongsPlayer)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            int position = spaceships.IndexOf(this);
            int playerPosition = spaceships.IndexOf(spaceships.Where(x => x.BelongsPlayer).FirstOrDefault());
            //on cherche a déffinir si le vaisseau du joueur est contigu avec le F18
            if(Math.Abs(position - playerPosition) <= 1) 
            {
                Console.WriteLine("Salut les mecs ... c'est moi!");
                spaceships[playerPosition].TakeDamages(10);
                this.TakeDamages(1000000000);
            }
        }
    }
}

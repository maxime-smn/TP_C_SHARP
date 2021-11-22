using Models;
using Models.SpaceShips;
using SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleGame
{
    public class SpaceInvadersConsole
    {
        public void NavigationMenu()
        {
            int Menuchoice = 0;
            Console.WriteLine(Menuchoice);
            switch (Menuchoice)
            {
                case 1:
                    Console.WriteLine("*************** Création d'un joueur ********************");
                    break;
                case 2:
                    Console.WriteLine("*************** Suppression d'un joueur ********************");
                    break;
                case 3:
                    Console.WriteLine("*************** choix du joueur ********************");
                    break;


            }
        #region Patern singleton
            //implémentation thread safe du patern singleton
        private static readonly Lazy<SpaceInvadersConsole> lazy =
        new Lazy<SpaceInvadersConsole>(() => new SpaceInvadersConsole());

        public static SpaceInvadersConsole Instance { get { return lazy.Value; } }

        private SpaceInvadersConsole() { Init(); }
        #endregion Patern singleton

        public List<Player> Players { get; private set; } = new List<Player>();
        public List<Spaceship> Spaceships { get; private set; } = new List<Spaceship>();

        private void Init()
        {
            Players = new List<Player>();
            Spaceships = new List<Spaceship>();
            Players.Add(new Player("MaXiMe", "haRlé", "Per6fleur"));
            Players.Add(new Player("Guillaume", "urban", "LaGrandeRoutière"));
            Players.Add(new Player("kintali asish-kumar", "PRusty", "DxC"));
            Spaceships.Add(Players[0].BattleShip);
            Spaceships.Add(new Dart(false)); 
            Spaceships.Add(new B_Wings(false));
            Spaceships.Add(new Rocinante(false));
            Spaceships.Add(new F_18(false));
            Spaceships.Add(new Tardis(false));
            Random rng = new Random();
            //on mélange la liste
            Spaceships.Sort((x, y) => rng.Next(-1, 2));
        }
        static void Main(string[] args)
        {
            Armory.ViewArmory();
            foreach (var item in SpaceInvadersConsole.Instance.Players)
            {
                Console.WriteLine(item.ToString());
                item.BattleShip.ViewShip();
            }
            while (SpaceInvadersConsole.Instance.Spaceships.Where(x => !x.BelongsPlayer && !x.IsDestroyed).ToList().Count > 0 && !SpaceInvadersConsole.Instance.Players[0].BattleShip.IsDestroyed)
            {
                SpaceInvadersConsole.Instance.PlayRound();
            }
            if(!SpaceInvadersConsole.Instance.Players[0].BattleShip.IsDestroyed)
            {
                Console.WriteLine("Gagné !");
            }
            else
            {
                Console.WriteLine("Perdu !");
            }
            //int win = 0;
            //for (int i = 0; i < 10000; i++)
            //{
            //    SpaceInvadersConsole.Instance.Init();
            //    while (SpaceInvadersConsole.Instance.Spaceships.Where(x => !x.BelongsPlayer && !x.IsDestroyed).ToList().Count > 0 && !SpaceInvadersConsole.Instance.Players[0].BattleShip.IsDestroyed)
            //    {
            //        SpaceInvadersConsole.Instance.PlayRound();
            //    }
            //    if (!SpaceInvadersConsole.Instance.Players[0].BattleShip.IsDestroyed)
            //    {
            //        win++;
            //    }
            //}
            //Console.WriteLine("win : " + win);
            Console.ReadKey();
        }

        public void PlayRound()
        {
            Console.WriteLine(""); 
            Console.WriteLine("=========== Tour ===========");
            Random rng = new Random();
            bool playerHasShoot = false;
            int nbrIt = 1;
            List<Spaceship> tmp = Spaceships.Where(x => !x.IsDestroyed).ToList();
            foreach (var item in tmp)
            {
                IAbility ship = item as IAbility;
                if(ship != null) { ship.UseAbility(Spaceships); }
                item.ReloadWeapons();
            }
            foreach (var item in tmp)
            {
                if(!playerHasShoot)
                {
                    tmp = Spaceships.Where(x => !x.BelongsPlayer && !x.IsDestroyed).ToList();
                    double chancesForPlayer = ((double)nbrIt / tmp.Count) * 100.0;
                    if (rng.Next(0, 101) < chancesForPlayer)
                    {
                        playerHasShoot = true;
                        Spaceship target = tmp[rng.Next(0, tmp.Count)];
                        Players[0].BattleShip.ShootTarget(target);
                    }
                }
                if (!item.BelongsPlayer && !item.IsDestroyed)
                {
                    item.ShootTarget(Players[0].BattleShip);
                }
                nbrIt++;
            }
            foreach (var item in Spaceships)
            {
                if (!item.IsDestroyed) { item.RepairShield(2); }
            }
        }
    }
}

using Models;
using SpaceInvadersArmory;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class SpaceInvadersConsole
    {
        #region Patern singleton
        //implémentation thread safe du patern singleton
        private static readonly Lazy<SpaceInvadersConsole> lazy =
        new Lazy<SpaceInvadersConsole>(() => new SpaceInvadersConsole());

        public static SpaceInvadersConsole Instance { get { return lazy.Value; } }

        private SpaceInvadersConsole() { Init(); }
        #endregion Patern singleton

        public List<Player> Players { get; } = new List<Player>();

        private void Init()
        {
            Players.Add(new Player("MaXiMe", "haRlé", "Per6fleur"));
            Players.Add(new Player("Guillaume", "urban", "LaGrandeRoutière"));
            Players.Add(new Player("kintali asish-kumar", "PRusty", "DxC"));
        }
        static void Main(string[] args)
        {
            Armory.ViewArmory();
            foreach (var item in SpaceInvadersConsole.Instance.Players)
            {
                Console.WriteLine(item.ToString());
                item.BattleShip.ViewShip();
            }
            Console.ReadKey();
        }
    }
}

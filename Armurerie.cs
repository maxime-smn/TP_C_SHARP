using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_C_Shrap
{
    class Armurerie
    {
        private static Weapon W1, W2, W3, W4, W5;
        public void Liste()
        {
            List<string> Armory = new List<string>();
            Armory.Add(new string("ARC"));
            Armory.Add(new string("ASSAULT"));
            Armory.Add(new string("SNIPER"));
            Armory.Add(new string("MECANICIAN"));
            Armory.Add(new string("MEDIC"));
        }

        public static void Init_Weapon()
        {
            W1 = new Weapon(Name_weapon : "ARC en bois", _minim_damage : 5, _max_damage : 50);
            W2 = new Weapon(Name_weapon: "ASSAULT avec Mitrailleuse", _minim_damage: 10, _max_damage: 60);
            W3 = new Weapon(Name_weapon: "SNIPER avec Barret", _minim_damage: 30, _max_damage: 100);
            W4 = new Weapon(Name_weapon: "MACANICIAN avec SEMI-AUTO", _minim_damage: 20, _max_damage: 80);
            W5 = new Weapon(Name_weapon: "MEDIC avec HK-416", _minim_damage: 15, _max_damage: 75);
        }
    }
}
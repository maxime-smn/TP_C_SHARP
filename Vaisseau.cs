using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_C_Shrap
{
    class Vaisseau
    {
        private float Health_point = 50;
        float Shield = 20;
        bool destroyed;

        public void Save_Health_lifePoint(float Save_HLP) {
            Save_HLP = Health_point;
        }
        public void _Storage_Weapon() {
            List<string> Storage_Weapon = new List<string>();

        }

        public void Add_Weapon(int Add, string new_Name, float new_minim_damage, float new_max_damage)
        {
            if (Add == 1)
                new Weapon(Name_weapon: new_Name, _minim_damage: new_minim_damage, _max_damage: new_max_damage);           
        }

        public void remove_Weapon(int rm)
        {
            if (rm == 1)
                new Weapon(Name_weapon: " ", _minim_damage: 0, _max_damage: 0);
        }

        public void View_Weapon()
        {
            _Storage_Weapon();
            Console.WriteLine();
        }

        private void Hit_average(float Hit_aver)
        {
            
        }
    }


}

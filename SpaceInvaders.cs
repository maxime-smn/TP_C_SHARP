using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_C_Shrap
{
    class SpaceInvaders
    {
        private static Player _P1, _P2, _P3;
        public SpaceInvaders() { }

        private static void Main() {
            Init_Player();
            SpaceInvaders SpaceInvaders = new SpaceInvaders();
            Console.WriteLine("Les joueurs sont : "+_P1  + " , "+_P2 + " et "+ _P3);
            
        }

        public static void Init_Player(){
            _P1 = new Player(_FirstName : "Polo" , _LastName : "Ralph", _Pseudo : "Lauren");
            _P2 = new Player(_FirstName: "Tommy", _LastName: "Hilfinger", _Pseudo: "TomHilfinger");
            _P3 = new Player(_FirstName: "Emporio", _LastName: "Armani", _Pseudo: "EAM");
        }

    }

}

using System;

namespace TP1_C_Shrap
{
    class Player//création de la classe et de ses attributs
    {
        private string LastName;
        private string FirstName;
        public string Pseudo;

        public Player(string _FirstName, string _LastName, string _Pseudo){//Constructeur public qui prends les infos de la classes
            LastName = _LastName;
            FirstName = _FirstName;
            Pseudo = _Pseudo;
            Formatting();
        }
        private void Formatting(){
            LastName = char.ToUpper(LastName[0]) + LastName.Substring(1).ToLower();
            FirstName = char.ToUpper(FirstName[0]) + FirstName.Substring(1).ToLower();
        }

        public override string ToString() => Pseudo + "( "+LastName +"  "+ FirstName+ " )";

        public override bool Equals(object obj)
        {
            object obj1 = Pseudo;
            object obj2 = Pseudo;

            if (obj1 == obj2)
                return false;
            else
                return true;
        }

    }  
}

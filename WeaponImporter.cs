using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SpaceInvadersArmory
{
    class WeaponImporter
    {
        Dictionary<string, int> WeaponImport = new Dictionary<string, int>();
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        public string NameWeapon { get; set; }

        public void Weaponimporter()
        {
            string nameweapon;
            try
            {
                StreamReader lecteur = new StreamReader("C:/Users/Maxime/Documents/CNAM/C#/TP3/Test.xml");
                nameweapon = lecteur.ReadLine();
                lecteur.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception" + e.Message);
            }
        }
    }
}
    
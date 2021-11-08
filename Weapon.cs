using System;

namespace SpaceInvadersArmory
{
    public class Weapon
    {
        public Guid Id { get; } = new Guid();
        /// <summary>
        /// Le shéma utilisé pour créer l'arme
        /// </summary>
        public WeaponBlueprint Blueprint { get; }
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage => (MinDamage + MaxDamage) / 2;
        public double Reloadtime { get; set; }
        public int LapCounter { get; set; }

        /// <summary>
        /// Constructeur avec une visibilité internal pour que seule l'armurerie puisse créer des armes.
        /// Par ce moyen on s'assure que toutes les armes proviennent l'armurerie
        /// </summary>
        /// <remarks>Exemple d'utilisation de la visibilité internal</remarks>
        internal Weapon(WeaponBlueprint blueprint)
        {
            Blueprint = blueprint;
            Name = blueprint.Name;
            Type = blueprint.Type;
            MinDamage = blueprint.MinDamage;
            MaxDamage = blueprint.MaxDamage;
            Reloadtime = blueprint.Reloadtime;
            LapCounter = blueprint.Reloadtime;
        }

        public override String ToString()
        {
            return Name + " : " + Type + " (" + MinDamage + "-" + MaxDamage + ")";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Weapon);
        }

        public bool Equals(Weapon other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <summary>
        /// Compare les arme en fonction de leur shéma
        /// </summary>
        /// <param name="obj">l'objet à comparer</param>
        /// <returns>le resultat de la comparaison</returns>
        public bool EqualsBlueprint(object obj)
        {
            return Equals(obj as Weapon);
        }
        public bool EqualsBlueprint(Weapon other)
        {
            return other != null &&
                   Blueprint.Equals(other.Blueprint);
        }

        public double Shoot(Weapon other)
        {
            Random rnd = new Random();
            int damage;
            int Luck;
            bool goodshoot;
            other.LapCounter--;

            if(other.LapCounter == 0)
            {
                damage = rnd.Next((int)other.MinDamage, (int)other.MaxDamage);

                if(other.Type == EWeaponType.Direct)
                {
                    Luck = rnd.Next(10);
                    if(Luck == 0)
                    {
                        goodshoot = false;
                        return damage = 0;
                    }
                    else
                    {
                        goodshoot = true;
                        return damage;
                    }
                }
                else if (other.Type == EWeaponType.Explosive)
                {
                    Luck = rnd.Next(5);
                    if(Luck == 0)
                    {
                        goodshoot = false;
                        return damage = 0;
                    }
                    else
                    {
                        goodshoot = true;
                        damage = damage * 2;
                        other.Reloadtime = 2 * other.LapCounter;

                        return damage + Reloadtime;
                    }
                }

                if(other.Type == EWeaponType.Guided)
                {
                    goodshoot = true;
                    damage = (int)other.MinDamage;
                    return damage;
                }
                else
                {
                    goodshoot = false;
                    return damage = 0;
                }
            }
            else if (other.LapCounter != 0)
            {
                return 0;
            }

            return 0;
        }

    }
}
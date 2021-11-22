using System;

namespace SpaceInvadersArmory
{
    public class Weapon : IEquatable<Weapon>
    {
        public Guid Id { get; } = Guid.NewGuid();
        /// <summary>
        /// Le shéma utilisé pour créer l'arme
        /// </summary>
        public WeaponBlueprint Blueprint { get; }
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage => (MinDamage + MaxDamage) / 2;
        public double ReloadTime { get; set; }
        public double TimeBeforReload { get; set; }
        public bool IsReload => TimeBeforReload <= 0;

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
            ReloadTime = blueprint.ReloadTime;
            TimeBeforReload = ReloadTime;
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

        public double Shoot()
        {
            if (!IsReload) return 0;
            double damage = 0;
            Random r = new Random();
            switch (Type)
            {
                case EWeaponType.Direct:
                    damage = HaveShootHit(10) ? GetDamage() : 0;
                    break;
                case EWeaponType.Explosive:
                    damage = HaveShootHit(4) ? GetDamage() : 0;
                    TimeBeforReload = ReloadTime * 2;
                    break;
                case EWeaponType.Guided:
                    damage = IsReload ? MinDamage : 0;
                    break;
                default:
                    damage = 0;
                    break;
            }
            if(TimeBeforReload <= 0) TimeBeforReload = ReloadTime;
            return damage;
        }

        private bool HaveShootHit(int oneChanceOf)
        {
            Random r = new Random();
            return r.Next(1, oneChanceOf) != r.Next(1, oneChanceOf);
        }

        private double GetDamage()
        {
            return IsReload ? Math.Round(MinDamage + (new Random().NextDouble() * (MaxDamage - MinDamage)), 2) : 0;
        }

        public double averagedamage()
        {
            return AverageDamage;
        }
    }
}

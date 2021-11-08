﻿using System;

public class Program
{
	public static void Main()
	{
		string FirstName, LastName;
		float Tall, Weight;
		int Age;
		int major = 18;
		Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe\n");
		Console.WriteLine("Donne moi ton nom, vil chenapan :\n");
		LastName = Console.ReadLine();
		if (LastName.Any(char.IsDigit))
        {
			Console.WriteLine("Ton nom contient une erreur, hop dehors\n");
        }
		else
        {
			Console.WriteLine("Bien, maintenant donne voir ton prénom :\n");
        }
		FirstName = Console.ReadLine();
		if (FirstName.Any(char.IsDigit))
        {
			Console.WriteLine("Désolé mais tu as mis un chiffre la.. Oust !\n");
        }
		else
        {
            Console.WriteLine("Bonjour " + FirstName + " " + LastName + " !\n");
        }
		
		Console.WriteLine("Peut-tu me donner ta taille (en cm) ?\n");
		Tall = float.Parse(Console.ReadLine());
		if (Tall.Any(char.IsLetter))
        {
			Console.WriteLine("Désolé mais tu as rentré une lettre la...");
        }
		else
        {
			Console.WriteLine("Bien, maintenant ton âge :\n");
        }	
		Age = int.Parse(Console.ReadLine());
		if (Age.Any(char.IsLetter))
		{
			Console.WriteLine("C'est bien dommage de mettre une lettre dans son nom..");
		}
		else
		{
			Console.WriteLine("Encore une petite info, le fameu poids (en kg)\n");
		}
		Weight = float.Parse(Console.ReadLine());
		if (Weight.Any(char.IsLetter))
        {
			Console.WriteLine("Tu pèse des lettres toi ?");
        }
		else
        {
			Console.WriteLine("Merci pour toutes ces petites infos !");
        }

			if (Age < major)
			{
				Console.Clear();
				Console.WriteLine("Alors comme ca " + FirstName + " " + LastName + " qui ne pèse que " + Weight + "Kg, qui ne mesure que " + Tall + " cm et qui n'a que " + Age + " ans, tu n'es vraiment qu'un vulgiaire mineur, honte à toi !\n");
			}
			else
			{
				Console.Clear();
				Console.WriteLine("Bravo Mr " + LastName + " tu connais alors le plaisir de la majorité avec tes " + Age + " ans !\n");
			}

			Console.WriteLine("Bien, merci pour toutes ses informtions, je me suis permis de calculer ton IMC que voici :\n");
			Console.WriteLine();

		}
	static string etiquette(string LastName, string FirstName)
		{
			return FirstName.ToLower() + " " + LastName.ToUpper();
		}

		static float CalculIMC(float Weight, float Tall)
		{
			Tall /= 100;
			float IMC = Weight / (Tall * Tall);
			return IMC;
		}
		static void Comm_IMC(float IMC)
		{
			const string anoerxie = "attention à l'anorexie !";
			const string maigrichon = "Vous êtes un peu maigrichon !";
			const string normal = "Vous êtes de corpulance normale";
			const string surpoids = "Vous êtes en surpoids !";
			const string obésité_mod = "Obésité modérée";
			const string obésité_sev = "Obésité sévère";
			const string obésité_morb = "Obésité morbide";

			if (IMC > 40)
				Console.WriteLine(obésité_morb);
			else if (IMC > 35)
				Console.WriteLine(obésité_sev);
			else if (IMC > 30)
				Console.WriteLine(obésité_mod);
			else if (IMC > 25)
				Console.WriteLine(surpoids);
			else if (IMC > 18.5)
				Console.WriteLine(normal);
			else if (IMC > 16.5)
				Console.WriteLine(maigrichon);
			else
				Console.WriteLine(anoerxie);
		}

		static void Nombre_Cheveux()
		{
			int nb_CH = 0;

			while (nb_CH < 100000 || nb_CH > 150000)
			{
				Console.WriteLine("Combien de cheveux pense tu avoir ?");
				try
				{
					nb_CH = int.Parse(Console.ReadLine());
				}
				catch (Exception a)
				{
					Console.WriteLine("Erreur de saisie, Merci de réessayer !");

				}
				if (nb_CH < 100000 || nb_CH > 150000)
				{
					Console.WriteLine("Non, tu n'as pas vue juste, tu veux encore une chance ?");
				}
				else
				{
					Console.WriteLine("Bien joué ! Tu as vue tu en as beaucoup sur ta tête !");
				}
			}
		}
	}



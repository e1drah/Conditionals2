using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals2
{
    internal class Program
    {
        

        static float health;

        static Boolean isDead;
        static Boolean maxHealthReached;

        static string statis;
        static string comandLine;
        static string WeaponName = "pistol";
        static void Main(string[] args)
        {
            isDead = false;
            maxHealthReached = true;

            health = 100;

            Instuction();


            Console.ReadKey(true);
        }
        //Show instuctions 
        static void Instuction()
        {
            ShowHUD();
            Console.WriteLine("Instuctions: ");
            Console.WriteLine("Type one of the following comands in order to proceed");
            Console.WriteLine();
            Console.WriteLine("+---------------+");
            Console.WriteLine("|'Take damage'  |");
            Console.WriteLine("|'Heal'         |");
            Console.WriteLine("|'Change weapon'|");
            Console.WriteLine("+---------------+");
            Console.WriteLine();
            comandLine = Console.ReadLine();

            if (comandLine == "Take damage")
            {
                if (isDead == false)
                {
                    Console.Clear();
                    DamageAmount();
                }
                else
                {
                    Console.WriteLine("Error! '" + comandLine + "' is not a vaild comand");
                    Console.WriteLine("You cannot take anymore damage! You are dead!");
                    Console.ReadKey(true);
                    Console.Clear();
                    Instuction();
                }
            }
            else if (comandLine == "Heal")
            {
                if (maxHealthReached == false)
                {
                    Console.Clear();
                    HealAmount();
                    
                }
                else
                {
                    Console.WriteLine("Error! '" + comandLine + "' is not a vaild comand");
                    Console.WriteLine("You cannot heal anymore! You are at max health!");
                    Console.ReadKey(true);
                    Console.Clear();
                    Instuction();
                }
            }
            else if (comandLine == "Change weapon")
            {
                Console.Clear();
                WhichWeapon();
            }
            else
            {
                Console.WriteLine("Error! '" + comandLine + "' is not a vaild comand");
                Console.ReadKey(true);
                Console.Clear();
                Instuction();
            }
        }
        //Figures out how much damage you take
        static void DamageAmount()
        {
            string damString;
            float damfloat;
            float damfloat2;
            ShowHUD();

            Console.WriteLine("How much damage do you take");
            damString = Console.ReadLine();
            damfloat2 = Int32.Parse(damString);
            damfloat = Convert.ToInt32(damfloat2);
            TakeDamage(damfloat);
            Console.Clear();

            Instuction();


        }
        //take damage
        static void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                isDead = true;
            }
            if (health < 100)
            {
                maxHealthReached = false;
            }
            
        }
        //Shows HUD
        static void HealAmount()
        {
            ShowHUD();
            float playerHeal;
            string playerHealString;

            Console.WriteLine("How much do you heal!");
            playerHealString = Console.ReadLine();
            playerHeal = Convert.ToInt32(playerHealString);
            HealPlayer(playerHeal);
            Console.Clear();

        }
        static void HealPlayer(float playerHeal)
        {
            health += playerHeal;
            if (health >= 0)
            {
                isDead = false;
                if (health >= 100)
                {
                    maxHealthReached = true;
                    health = 100;
                }
            }
            Console.Clear();
            Instuction();

        }
        static void WhichWeapon()
        {
            ShowHUD();

            int weaponNumber;
            string weaponNumberString;

            Console.WriteLine("+---------------+");
            Console.WriteLine("|0 = pistol     |");
            Console.WriteLine("|1 = shot gun   |");
            Console.WriteLine("|2 = spreader   |");
            Console.WriteLine("|3 = laser      |");
            Console.WriteLine("|4 = sniper     |");
            Console.WriteLine("|5 = bfg        |");
            Console.WriteLine("+---------------+");
            Console.WriteLine();
            weaponNumberString = Console.ReadLine();
            weaponNumber = Convert.ToInt32(weaponNumberString);
            Console.Clear();
            DeterminWeapons(weaponNumber);
        }
        static void ShowHUD()
        {
            DeterminStatis();
            Console.WriteLine("Heath: " + health + " Equiped weapon: " + WeaponName);
            Console.WriteLine("You are " + statis);
            Console.WriteLine();
        }
        static void DeterminStatis()
        {
            if (health <= 0)
            {
                statis = "DEAD!";
            }
            if ((health > 0) && (health <= 25))
            {
                statis = "BARLY HOLDING ON!";
            }
            if ((health > 25) && (health <= 50))
            {
                statis = "STILL KICKING!";
            }
            if ((health > 50) && (health <= 75))
            {
                statis = "ROUGHED UP!";
            }
            if ((health > 75) && (health < 100))
            {
                statis = "FINE!";
            }
            if (health >= 100)
            {
                statis = "IN PERFECT HEALTH";
            }
        }
        static void DeterminWeapons(int weaponNumber)
        {
            if (weaponNumber == 0)
            {
                WeaponName = "pistol";
                Instuction();
            }
            else if (weaponNumber == 1)
            {
                WeaponName = "shot gun";
                Instuction();
            }
            else if (weaponNumber == 2)
            {
                WeaponName = "spreader";
                Instuction();
            }
            else if (weaponNumber == 3)
            {
                WeaponName = "laser";
                Instuction();
            }
            else if (weaponNumber == 4)
            {
                WeaponName = "sniper";
                Instuction();
            }
            else if (weaponNumber == 5)
            {
                WeaponName = "bfg";
                Instuction();
            }
            else
            {
                Console.WriteLine("Error! '" + weaponNumber + "' Is not a valid weapon number");
                Console.ReadKey();
                Console.Clear();
                WhichWeapon();
            }

        }
    }
}

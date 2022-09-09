using System;
using Medieval_War.Armia;

namespace Medieval_War.Pole_boia
{
    internal class Pole_Boia
    {
        public const short shirina = 120;
        public const short visota = 40;
        private short[,] pole = new short[visota, shirina];

        public short Shirina
        {
            get { return shirina; }
        }
        public short Visota
        {
            get { return visota; }
        }
        public short this[short i, short j]
        {
            get { return pole[i, j]; }
            set { pole[i, j] = value; }
        }
        public short[,] Pole
        {
            get { return pole; }
        }
        public Pole_Boia() 
        { 
        
        }
        public void Show(Basa_Soldat[] soldati)
        {
            for (short i = 0; i < Visota; i++)
            {
                for (short j = 0; j < Shirina; j++)
                {
                    if (pole[i, j] == 0)
                        Console.BackgroundColor = ConsoleColor.Green;
                    else
                    {
                        bool IsAlive = true;
                        for (short k = 0; k < soldati.Length; k++)
                        {
                            if (soldati[k].X == j && soldati[k].Y == i)
                            {
                                IsAlive = soldati[k].HP == 0 ? false : true;
                                break;
                            }
                        }
                        if (IsAlive)
                        {
                            if (pole[i, j] == 1)
                                Console.BackgroundColor = ConsoleColor.Blue;
                            else
                                Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                            Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        public bool IsTheBattleOver(Basa_Soldat[] soldati)
        {
            for (short i = 0; i < soldati.Length; i++)
            {
                if (soldati[i].Porojenie_protivnika == true)
                    return true;
            }
            return false;
        }
    }
}
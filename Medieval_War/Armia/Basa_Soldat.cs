using System;
using Medieval_War.Orujie;
using Medieval_War.Sposob_peredvizenia;

namespace Medieval_War.Armia
{
    abstract class Basa_Soldat
    {
        private string imina;
        private short hp;
        private BasaOrujia orujie;
        private SposobPeredvizenia peredvizenia;
        private short x;
        private short y;
        private short grupa;
        private bool porojenie_protivnika;

        public string Imina
        {
            get { return imina; }
            set { imina = value; }
        }
        public short HP
        {
            get { return hp; }
            set { hp = value; }
        }
        public BasaOrujia Orujie
        {
            get { return orujie; }
            private set { orujie = value; }
        }
        public SposobPeredvizenia Peredvizenia
        {
            get { return peredvizenia; }
            set { peredvizenia = value; }
        }
        public short X
        {
            get { return x; }
            set { x = value; }
        }
        public short Y
        {
            get { return y; }
            set { y = value; }
        }
        public short Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        public bool Porojenie_protivnika
        {
            get { return porojenie_protivnika; }
            set { porojenie_protivnika = value; }
        }
        private Basa_Soldat() 
        {
        
        }
        protected Basa_Soldat(string imina, short hp, float weaponProficiency, BasaOrujia orujie, SposobPeredvizenia peredvizenia, short x, short y, short grupa, bool porojenie_protivnika)
        {
            Imina = imina;
            HP = hp;
            Orujie = orujie;
            Peredvizenia = peredvizenia;
            X = x;
            Y = y;
            Grupa = grupa;
            Porojenie_protivnika = porojenie_protivnika;
        }
        private void Move(short rastoianie_do_protivnika, short protivnikaX, short protivnikaY, short[,] pole_boia)
        {
            float protivnik = (float)(Sposob_peredvizenia.Skorost / Math.Sqrt(rastoianie_do_protivnika));
            short peredvijenie_k_X = Convert.ToInt16((X + protivnik * protivnikaX) / (1 + protivnik));
            short peredvijenie_k_Y = Convert.ToInt16((Y + protivnik * protivnikaY) / (1 + protivnik));
            short value = pole_boia[Y, X];
            pole_boia[Y, X] = 0;
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" ");
            Console.SetCursorPosition(0, pole_boia.GetLength(0));
            if (pole_boia[peredvijenie_k_Y, peredvijenie_k_X] != 0)
            {
                short nomer = 3;
                while (nomer / 2 <= peredvijenie_k_X || nomer / 2 < pole_boia.GetLength(1) - peredvijenie_k_X || nomer / 2 <= peredvijenie_k_Y || nomer / 2 < pole_boia.GetLength(0) - peredvijenie_k_Y)
                {
                    bool Esle_est = false;
                    for (short i = 0; i < nomer; i++)
                    {
                        for (short j = 0; j < nomer; j++)
                        {
                            if (j == 1 && i != 0 && i != nomer - 1)
                            {
                                j = Convert.ToInt16(nomer - (short)2);
                                continue;
                            }
                            if (peredvijenie_k_X + j >= nomer / 2 && peredvijenie_k_X + j < pole_boia.GetLength(1) + nomer / 2 && peredvijenie_k_Y + i >= nomer / 2 && peredvijenie_k_Y + i < pole_boia.GetLength(0) + nomer / 2)
                            {
                                if (pole_boia[peredvijenie_k_Y + i - nomer / 2, peredvijenie_k_X + j - nomer / 2] == 0)
                                {
                                    X = Convert.ToInt16(peredvijenie_k_X + j - nomer / 2);
                                    Y = Convert.ToInt16(peredvijenie_k_Y + i - nomer / 2);
                                    Esle_est = true;
                                }
                            }
                            if (Esle_est)
                                break;
                        }
                        if (Esle_est)
                            break;
                    }
                    if (Esle_est)
                        break;
                    nomer += 2;
                }
            }
            else
            {
                X = peredvijenie_k_X;
                Y = peredvijenie_k_Y;
            }
            pole_boia[Y, X] = value;
            Console.SetCursorPosition(X, Y);
            if (Grupa == 1)
                Console.BackgroundColor = ConsoleColor.Blue;
            else
                Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            Console.SetCursorPosition(0, pole_boia.GetLength(0));
        }
        private void Wound(Basa_Soldat[] soldati, short nomer_soldata, short pole_boia_visita)
        {
            soldati[nomer_soldata].HP -= Convert.ToInt16(Orujie.Uron);
            if (soldati[nomer_soldata].HP <= 0)
            {
                soldati[nomer_soldata].HP = 0;
                Console.SetCursorPosition(soldati[nomer_soldata].X, soldati[nomer_soldata].Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.SetCursorPosition(0, pole_boia_visita);
            }
        }
        private void RivalSearch(short[,] pole_boia, Basa_Soldat[] soldati)
        {
            short? protivnikX = null;
            short? protivnikY = null;
            short? distance_to_rival = null;
            short nomer = 3;
            short nomer_soldata = 0;
            while (nomer / 2 <= X || nomer / 2 < pole_boia.GetLength(1) - X || nomer / 2 <= Y || nomer / 2 < pole_boia.GetLength(0) - Y)
            {
                for (short i = 0; i < nomer; i++)
                {
                    if (protivnikX != null)
                        continue;
                    for (short j = 0; j < nomer; j++)
                    {
                        if (protivnikX != null)
                            continue;
                        if (j == 1 && i != 0 && i != nomer - 1)
                        {
                            j = Convert.ToInt16(nomer - (short)2);
                            continue;
                        }
                        if (X + j >= nomer / 2 && X + j < pole_boia.GetLength(1) + nomer / 2 && Y + i >= nomer / 2 && Y + i < pole_boia.GetLength(0) + nomer / 2)
                        {
                            if (pole_boia[Y + i - nomer / 2, X + j - nomer / 2] != 0 && pole_boia[Y + i - nomer / 2, X + j - nomer / 2] != Grupa)
                            {
                                for (short k = 0; k < soldati.Length; k++)
                                {
                                    if (soldati[k].X == X + j - nomer / 2 && soldati[k].Y == Y + i - nomer / 2)
                                    {
                                        nomer_soldata = k;
                                        break;
                                    }
                                }
                                if (soldati[nomer_soldata].HP != 0)
                                {
                                    protivnikX = Convert.ToInt16(X + j - nomer / 2);
                                    protivnikY = Convert.ToInt16(Y + i - nomer / 2);
                                    distance_to_rival = Convert.ToInt16(Math.Pow(j - nomer / 2, 2) + Math.Pow(i - nomer / 2, 2));
                                }
                            }
                        }
                    }
                }
                nomer += 2;
            }
            if (protivnikX == null)
                Porojenie_protivnika = true;
            else if (distance_to_rival <= Math.Pow(Orujie.Dalnost, 2))
                Wound(soldati, nomer_soldata, (short)pole_boia.GetLength(0));
            else
                Move((short)distance_to_rival, (short)protivnikX, (short)protivnikY, pole_boia);
        }
        public virtual void Attack(short[,] battlefield, Basa_Soldat[] soldiers)
        {
            RivalSearch(battlefield, soldiers);
        }
    }
}
using System;
using System.Data.SqlClient;
using Medieval_War.Armia.Boec_c_Toporom;
using Medieval_War.Armia.Boec_c_Mechom;
using Medieval_War.Armia.Boec_c_Pikai;
using Medieval_War.Armia.Boec_c_Lukom;
using Medieval_War.Armia;
using Medieval_War.Pole_boia;
using Medieval_War.Imina;
using Medieval_War.Database;

Pole_Boia pole_boia = new Pole_Boia();
for (short i = 0; i < pole_boia.Visota; i++)
{
    for (short j = 0; j < pole_boia.Shirina; j++)
        pole_boia[i, j] = (short)0;
}

Console.Write("Vvedite kolichestvo soldat pervoi grupi: ");
short pervaia_grupa_soldat = short.Parse(Console.ReadLine());
Console.Write("Vvedite kolichestvo soldat vtoroi grupi: ");
short vtoraia_grupa_soldat = short.Parse(Console.ReadLine());
Basa_Soldat[] soldati = new Basa_Soldat[pervaia_grupa_soldat + vtoraia_grupa_soldat];

short vibor = 0;
do
{
    Console.Write("\nEsli hotite vvodit informaciu samostoiatilno vvedite -- '1';\nEsli hotite chobi informacia vvodilas polu avtomaticheski vvedite -- '2': ");
    vibor = short.Parse(Console.ReadLine());
} while (vibor != 1 && vibor != 2);


for (short i = 0; i < pervaia_grupa_soldat + vtoraia_grupa_soldat; i++)
{
    if (i == 0)
        Console.WriteLine("\nPervaia grupa:\n");
    else if (i == pervaia_grupa_soldat)
        Console.WriteLine("\nVtoraia grupa:\n");
    short X = 0;
    short Y = 0;
    string okonchanie = String.Empty;
    if (i == 0 || i == pervaia_grupa_soldat)
        okonchanie = "ii";
    else if (i == 1 || i == pervaia_grupa_soldat + 1)
        okonchanie = "oi";
    else if (i == 2 || i == pervaia_grupa_soldat + 2)
        okonchanie = "ii";
    else
        okonchanie = "ii";
    short iterator = Convert.ToInt16(i < pervaia_grupa_soldat ? i + 1 : i - pervaia_grupa_soldat + 1);
    Console.WriteLine($"Esli hotite {iterator}-{okonchanie} boicami Severa vvedite -- '1';");
    Console.WriteLine($"Esli hotite {iterator}-{okonchanie} boicami Uga vvedite -- '2';");
    Console.WriteLine($"Esli hotite {iterator}-{okonchanie} boicami Zpada vvedite -- '3': ");
    Console.Write($"Esli hotite {iterator}-{okonchanie} boicami Vostoka vvedite -- '4': ");
    short vibor_armii = short.Parse(Console.ReadLine());
    Random randomnoe_chislo = new Random();
    if (vibor == 1)
    {
        Console.Write("Vvedite imia soldata: ");
        string imia = Console.ReadLine();
        Console.Write("Vvedite posiciu soldata po ixcu: ");
        short mesto_X = short.Parse(Console.ReadLine());
        Console.Write("Vvedite posiciu soldata po igriku: ");
        short mesto_Y = short.Parse(Console.ReadLine());
        X = mesto_X >= pole_boia.Shirina || mesto_X < 0 ? Convert.ToInt16(randomnoe_chislo.Next(0, pole_boia.Shirina - 1)) : mesto_X;
        Y = mesto_Y >= pole_boia.Visota || mesto_Y < 0 ? Convert.ToInt16(randomnoe_chislo.Next(0, pole_boia.Visota - 1)) : mesto_Y;
        if (vibor_armii == 1)
            soldati[i] = new Severnie_soldati(imia, X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 2)
            soldati[i] = new Ujnie_soldati(imia, X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 3)
            soldati[i] = new Zapadnie_soldati(imia, X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 4)
            soldati[i] = new Vostochnie_soldati(imia, X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else
            soldati[i] = new Severnie_soldati(imia, X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
    }
    else
    {
        X = Convert.ToInt16(randomnoe_chislo.Next(0, pole_boia.Shirina - 1));
        Y = Convert.ToInt16(randomnoe_chislo.Next(0, pole_boia.Visota - 1));
        if (vibor_armii == 1)
            soldati[i] = new Severnie_soldati(Imina.Sever[randomnoe_chislo.Next(0, Imina.Sever.Length - 1)], X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 2)
            soldati[i] = new Ujnie_soldati(Imina.Ug[randomnoe_chislo.Next(0, Imina.Ug.Length - 1)], X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 3)
            soldati[i] = new Zapadnie_soldati(Imina.Zapad[randomnoe_chislo.Next(0, Imina.Zapad.Length - 1)], X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else if (vibor_armii == 4)
            soldati[i] = new Vostochnie_soldati(Imina.Vostok[randomnoe_chislo.Next(0, Imina.Vostok.Length - 1)], X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
        else
            soldati[i] = new Severnie_soldati(Imina.Sever[randomnoe_chislo.Next(0, Imina.Sever.Length - 1)], X, Y, i < pervaia_grupa_soldat ? (short)1 : (short)2);
    }
    pole_boia[Y, X] = i < pervaia_grupa_soldat ? (short)1 : (short)2;
}

Console.WriteLine("\nPole boia vigladit vot tak:\n");
pole_boia.Show(soldati);

Console.WriteLine("\nSostav komand pered boem:");
for (short i = 0; i < 2 * soldati.Length; i++)
{
    if (i == 0)
        Console.WriteLine("\nSinia komanda:\n");
    else if (i == pervaia_grupa_soldat)
        Console.WriteLine("\nKrasnaia komanda:\n");
    if (i < soldati.Length)
    {
        if (soldati[i].Grupa == 1)
            Console.WriteLine($"{soldati[i].Imina} ({soldati[i].X}, {soldati[i].Y})");
    }
    else
    {
        if (soldati[i - soldati.Length].Grupa == 2)
            Console.WriteLine($"{soldati[i - soldati.Length].Imina} ({soldati[i - soldati.Length].X}, {soldati[i - soldati.Length].Y})");
    }
}

Console.WriteLine("\nEsli hotite nachat boi najmite lubuiu klavishu");
Console.ReadKey();

Console.Clear();
pole_boia.Show(soldati);
short nomer_boica = 1;
while (!pole_boia.IsTheBattleOver(soldati))
{
    System.Threading.Thread.Sleep(1000);
    if (nomer_boica % 2 == 1)
    {
        for (short i = 0; i < soldati.Length; i++)
        {
            if (i != 0 && soldati[i - 1].Porojenie_protivnika)
                break;
            if (soldati[i].HP != 0)
                soldati[i].Attack(pole_boia.Pole, soldati);
        }
    }
    else
    {
        for (short i = Convert.ToInt16(soldati.Length); i > 0; i--)
        {
            if (i != soldati.Length && soldati[i].Porojenie_protivnika)
                break;
            if (soldati[i - 1].HP != 0)
                soldati[i - 1].Attack(pole_boia.Pole, soldati);
        }
    }
    nomer_boica++;
}
Console.SetCursorPosition(0, pole_boia.Visota);

short vse_sin_soldati = 0;
short vse_vijivshie = 0;
short vse_kra_soldati = 0;
short nomer_vijivshai_grupi = 0;
for (short i = 0; i < soldati.Length; i++)
{
    if (soldati[i].Grupa == 1)
        vse_sin_soldati++;
    else
        vse_kra_soldati++;
    if (soldati[i].HP != 0)
    {
        vse_vijivshie++;
        nomer_vijivshai_grupi = soldati[i].Grupa;
    }
}

Singleton podkluchenie = Singleton.GetInstance("Server=DESKTOP-QUNSP;Database=Medieval War Resultat Boia;Trusted_Connection=True;");
DataBase dataBase = new DataBase(podkluchenie);
using (dataBase.SqlPodkluchenie)
{
    dataBase.SqlPodkluchenie.Open();
    SqlComandi command_1 = dataBase.Request("SELECT TOP 1 * FROM Resultat ORDER BY ID DESC;");
    SqlDataReader reader = command_1.ExecuteReader();
    short nomer = 0;
    while (reader.Read())
        nomer = Convert.ToInt16(reader.GetValue(1));
    reader.Close();

    SqlComandi command_2 = dataBase.Request(String.Format("INSERT INTO Pobeda_Info(Vse_Soldati, Survivors) VALUES({0}, {1}); INSERT INTO Porajenie_Info(Vse_Soldati) VALUES({2}); INSERT INTO Results(Pobeda_Id, Porajenie_Id) VALUES({3}, {3}); ", nomer_vijivshai_grupi == 1 ? vse_sin_soldati : vse_kra_soldati, all_survivors, nomer_vijivshai_grupi == 1 ? vse_kra_soldati : vse_sin_soldati, nomer + 1));
    if (command_2.ExecuteNonQuery() > 0)
        Console.WriteLine("The battle is over");
    dataBase.SqlPodkluchenie.Close();
}

string cvet_pobeditela = nomer_vijivshai_grupi == 1 ? new string("Siniia") : new string("Krasnaia");
string imena_visivshih = String.Empty;
for (short i = 0; i < soldati.Length; i++)
{
    if (soldati[i].HP != 0)
        imena_visivshih += soldati[i].Imina + ", ";
}
imena_visivshih = imena_visivshih.Remove(imena_visivshih.Length - 2);
Console.WriteLine($"V boiu uchastvivalo {soldati.Length} boicov. {cvet_pobeditela} komanda pobedila.\n{vse_vijivshie} boicov vijilo - {imena_visivshih}.");
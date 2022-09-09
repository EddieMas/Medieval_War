using Medieval_War.Orujie.Blijnii_boi;
using Medieval_War.Sposob_peredvizenia;

namespace Medieval_War.Armia.Boec_c_Pikai
{
    internal class Vostochnie_soldati : Basa_Soldat
    {
        public Vostochnie_soldati(string imina, short X, short Y, short grupa) : base(imina, 100, (float)2.3, new Pika(), new Na_kone(), X, Y, grupa, false) 
        { 
        
        }
        public override void Attack(short[,] pole_boia, Basa_Soldat[] soldati)
        {
            base.Attack(pole_boia, soldati);
        }
    }
}
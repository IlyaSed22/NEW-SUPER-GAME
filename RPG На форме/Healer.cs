using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable()]
    class Healer : Hero
    {
        public static readonly string nameofclass = "Жрец";
        public void Heal(Hero h1)
        {
            h1.Health = h1.Health + 50;
        }
        public void Attack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(5, 20);
            h1.Health -= dmg;
            h1.ContrAttack(this);
        }
         public Healer() : base()
        {
            base.Health = 75;
            Random rnd = new Random();
            dmg = rnd.Next(5, 20);
            
            strong = 15;

            Skills.Add("Атака", Attack);
            Skills.Add("Лечение", Heal);
        }

         public override void ContrAttack(Hero h1)
         {
             Random rnd = new Random();
             dmg = rnd.Next(0, 15);
             h1.Health -= dmg;
         }
         public override string GetClassName()
         {
             return nameofclass;
         }
         public static Hero Create()
         {
             return 
                 new Healer();
         }
    } 
}

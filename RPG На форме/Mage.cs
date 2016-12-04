using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable()]
    class Mage : Hero
    {
        public static readonly string nameofclass = "Маг";
        public Mage() : base()
        {
            base.Health = 40;
           
            strong = 65;

            Skills.Add("Атака", Attack);
        }
        public override void Attack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(55, 70);
            h1.Health -= dmg;
            h1.ContrAttack(this);
        }

        public override void ContrAttack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(40, 60);
            h1.Health -= dmg;
        }
        public override string GetClassName()
        {
            return nameofclass;
        }
        public static Hero Create()
        {
            return new Mage();
        }
    }
}

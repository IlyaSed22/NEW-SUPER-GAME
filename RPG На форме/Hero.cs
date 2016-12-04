using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsFormsApplication1
{
    [Serializable()]
    public abstract class Hero
    {
        public static List<string> NameList = new List<string>();
        private Random _rS;
        List<string> HeroName = new List<string>();
        public int strong;
        public string idname;
        public string name;
        
        public int dmg;

        // Словарь, в котором будут храниться умения героя
        // Где ключ - это название умения
        // И значение - это само метод умения
        public Dictionary<string, SkillHandler> Skills;

        // Делегат, в котором будут храниться действия
        public delegate void SkillHandler(Hero hero);

        public Hero()
        {
             Skills = new Dictionary<string, SkillHandler>();
             _rS = new Random();

             int r = _rS.Next(NameList.Count);
             name = NameList[r];
        }

        public virtual void Attack(Hero h1)
        {
               
        }

        public override string ToString()
        {
            return name;
        }

        public virtual void ContrAttack(Hero h1)
        {

        }

        private int _health;
        public int Health
        {
            get { return _health; }

            set 
            {
                if (value <= 0)
                {
                    _health = 0;
                    if (OnDeath != null)
                    {
                        OnDeath(this);
                    }
                }
                else
                {
                    _health = value;
                }
            }
        }
        public abstract string GetClassName();
        
        public event SkillHandler OnDeath;

        
    }
}



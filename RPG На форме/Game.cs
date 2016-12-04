using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{ 
        [Serializable()]
        public sealed class Game
        {
            public void Start()
            {
                // Если файл сохранения существуют, загружай игру
                //if(false)
                if (File.Exists("team1.bin") && File.Exists("team2.bin"))
                {
                    using (Stream stream = File.Open("team1.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        YourTeam = (List<Hero>)bin.Deserialize(stream);
                    }
                    using (Stream stream = File.Open("team2.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        EnemyTeam = (List<Hero>)bin.Deserialize(stream);
                    }
                }
                //Иначе - создай новую
                else
                {
                    
                    Form2 forma2 = new Form2();
                    forma2.ShowDialog();

                }
            }

            static readonly Game _instance = new Game();
            public static Game Instance
            {
                get
                {
                    return _instance;
                }
            }

            public Dictionary<string, Func<Hero>> HeroCreater;

            public List<Hero> YourTeam;

            public List<Hero> EnemyTeam;

            Game()
            {
                HeroCreater = new Dictionary<string, Func<Hero>>();
                HeroCreater.Add(Warrior.nameofclass, Warrior.Create);
                HeroCreater.Add(Mage.nameofclass, Mage.Create);
                HeroCreater.Add(Healer.nameofclass, Healer.Create);
                YourTeam = new List<Hero>();
                EnemyTeam = new List<Hero>();
                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader("Имена.txt", Encoding.Default))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                Hero.NameList = lines;
            }
            
            public void AddPersonage(Hero jj)
            {

                YourTeam.Add(jj);
            }

            public void AddEnemy(Hero jj)
            {
                EnemyTeam.Add(jj);
            }

            public void Check()
            {
                if (EnemyTeam.Count == 0)
                {

                }
                if (YourTeam.Count == 0)
                {

                }
            }

            
    }
}

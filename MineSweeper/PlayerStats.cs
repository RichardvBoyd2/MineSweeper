using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class PlayerStats : IComparable
    {
        public String name;
        public String level;
        public int time;

        public PlayerStats (String level, int time)
        {
            this.level = level;
            this.time = time;
        }

        public PlayerStats(String name, String level, int time)
        {
            this.name = name;
            this.level = level;
            this.time = time;
        }

        public int CompareTo(object obj)
        {
            return time.CompareTo(obj);
        }

        public override String ToString()
        {
            return name + level + time.ToString();
        }
    }
}
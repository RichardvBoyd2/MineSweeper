using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227MilestoneProject
{
    class Cell
    {
        public int row { get; set; } = -1;
        public int col { get; set; } = -1;
        public bool visited { get; set; } = false;
        public bool live { get; set; } = false;
        public int liveneighbors { get; set; } = 0;

        public Cell() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    interface IPlayable
    {
        void PlayGame();
        void CellVisit(int x, int y);
        void RefreshGame();
        bool Win(Square[,] test);
        void RecursiveTest(int x, int y);
    }
}

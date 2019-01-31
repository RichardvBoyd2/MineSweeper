using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class HighScores : Form
    {
        List<PlayerStats> scores = new List<PlayerStats>();
        List<PlayerStats> sortedScores = new List<PlayerStats>();

        //constructor for losing games
        public HighScores(string level)
        {
            using (StreamReader input = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Scores.txt")))
            {
                string line;
                int savedtime;
                string[] split;

                while ((line = input.ReadLine()) != null)
                {
                    split = line.Split(' ');
                    Int32.TryParse(split[2], out savedtime);
                    NewScore(split[0], split[1], savedtime);
                }
            }

            var queryScores =
                from PlayerStats in scores
                where PlayerStats.level == level
                orderby PlayerStats.time ascending
                select PlayerStats;

            foreach (var PlayerStats in queryScores)
            {
                sortedScores.Add(PlayerStats);
            }

            InitializeComponent();
        }

        //constructor for winning games
        public HighScores(string name, string level, int time)
        {
            NewScore(name, level, time);
            using (StreamReader input = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Scores.txt")))
            {
                string line;
                int savedtime;
                string[] split;

                while ((line = input.ReadLine()) != null)
                {
                    split = line.Split(' ');
                    Int32.TryParse(split[2], out savedtime);
                    NewScore(split[0], split[1], savedtime);
                }
            }

            using (StreamWriter output = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Scores.txt")))
            {
                foreach (var PlayerStats in scores)
                {
                    output.WriteLine(PlayerStats.name + " " + PlayerStats.level + " " + PlayerStats.time);
                }
            }

            var queryScores =
                from PlayerStats in scores
                where PlayerStats.level == level
                orderby PlayerStats.time ascending
                select PlayerStats;

            foreach (var PlayerStats in queryScores)
            {
                sortedScores.Add(PlayerStats);
            }

            InitializeComponent();
        }

        public void NewScore(string name, string level, int time)
        {
            scores.Add(new PlayerStats(name, level, time));
        }

    }
}

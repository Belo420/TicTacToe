using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player1
    {
        public int wins { get; set; }
        public int loses { get; set; }
    }

    public class Player2
    {
        public int loses { get; set; }
        public int wins { get; set; }
    }

    public class Scores
    {
        public Player1 Player1 { get; set; }
        public Player2 Player2 { get; set; }
        public int pats { get; set; }
    }
}

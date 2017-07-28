using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoRooms.Domain;

namespace TwoRooms.Uwp
{
    class GameTypeSelectViewModel
    {
        public PlayerCount Player { get; set; }
        public IList<GameType> GameTypes { get; set; }
    }
}

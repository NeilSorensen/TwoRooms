using System;
using System.Collections.Generic;
using System.Text;

namespace TwoRooms.Domain
{
    public class RuleFactory
    {
        private static readonly IDictionary<PlayerCount, GameRules> BasicRules;
        private static readonly IDictionary<PlayerCount, GameRules> AdvancedRules;

        private static readonly IDictionary<PlayerCount, int[]> HostageCounts;

        static RuleFactory()
        {
            HostageCounts = new Dictionary<PlayerCount, int[]>
            {
                {PlayerCount.SixToTen, new []{1, 1, 1} },
                {PlayerCount.ElevenToThirteen, new []{1, 1, 2, 2, 2} },
                {PlayerCount.FourteenToSeventeen, new []{1, 1, 2, 2, 3} },
                {PlayerCount.EighteenToTwentyOne, new []{1, 1, 2, 3, 4} },
                {PlayerCount.TwentyTwoPlus, new []{1, 2, 3, 4, 5} },
            };

            BasicRules = new Dictionary<PlayerCount, GameRules>
            {
                { PlayerCount.SixToTen, new GameRules(3, HostageCounts[PlayerCount.SixToTen]) },
                { PlayerCount.ElevenToThirteen, new GameRules(3, HostageCounts[PlayerCount.ElevenToThirteen]) },
                { PlayerCount.FourteenToSeventeen, new GameRules(3, HostageCounts[PlayerCount.FourteenToSeventeen]) },
                { PlayerCount.EighteenToTwentyOne, new GameRules(3, HostageCounts[PlayerCount.EighteenToTwentyOne]) },
                { PlayerCount.TwentyTwoPlus, new GameRules(3, HostageCounts[PlayerCount.TwentyTwoPlus]) },
            };

            AdvancedRules = new Dictionary<PlayerCount, GameRules>
            {
                { PlayerCount.ElevenToThirteen, new GameRules(5, HostageCounts[PlayerCount.ElevenToThirteen]) },
                { PlayerCount.FourteenToSeventeen, new GameRules(5, HostageCounts[PlayerCount.FourteenToSeventeen]) },
                { PlayerCount.EighteenToTwentyOne, new GameRules(5, HostageCounts[PlayerCount.EighteenToTwentyOne]) },
                { PlayerCount.TwentyTwoPlus, new GameRules(5, HostageCounts[PlayerCount.TwentyTwoPlus]) },
            };
        }

        public static GameType[] GetSupportedGameTypes(PlayerCount players)
        {
            if (players == PlayerCount.SixToTen)
            {
                return new GameType[] { GameType.Basic };
            }
            return new GameType[] { GameType.Basic, GameType.Advanced };
        }


        public static GameRules GetGameRules(PlayerCount playerCount, GameType type)
        {
            if (type == GameType.Basic)
            {
                return BasicRules[playerCount];
            }
            return AdvancedRules[playerCount];
        }

    }

}

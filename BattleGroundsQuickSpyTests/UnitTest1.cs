using System;
using System.Diagnostics;
using System.Linq;
using HackF5.UnitySpy;
using HackF5.UnitySpy.HearthstoneLib;
using NUnit.Framework;

namespace BattleGroundsQuickSpyTests
{
    public class Tests
    {
        [Test]
        public void PassingTest()
        {
            Console.WriteLine( DateTime.Now.ToString("HH:mm:ss") );
            MindVision mindVision = new MindVision();
            var players = mindVision.GetBattlegroundsInfo().Game.Players;
            Console.WriteLine( DateTime.Now.ToString("HH:mm:ss") );
            players = mindVision.GetBattlegroundsInfo().Game.Players;
            Console.WriteLine( DateTime.Now.ToString("HH:mm:ss") );
            foreach (var player in players)
            {
                Console.WriteLine(player.LeaderboardPosition);
                Console.WriteLine(player.TechLevel);
            }
        }
    }
}
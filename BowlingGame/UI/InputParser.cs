using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public class InputParser
    {
        private readonly IGameParser _gameParser;

        public InputParser(IGameParser gameParser)
        {
            _gameParser = gameParser;
        }

        public List<GameState> Parse(string input)
        {
            return input.Split('\n')
                        .Where(line => !string.IsNullOrEmpty(line))
                        .Select(game => _gameParser.Parse(game))
                        .ToList();
        }
    }
}

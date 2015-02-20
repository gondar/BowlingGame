using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public interface IInputParser
    {
        List<GameState> Parse(List<string> input);
    }

    public class InputParser : IInputParser
    {
        private readonly IGameParser _gameParser;

        public InputParser(IGameParser gameParser)
        {
            _gameParser = gameParser;
        }

        public List<GameState> Parse(List<string> input)
        {
            return input.Select(game => _gameParser.Parse(game))
                        .ToList();
        }
    }
}

using System.Globalization;
using System.Linq;
using BowlingGame.Domain;
using BowlingGame.UI;

namespace BowlingGame
{
    public class BowlingGame
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly IInputParser _inputParser;
        private readonly IGame _game;

        static void Main(string[] args)
        {
            var bowlingGame = new BowlingGame();
            bowlingGame.Play();
        }

        public BowlingGame(IConsoleWrapper consoleWrapper = null, IInputParser inputParser = null, IGame game = null)
        {
            _consoleWrapper = consoleWrapper ?? new ConsoleWrapper();
            _inputParser = inputParser ?? new InputParser(new GameParser(new FrameParser()));
            _game = game ?? new Game();
        }

        public void Play()
        {
            var gameStates = _inputParser.Parse(_consoleWrapper.ReadLines());

            var output = gameStates.Select(gameState => _game.Play(gameState))
                                   .Select(result => result.ToString(CultureInfo.InvariantCulture))
                                   .ToList();

            _consoleWrapper.WriteLines(output);
        }
    }
}

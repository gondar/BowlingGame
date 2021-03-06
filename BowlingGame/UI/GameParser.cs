﻿using System.Linq;
using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public interface IGameParser
    {
        GameState Parse(string gameText);
    }

    public class GameParser : IGameParser
    {
        private readonly IFrameParser _frameParser;

        public GameParser(IFrameParser frameParser)
        {
            _frameParser = frameParser;
        }

        public GameState Parse(string gameText)
        {
            return new GameState
                {
                    Frames = gameText.Split('|')
                                     .Select(frame => _frameParser.Parse(frame))
                                     .ToList()
                };
        }
    }
}
using Expanse.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines
{
    public class PresentationEngine : IPresentTheGame
    {
        protected IPlayAudio _audioEngine { get; private set; }
        protected IShowGraphics _renderingEngine { get; private set; }

        public PresentationEngine(IShowGraphics renderingEngine, IPlayAudio audioEngine)
        {
            _renderingEngine = renderingEngine;
            _audioEngine = audioEngine;
        }
    }
}

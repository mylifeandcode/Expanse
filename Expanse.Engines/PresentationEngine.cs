using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines
{
    public interface IPresentationEngine { }

    public class PresentationEngine : IPresentationEngine
    {
        protected IAudioEngine _audioEngine { get; private set; }
        protected IRenderingEngine _renderingEngine { get; private set; }

        public PresentationEngine(IRenderingEngine renderingEngine, IAudioEngine audioEngine)
        {
            _renderingEngine = renderingEngine;
            _audioEngine = audioEngine;
        }
    }
}

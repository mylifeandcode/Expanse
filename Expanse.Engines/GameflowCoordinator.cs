using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines
{
    public interface IGameflowCoordinator
    {
        void EndTurn();
        void SaveGame(string filename);
        void LoadGame(string filename);
        void Quit();
        void NewGame();
    }

    public class GameflowCoordinator : IGameflowCoordinator
    {
        #region Properties
        public IArtificialIntelligenceDecisionEngine AIDecisionEngine { get; private set; }
        public IAudioEngine AudioEngine { get; private set; }
        public ICombatEngine CombatEngine { get; private set; }
        public IDiplomacyEngine DiplomacyEngine { get; private set; }
        public IMovementEngine MovementEngine { get; private set; }
        public IPresentationEngine PresentationEngine { get; private set; }
        public IProductionEngine ProductionEngine { get; private set; }
        public IRenderingEngine RenderingEngine { get; private set; }
        public IResourceEngine ResourceEngine { get; private set; }
        #endregion Properties

        #region Constructors
        public GameflowCoordinator(
            IArtificialIntelligenceDecisionEngine aiDecisionEngine,
            IAudioEngine audioEngine,
            ICombatEngine combatEngine,
            IDiplomacyEngine diplomacyEngine,
            IMovementEngine movementEngine,
            IPresentationEngine presentationEngine,
            IProductionEngine productionEngine,
            IRenderingEngine renderingEngine,
            IResourceEngine resourceEngine)
        {
            AIDecisionEngine = aiDecisionEngine;
            AudioEngine = audioEngine;
            CombatEngine = combatEngine;
            DiplomacyEngine = diplomacyEngine;
            MovementEngine = movementEngine;
            PresentationEngine = presentationEngine;
            ProductionEngine = productionEngine;
            RenderingEngine = renderingEngine;
            ResourceEngine = resourceEngine;
        }
        #endregion Constructors

        #region Public Methods
        public void EndTurn()
        {
            //TODO: Resolve all actions for player and AI
            BeginTurn();
            throw new NotImplementedException();
        }

        public void SaveGame(string filename)
        {
            throw new NotImplementedException();
        }

        public void LoadGame(string filename)
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            throw new NotImplementedException();
        }
        #endregion Public Methods

        #region Private Methods
        private void BeginTurn()
        {
        }
        #endregion Private Methods
    }
}

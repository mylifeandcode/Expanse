using Expanse.Engines.Interfaces;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines
{
    public class GameflowCoordinator : ICoordinateGameflow
    {
        #region Properties
        public IMakeAIDecisions AIDecisionEngine { get; private set; }
        public IPlayAudio AudioEngine { get; private set; }
        public IResolveCombat CombatEngine { get; private set; }
        public ICoordinateDiplomacy DiplomacyEngine { get; private set; }
        public IResolveMovement MovementEngine { get; private set; }
        public IPresentTheGame PresentationEngine { get; private set; }
        public ICoordinateProduction ProductionEngine { get; private set; }
        //public IShowGraphics RenderingEngine { get; private set; }
        public IAdjustResources ResourceEngine { get; private set; }
        #endregion Properties

        #region Constructors
        public GameflowCoordinator(
            IMakeAIDecisions aiDecisionEngine,
            IPlayAudio audioEngine,
            IResolveCombat combatEngine,
            ICoordinateDiplomacy diplomacyEngine,
            IResolveMovement movementEngine,
            IPresentTheGame presentationEngine,
            ICoordinateProduction productionEngine,
            //IShowGraphics renderingEngine,
            IAdjustResources resourceEngine)
        {
            AIDecisionEngine = aiDecisionEngine;
            AudioEngine = audioEngine;
            CombatEngine = combatEngine;
            DiplomacyEngine = diplomacyEngine;
            MovementEngine = movementEngine;
            PresentationEngine = presentationEngine;
            ProductionEngine = productionEngine;
            //RenderingEngine = renderingEngine;
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

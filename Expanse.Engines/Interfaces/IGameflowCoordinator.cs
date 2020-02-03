using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines.Interfaces
{
    public interface IGameflowCoordinator
    {
        void EndTurn();
        void SaveGame(string filename);
        void LoadGame(string filename);
        void Quit();
        void NewGame();
    }
}

using BoxesLogic.Interfaces;
using ConsoleTables;

namespace Program.Implamentations
{
    internal class ShowConfiguration : IUiScreen
    {
        public void Show()
        {
            StaticInstances.LogicManager.ShowConfigurations();
        }
    }
}
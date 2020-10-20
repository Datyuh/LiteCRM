using LiteCRM.Infrastucture.Commands.Base;
using System.Windows;

namespace LiteCRM.Infrastucture.Commands
{
    internal class CloseApplicationMainCommand : Command

    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();

    }

}

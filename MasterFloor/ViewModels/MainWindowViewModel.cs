using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MasterFloor.Models;
using MasterFloor.Views;

namespace MasterFloor.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel? Instance;
        public MainWindowViewModel()
        {
            Instance = this;
        }

        [ObservableProperty]
        private UserControl _userControl = new PartnersView();
      
        public static _43pTokarevaUpContext dbContext = new _43pTokarevaUpContext();
    }
}

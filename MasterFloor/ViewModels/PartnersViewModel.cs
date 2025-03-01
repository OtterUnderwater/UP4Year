using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MasterFloor.Models;
using MasterFloor.Views;

namespace MasterFloor.ViewModels
{
	public partial class PartnersViewModel : ViewModelBase
	{
        public PartnersViewModel()
        {
            Partners = MainWindowViewModel.dbContext.Partners.ToList();
        }

        [ObservableProperty]
        List<Partner> _partners = new List<Partner>();

        // дополнительного фона используется цвет #F4E8D3.
        // Для акцентирования внимания цвет #67BA80.
        // Заголовок окна(страницы) должен соответствовать назначению
    }
}
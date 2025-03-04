using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterFloor.Models;
using MasterFloor.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MasterFloor.ViewModels
{
	public partial class HistoryViewModel : ViewModelBase
	{
		[ObservableProperty]
		List<PartnerProduct> _products;

		[ObservableProperty]
		string _heading;

		public HistoryViewModel(Partner partner)
		{
			Heading = $"История реализации продукции \"{partner.Title}\"";
			Products = MainWindowViewModel.dbContext.PartnerProducts.Where(pp => pp.IdPartner == partner.Id)
				.Include(pp => pp.IdProductNavigation).ToList();
		}

		[RelayCommand]
		public void GoBack() => MainWindowViewModel.Instance.UserControl = new PartnersView();
	}
}
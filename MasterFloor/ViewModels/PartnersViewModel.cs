using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterFloor.Models;
using MasterFloor.Views;
using Microsoft.EntityFrameworkCore;

namespace MasterFloor.ViewModels
{
	public partial class PartnersViewModel : ViewModelBase
	{
		[ObservableProperty]
		List<Partner> _partners = new List<Partner>();

		Partner _selectedPartner;
		public Partner SelectedPartner
		{
			get => _selectedPartner;
			set
			{
				_selectedPartner = value;
				//При выборе элемента осуществляется переход на форму редактирования
				MainWindowViewModel.Instance.UserControl = new EditAddPartnerView(_selectedPartner.Id);
			}
		}

		public PartnersViewModel()
        {
            Partners = MainWindowViewModel.dbContext.Partners.Include(p => p.IdTypeCompanyNavigation)
				.Include(p => p.PartnerProducts).ToList();
			foreach (var item in Partners)
			{
				int sum = item.PartnerProducts.Sum(it => it.CountProducts);
				if (sum < 10000)
					item.Discount = 0;
				else if (sum >= 10000 && sum < 50000)
					item.Discount = 5;
				else if (sum >= 50000 && sum < 300000)
					item.Discount = 10;
				else if (sum >= 300000)
					item.Discount = 15;
			}
		}

		[RelayCommand]
		public void GoAddPartner() => MainWindowViewModel.Instance.UserControl = new EditAddPartnerView();

		[RelayCommand]
		public void GoHistory(Partner partner) => MainWindowViewModel.Instance.UserControl = new HistoryView(partner);
	}
}
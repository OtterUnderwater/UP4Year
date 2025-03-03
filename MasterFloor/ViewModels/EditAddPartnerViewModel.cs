using CommunityToolkit.Mvvm.ComponentModel;
using MasterFloor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterFloor.ViewModels
{
	public partial class EditAddPartnerViewModel : ViewModelBase
	{
		[ObservableProperty]
		Partner _partner;

		public EditAddPartnerViewModel()
		{

		}

		public EditAddPartnerViewModel(int IdPartner)
		{
			_partner = MainWindowViewModel.dbContext.Partners.First(p => p.Id == IdPartner);
		}
	}
}
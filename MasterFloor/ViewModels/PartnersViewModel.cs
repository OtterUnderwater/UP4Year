using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MasterFloor.Models;
using MasterFloor.Views;
using Microsoft.EntityFrameworkCore;

namespace MasterFloor.ViewModels
{
	public partial class PartnersViewModel : ViewModelBase
	{
        public PartnersViewModel()
        {
            Partners = MainWindowViewModel.dbContext.Partners.Include(it => it.IdTypeCompanyNavigation).ToList();
			//foreach (var item in Partners)
			//{
			//	int sum = item.PartnerProducts.Sum(it => it.CountProducts);
			//	if (sum < 10000) item.Discount = 0;
			//	else if (sum >= 10000 && sum <= 50000) item.Discount = 5;
			//	else if (sum >= 50000 && sum <= 300000) item.Discount = 10;
			//	else if (sum > 300000) item.Discount = 15;
			//}
		}

		[ObservableProperty]
        List<Partner> _partners = new List<Partner>();

		// дополнительного фона используется цвет #F4E8D3.
		// Для акцентирования внимания цвет #67BA80.
		// Заголовок окна(страницы) должен соответствовать назначению
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterFloor.Models;
using MasterFloor.Views;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFloor.ViewModels
{
	public partial class EditAddPartnerViewModel : ViewModelBase
	{
		[ObservableProperty]
		Partner _partner;

		[ObservableProperty]
		List<TypeCompany> _typesCompany;

		[ObservableProperty]
		string _heading;

		public EditAddPartnerViewModel()
		{
			Heading = "Добавление партнера";
			TypesCompany = MainWindowViewModel.dbContext.TypeCompanies.ToList();
			Partner = new Partner();
			Partner.IdTypeCompanyNavigation = TypesCompany.First();
		}

		public EditAddPartnerViewModel(int IdPartner)
		{
			Heading = "Редактирование партнера";
			TypesCompany = MainWindowViewModel.dbContext.TypeCompanies.ToList();
			Partner = MainWindowViewModel.dbContext.Partners.Include(p => p.IdTypeCompanyNavigation).First(p => p.Id == IdPartner);
		}

		[RelayCommand]
		public async Task Save()
		{
			try
			{
				if (Partner.Id == 0)
				{
					MainWindowViewModel.dbContext.Partners.Add(Partner);
					MainWindowViewModel.dbContext.SaveChanges();
					await MessageBoxManager.GetMessageBoxStandard("Добавление", "Партнер добавлен", ButtonEnum.Ok, Icon.Info).ShowAsync();
				}
				else
				{
					MainWindowViewModel.dbContext.Partners.Update(Partner);
					MainWindowViewModel.dbContext.SaveChanges();
					await MessageBoxManager.GetMessageBoxStandard("Редактирование", "Информация о партнере обновлена", ButtonEnum.Ok, Icon.Info).ShowAsync();
				}
				MainWindowViewModel.Instance.UserControl = new PartnersView();
			}
			catch
			{
				await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Проверьте правильность заполнения полей и попробуйте еще раз", ButtonEnum.Ok, Icon.Error).ShowAsync();
			}
		}

		[RelayCommand]
		public void GoBack() => MainWindowViewModel.Instance.UserControl = new PartnersView();
	}
}
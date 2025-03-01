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

        // ��������������� ���� ������������ ���� #F4E8D3.
        // ��� �������������� �������� ���� #67BA80.
        // ��������� ����(��������) ������ ��������������� ����������
    }
}
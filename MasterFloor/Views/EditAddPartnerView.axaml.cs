using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterFloor.Models;
using MasterFloor.ViewModels;

namespace MasterFloor.Views;

public partial class EditAddPartnerView : UserControl
{
    public EditAddPartnerView()
    {
		InitializeComponent();
		DataContext = new EditAddPartnerViewModel();
	}

    public EditAddPartnerView(int IdPartner)
	{
		InitializeComponent();
		DataContext = new EditAddPartnerViewModel(IdPartner);
    }
}
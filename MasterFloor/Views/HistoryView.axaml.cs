using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterFloor.Models;
using MasterFloor.ViewModels;

namespace MasterFloor.Views;

public partial class HistoryView : UserControl
{
    public HistoryView()
    {
        InitializeComponent();
	}
	public HistoryView(Partner partner)
	{
		InitializeComponent();
		DataContext = new HistoryViewModel(partner);
	}
}
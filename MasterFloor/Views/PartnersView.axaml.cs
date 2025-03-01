using System.ComponentModel.DataAnnotations;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterFloor.ViewModels;

namespace MasterFloor.Views;

public partial class PartnersView : UserControl
{
    public PartnersView()
    {
        InitializeComponent();
        DataContext = new PartnersViewModel();
    }
}
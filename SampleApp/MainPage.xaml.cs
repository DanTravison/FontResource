using SampleApp.Resources;
using Shared.Resources;
using System.Collections.ObjectModel;

namespace SampleApp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        BindingContext = new ObservableCollection<FontItem>()
        {
            new(fontFamily:"OpenSansRegular", text:"Test text"),
            new(fontFamily:"OpenSansSemibold", text:"Test text."),
            new(fontFamily:nameof(FluentUI), text:FluentUI.CallConnectingFilled),
            new(fontFamily:nameof(Material), text:Material.Keyboard)
        };
        InitializeComponent();
    }
}

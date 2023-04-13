using MAUI.GPT.ViewModels;

namespace MAUI.GPT.Views;

public partial class MainView : ContentPage
{

	public MainView(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}


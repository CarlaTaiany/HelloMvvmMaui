using HelloMvvmMaui.ViewModels;
namespace HelloMvvmMaui
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();

            //Define o contexto de dados da View (MainPage.xaml) para o ViewModel (MainViewModel.cs)
            BindingContext = new ViewModels.MainViewModel(); 
        }

        
    }
}

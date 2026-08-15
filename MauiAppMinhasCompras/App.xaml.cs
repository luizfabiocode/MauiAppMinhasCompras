using Microsoft.Extensions.DependencyInjection;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Comente ou remova esta linha se não quiser mais o AppShell
            // return new Window(new AppShell());

            // Use esta linha para iniciar com sua página ListaProduto
            return new Window(new NavigationPage(new Views.ListaProduto()));
        }
    }
}
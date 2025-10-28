namespace Projekt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            GoToAsync("//Home"); // strona z routem "Home" otworzy sie pierwsza
        }
    }
}

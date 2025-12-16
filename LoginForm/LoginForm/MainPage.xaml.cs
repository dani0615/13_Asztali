namespace LoginForm
{
    public partial class MainPage : ContentPage
    {
        static List<Users> user = new List<Users>()
        {
            
               new Users { Nev ="tibor" , Jelszo="erosjelszo123" },
               new Users { Nev ="sandor" , Jelszo="sanyika01" },
               new Users { Nev ="lacigaming" , Jelszo="fortnite69" }
        };

        public MainPage()
        {
            InitializeComponent(); 
        }



        private async void btnBelépés_Clicked(object sender, EventArgs e)
        {
            string beirtNev = entNev.Text.Trim();
            string beirtJelszo = entPassword.Text.Trim();

            foreach (Users felhasznalo in user)
            {
                if (felhasznalo.Nev == beirtNev)
                {
                    if (felhasznalo.Jelszo == beirtJelszo)
                    {
                        DisplayAlert("Sikeres", $"Üdvözöllek, {felhasznalo.Nev}!", "OK");
                        await Shell.Current.GoToAsync("NewPage1");
                        return;
                    }
                    else
                    {
                        DisplayAlert("Hiba", "Hibás jelszó!", "OK");
                    }
                    return; 
                }
            }

            DisplayAlert("Hiba", "Nem létezik ilyen felhasználónév!", "OK");
        }
    }
}

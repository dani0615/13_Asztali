using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CukraszdaWPF
{
    public class Sutemenyek : INotifyPropertyChanged
    {
        public string Suti { get; set; }
        public int Ar { get; set; }

        private bool _kivalasztva;
        public bool Kivalasztva
        {
            get => _kivalasztva;
            set { _kivalasztva = value; OnPropertyChanged(); }
        }

        private int _adag;
        public int Adag
        {
            get => _adag;
            set { _adag = value < 0 ? 0 : value; OnPropertyChanged(); }
        }

        public string NevAr => $"{Suti}({Ar} Ft)";

        public Sutemenyek(string sor)
        {
            var adatok = sor.Split(';');
            Suti = adatok[0].Trim();
            Ar = int.Parse(adatok[1].Trim());
            Kivalasztva = false;
            Adag = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
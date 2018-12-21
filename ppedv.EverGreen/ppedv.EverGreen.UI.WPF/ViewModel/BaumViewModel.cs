using ppedv.EverGreen.Logic;
using ppedv.EverGreen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.EverGreen.UI.WPF.ViewModel
{
    public class BaumViewModel : ViewModelBase
    {
        public ObservableCollection<Tannenbaum> BaumListe { get; set; }

        public List<Herkunft> HerkunftList { get; set; }
        public List<BaumArt> Arten { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public Tannenbaum SelectedBaum
        {
            get => _selectedBaum;
            set
            {
                _selectedBaum = value;

                OnPropChanged(nameof(SelectedBaum));
                OnPropChanged(nameof(HöheInFuß));
            }
        }

        public double HöheInFuß
        {
            get
            {
                if (SelectedBaum == null)
                    return -1;

                return SelectedBaum.Height * 100 * 3.2808;
            }
        }

        Core core = new Core();
        private Tannenbaum _selectedBaum;

        public BaumViewModel()
        {
            BaumListe = new ObservableCollection<Tannenbaum>(core.Repository.GetAll<Tannenbaum>());
            HerkunftList = new List<Herkunft>(core.Repository.GetAll<Herkunft>());
            Arten = new List<BaumArt>(core.Repository.GetAll<BaumArt>());

            SaveCommand = new RelayCommand(o => core.Repository.Save());
            NewCommand = new RelayCommand(UserWantsToAddNewBaum);
        }

        private void UserWantsToAddNewBaum(object obj)
        {
            var nb = new Tannenbaum() { Height = 9999 };
            core.Repository.Add(nb);
            BaumListe.Add(nb);
            SelectedBaum = nb;
        }
    }
}

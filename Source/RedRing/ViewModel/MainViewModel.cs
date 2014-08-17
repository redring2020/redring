using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ‹óŠÔ ƒ‚ƒfƒ‹ { get;private set; }

        public MainViewModel()
        {
            ƒ‚ƒfƒ‹ = new ‹óŠÔ();

            —§•û‘Ì‚ð’Ç‰Á‚·‚é = new RelayCommand(() => ƒ‚ƒfƒ‹.—§•û‘Ì‚ð’Ç‰Á‚·‚é());
        }

        public RelayCommand —§•û‘Ì‚ð’Ç‰Á‚·‚é { get;private set; }
    }
}
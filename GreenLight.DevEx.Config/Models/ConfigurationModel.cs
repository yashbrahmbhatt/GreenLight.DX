using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Models
{
    public class ConfigurationModel : INotifyPropertyChanged
    {
        private string _name = "Config";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<SettingRowModel> Settings { get; } = new ObservableCollection<SettingRowModel>() { new SettingRowModel() };
        public ObservableCollection<AssetRowModel> Assets { get; } = new ObservableCollection<AssetRowModel>() { new AssetRowModel()};
        public ObservableCollection<ResourceRowModel> Resources { get; } = new ObservableCollection<ResourceRowModel>() { new ResourceRowModel()};

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

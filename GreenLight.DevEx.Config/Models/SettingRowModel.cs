using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Models
{
    public class SettingRowModel : ConfigurationRowModel
    {
        private string _value = "Value";
        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public SettingRowModel()
        {
        }
    }
}

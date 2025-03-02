using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Models
{
    public class AssetRowModel : ConfigurationRowModel
    {
        private string _assetName = "AssetName";
        public string AssetName
        {
            get => _assetName;
            set
            {
                if (_assetName != value)
                {
                    _assetName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _assetFolder = "AssetFolder";
        public string AssetFolder
        {
            get => _assetFolder;
            set
            {
                if (_assetFolder != value)
                {
                    _assetFolder = value;
                    OnPropertyChanged();
                }
            }
        }

        public AssetRowModel()
        {
        }
    }
}

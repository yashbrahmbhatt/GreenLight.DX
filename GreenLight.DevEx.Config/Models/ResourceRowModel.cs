using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Models
{
    public class ResourceRowModel : ConfigurationRowModel
    {
        private string _path = "Path";
        public string Path
        {
            get => _path;
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _folder = "Folder";
        public string Folder
        {
            get => _folder;
            set
            {
                if (_folder != value)
                {
                    _folder = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _bucket = "Bucket";
        public string Bucket
        {
            get => _bucket;
            set
            {
                if (_bucket != value)
                {
                    _bucket = value;
                    OnPropertyChanged();
                }
            }
        }

        public ResourceRowModel()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Docs
{
    public abstract class BaseEditor
    {
        public string FilePath { get; set; }
        public string FileName { get { return Path.GetFileNameWithoutExtension(FilePath); } }
    }
}

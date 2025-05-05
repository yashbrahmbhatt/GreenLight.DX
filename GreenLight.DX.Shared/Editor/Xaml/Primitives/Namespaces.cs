using GreenLight.DX.Shared.Editor.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GreenLight.DX.Shared.Editor.Xaml.Primitives
{
    public class Namespaces
    {
        private List<XElement>? NamespacesElementList => Document.Root?.Descendants().First(e => e.Name.LocalName == LocalNames.Namespaces).Descendants().Where(d => d.Name.LocalName.ToString() == "String").ToList();
        public List<string>? Values
        {
            get
            {
                return NamespacesElementList?.Select(r => r.Value).ToList();
            }
            set
            {
                if (value != null)
                {
                    var ReferenceParent = Document.Root?.Elements().First();
                    ReferenceParent?.RemoveNodes();
                    foreach (var namespaceVal in value)
                    {
                        var newElement = new XElement(
                            NamespaceNames.X + "String",
                            namespaceVal
                        );
                        ReferenceParent?.Add(newElement);
                    }
                }
            }
        }

        private XDocument Document { get; set; }
        public Namespaces(XDocument element)
        {
            Document = element;
        }
    }
}

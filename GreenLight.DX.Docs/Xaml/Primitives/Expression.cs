using GreenLight.DX.Docs.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GreenLight.DX.Docs.Xaml.Primitives
{
    public class Expression
    {
        public string Type
        {
            get
            {
                if (Expression_TypeElement == null) return null;
                return Expression_TypeElement.Value;
            }
        }

        public string Path
        {
            get
            {
                var PathValue = ExpressionElement
                    .Ancestors().Reverse().Select(a => a.Name.LocalName + "[" + a.ElementsBeforeSelf().Count() + "]");
                return string.Join("/", PathValue);
            }
        }

        public string Value
        {
            get
            {
                return ExpressionElement.Value;
            }
            set
            {
                if (value == null)
                {
                    ExpressionElement.Value = "";
                    return;
                }
                ExpressionElement.Value = value;
            }
        }
        public string ActivityType
        {
            get
            {
                if (ActivityElement == null) return null;
                return ActivityElement.Name.LocalName;
            }
        }
        public string ActivityName
        {
            get
            {
                if (Activity_NameElement == null) return null;
                return Activity_NameElement.Value;
            }
        }
        private XElement ActivityElement
        {
            get
            {
                return XDocumentHelpers.GetClosestParentWithAttribute(ExpressionElement, LocalNames.DisplayName);
            }
        }
        private XAttribute Activity_NameElement
        {
            get
            {
                return XDocumentHelpers.GetAttribute(ActivityElement, LocalNames.DisplayName);
            }
        }
        private XElement ExpressionElement { get; set; }
        private XAttribute Expression_TypeElement
        {
            get
            {
                return XDocumentHelpers.GetAttribute(ExpressionElement, LocalNames.ExpressionType);
            }
        }
        public Expression(XElement element)
        {
            ExpressionElement = element;
        }
    }
}
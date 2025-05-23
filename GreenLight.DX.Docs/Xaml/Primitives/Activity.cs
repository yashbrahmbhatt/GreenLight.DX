﻿using GreenLight.DX.Docs.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GreenLight.DX.Docs.Xaml.Primitives
{
    public class Activity
    {
        public string Id
        {
            get
            {
                return IdElement.Value.Replace("`", "");
            }
            set
            {
                IdElement.Value = value;
            }
        }

        public string Name
        {
            get
            {
                return NameElement.Value;
            }
            set
            {
                NameElement.Value = value;
            }
        }
        public string Description
        {
            get
            {
                return DescriptionElement != null ? DescriptionElement.Value : "";
            }
            set
            {
                if (DescriptionElement != null)
                {
                    if (value != null)
                        DescriptionElement.Value = value;
                    else
                        DescriptionElement.Remove();
                }
                else
                {
                    if (value != null)
                        ActivityElement.Add(new XAttribute(LocalNames.Description, value));
                }
            }
        }
        public string Type
        {
            get
            {
                return ActivityElement.Name.LocalName;
            }
        }

        public XElement ActivityElement { get; }
        private XAttribute IdElement => ActivityElement.Attribute("{http://schemas.microsoft.com/netfx/2010/xaml/activities/presentation}" + LocalNames.IdRef) ?? throw new Exception("Could not find activity's id element.");
        private XAttribute DescriptionElement => XDocumentHelpers.GetAttribute(ActivityElement, LocalNames.Description);
        private XAttribute NameElement => XDocumentHelpers.GetAttribute(ActivityElement, LocalNames.DisplayName) ?? throw new Exception("Could not find activity's name element");

        public Activity(XElement activity)
        {
            ActivityElement = activity;
        }

        public void Remove()
        {
            ActivityElement.Remove();
        }
    }
}

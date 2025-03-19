using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public partial class ConfigurationViewModel
    {
        public void ValidateUniqueKeys()
        {
            var allKeys = Settings.Select(s => s.Key)
                .Concat(Assets.Select(a => a.Key))
                .Concat(Resources.Select(r => r.Key));

            var duplicateKeys = allKeys.GroupBy(k => k)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var setting in Settings) setting.RemoveError(nameof(setting.Key), $"Duplicate key");
            foreach (var asset in Assets) asset.RemoveError(nameof(asset.Key), $"Duplicate key");
            foreach (var resource in Resources) resource.RemoveError(nameof(resource.Key), $"Duplicate key");

            foreach (var key in duplicateKeys)
            {
                // Add error to relevant view models
                var settings = Settings.Where(s => s.Key == key);
                if (settings.Any())
                    foreach (var setting in settings) setting.AddError(nameof(setting.Key), $"Duplicate key");

                var assets = Assets.Where(a => a.Key == key);
                if (assets.Any())
                    foreach (var asset in assets) asset.AddError(nameof(asset.Key), $"Duplicate key");

                var resources = Resources.Where(r => r.Key == key);
                if (resources.Any())
                    foreach (var resource in resources) resource.AddError(nameof(resource.Key), $"Duplicate key");
            }
        }

        protected void ValidateRequired(object value, string propertyName)
        {
            var message = Studio.Resources.ValidationMessages.Property_Required.Replace("{PropertyName}", propertyName);
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                AddError(propertyName, message);
            }
            else
            {
                RemoveError(propertyName, message);
            }
            OnPropertyChanged(nameof(HasErrors));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class MainWindowViewModel
    {
        private void ValidateUniqueNames()
        {
            var duplicateNames = Configurations
                .GroupBy(c => c.Model.Name)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            Debug("Validating unique configuration names", "ValidateUniqueNames");
            foreach (var config in Configurations)
            {
                if (duplicateNames.Contains(config.Name))
                {
                    config.AddError(nameof(config.Name), $"Duplicate configuration name");
                }
                else
                {
                    config.RemoveError(nameof(config.Name), $"Duplicate configuration name");
                }
            }

        }
    }
}

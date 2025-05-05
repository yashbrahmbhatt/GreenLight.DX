using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.ViewModels
{
    public partial class ConfigurationViewModel
    {

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Count != 0;

        public void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }
            _errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Remove(error);
                if (_errors[propertyName].Count == 0)
                {
                    _errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
            }
        }
        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName == null) return Enumerable.Empty<string>();
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : new List<string>();
        }


        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));

        }
    }
}

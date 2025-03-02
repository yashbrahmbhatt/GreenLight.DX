using GreenLight.DX.Commands;
using GreenLight.DX.Events;
using GreenLight.DX.Misc;
using GreenLight.DX.Models;
using Prism.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.ViewModels
{
    public abstract class ConfigurationRowViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly IEventAggregator _eventAggregator;
        public ConfigurationRowModel Model { get; protected set; }
        [Required(ErrorMessage = "Key is required.")]
        public string Key
        {
            get => Model.Key;
            set
            {

                Model.Key = value;
                OnPropertyChanged();

            }
        }
        [Required(ErrorMessage = "Description is required.")]
        public string Description
        {
            get => Model.Description;
            set
            {

                Model.Description = value;
                OnPropertyChanged();

            }
        }
        [Required(ErrorMessage = "Type is required.")]
        public Type SelectedType
        {
            get => Model.SelectedType;
            set
            {

                Model.SelectedType = value;
                OnPropertyChanged();

            }
        }

        public ICommand DeleteRowCommand { get; }
        protected ConfigurationRowViewModel(IEventAggregator eventAggregator, ConfigurationRowModel model)
        {
            _eventAggregator = eventAggregator;
            Model = model;
            DeleteRowCommand = new RelayCommand(OnDelete);
        }

        protected virtual void OnDelete()
        {
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent>().Publish(this);
        }

        // ... INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // INotifyDataErrorInfo Implementation
        public readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Any();

        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName == null) return Enumerable.Empty<string>();
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : new List<string>();
        }

        protected void ValidateProperty(object value, string propertyName)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = propertyName }, validationResults);

            if (validationResults.Any())
            {
                _errors[propertyName] = validationResults.Select(vr => vr.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            OnErrorsChanged(propertyName); // Call the helper method
        }

        // Helper method to raise the ErrorsChanged event
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}

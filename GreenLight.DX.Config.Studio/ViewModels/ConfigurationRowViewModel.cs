using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Services;
using GreenLight.DX.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public abstract class ConfigurationRowViewModel<T> : INotifyPropertyChanged, INotifyDataErrorInfo where T : ConfigItem
    {
        public readonly IEventAggregator _eventAggregator;
        public readonly ITypeParserService _typeParserService;

        private ObservableCollection<Type> _supportedTypes;
        public ObservableCollection<Type> SupportedTypes
        {
            get => _supportedTypes;
            set
            {
                if (_supportedTypes != value)
                {
                    _supportedTypes = value;
                    OnPropertyChanged();
                }
            }
        }
        private T _model;
        public T Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Key
        {
            get => Model.Key;
            set
            {
                if (Model.Key != value)
                {
                    Model.Key = value;
                    OnPropertyChanged();
                    ValidateRequired(value, nameof(Key));
                }
            }
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged();
                    ValidateRequired(value, nameof(Description));
                }
            }
        }
        public string Value
        {
            get => Model.Value;
            set
            {
                if (Model.Value != value)
                {
                    Model.Value = value;
                    OnPropertyChanged();
                    ValidateRequired(value, nameof(Value));
                    ValidateValueAndType();
                }
            }
        }

        public Type SelectedType
        {
            get => Model.ValueType;
            set
            {
                if (Model.ValueType != value)
                {
                    Model.ValueType = value;
                    OnPropertyChanged();
                    ValidateRequired(value, nameof(SelectedType));
                    ValidateValueAndType();
                }
            }
        }

        public ICommand DeleteRowCommand { get; }
        public int Row { get; set; }

        protected ConfigurationRowViewModel(IServiceProvider services, T model, int row)
        {
            _eventAggregator = services.GetRequiredService<IEventAggregator>();
            _typeParserService = services.GetRequiredService<ITypeParserService>();
            SupportedTypes = new ObservableCollection<Type>(_typeParserService.GetSupportedTypes());
            _model = model;
            DeleteRowCommand = new RelayCommand(RaiseRowDeletedEvent);
            Row = row;
        }

        protected virtual void RaisePropertyChangedEvent(string? propertyName)
        {
            if(_eventAggregator == null) return;
            _eventAggregator.GetEvent<ConfigurationRowPropertyChangedEvent<T>>().Publish(new ConfigurationRowPropertyChangedEventArgs<T>()
            {
                ViewModel = this,
                EventArgs = new PropertyChangedEventArgs(propertyName)
            });
        }

        protected virtual void RaiseRowDeletedEvent()
        {
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<T>>().Publish(this);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if(propertyName != null && propertyName != nameof(HasErrors)) RaisePropertyChangedEvent(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // INotifyDataErrorInfo Implementation
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Count != 0;
        public void AddError(string propertyName, string error)
        {
            if (!_errors.TryGetValue(propertyName, out var errors))
            {
                _errors[propertyName] = new List<string> { error };
            } else
            {
                _errors[propertyName].Add(error);
            }
            OnErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName, string error)
        {
            if (_errors.TryGetValue(propertyName, out var errors))
            {
                // Construct a regular expression from the error template
                string regexPattern = "^" + Regex.Replace(Regex.Escape(error).Replace("\\{","{").Replace("\\}","}"), @"\{[^}]*\}", ".*") +"$"; // Replace anything between {} with .*

                Regex regex = new Regex(regexPattern);

                // Find and remove matching errors
                var matchingErrors = errors.Where(e => regex.IsMatch(e)).ToList();

                foreach (var matchingError in matchingErrors)
                {
                    errors.Remove(matchingError);
                }

                if (errors.Count == 0)
                {
                    _errors.Remove(propertyName);
                }

                if (matchingErrors.Count > 0) // Only raise event if any errors were removed.
                {
                    OnErrorsChanged(propertyName);
                }
            }
        }
        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName == null) return Enumerable.Empty<string>();
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : new List<string>();
        }

        protected void ValidateRequired(object value, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) return;
            var message = Resources.ValidationMessages.Property_Required.Replace("{PropertyName}", propertyName);
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (propertyName == nameof(Description)) return; // Description is not required
                AddError(propertyName, message);
            }
            else
            {
                RemoveError(propertyName, Resources.ValidationMessages.Property_Required);
            }
        }

        protected void ValidateValueAndType()
        {
            if (SelectedType == null || Value == null) return;
            _typeParserService.TryParse(Value, SelectedType, out var result);
            var message = Resources.ValidationMessages.Value_Type_Mismatch.Replace("{Value}", Value).Replace("{Type}", SelectedType.FullName);
            if (result == null)
            {
                AddError(nameof(Value), message);
                AddError(nameof(SelectedType), message);
            }
            else
            {
                RemoveError(nameof(Value), Resources.ValidationMessages.Value_Type_Mismatch);
                RemoveError(nameof(SelectedType), Resources.ValidationMessages.Value_Type_Mismatch);
            }
        }

        // Helper method to raise the ErrorsChanged event
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }
    }
}

using GreenLight.DX.Config.Studio.Events;
using GreenLight.DX.Config.Studio.Models;
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
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.Config.Studio.ViewModels
{
    public abstract class ConfigurationRowViewModel<T> : INotifyPropertyChanged, INotifyDataErrorInfo where T : ConfigurationRowModel
    {
        private readonly IEventAggregator _eventAggregator;
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
                    ValidateProperty(value, nameof(Key));
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
                    ValidateProperty(value, nameof(Description));
                }
            }
        }

        public Type SelectedType
        {
            get => Model.SelectedType;
            set
            {
                if (Model.SelectedType != value)
                {
                    Model.SelectedType = value;
                    OnPropertyChanged();
                    ValidateProperty(value, nameof(SelectedType));
                }
            }
        }

        public ICommand DeleteRowCommand { get; }
        public int Row { get; set; }

        protected ConfigurationRowViewModel(IServiceProvider services, T model, int row)
        {
            _eventAggregator = services.GetRequiredService<IEventAggregator>();
            _model = model;
            DeleteRowCommand = new RelayCommand(RaiseRowDeletedEvent);
            Row = row;
        }

        protected virtual void RaisePropertyChangedEvent(string? propertyName)
        {
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
            if(propertyName == nameof(Key)) RaisePropertyChangedEvent(nameof(Key));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // INotifyDataErrorInfo Implementation
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Count != 0;
        public void AddError(string propertyName, string error)
        {
            if (!_errors.TryGetValue(propertyName, out _))
            {
                List<string>? errors = new List<string>();
                _errors[propertyName] = errors;
            } else
            {
                _errors[propertyName].Add(error);
            }
            OnErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName, string error)
        {
            if (_errors.TryGetValue(propertyName, out var errors) && errors.Contains(error))
            {
                errors.Remove(error);
                if (errors.Count == 0)
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

        protected void ValidateProperty(object value, string propertyName)
        {
            ValidateRequired(value, propertyName);
        }

        protected void ValidateRequired(object value, string propertyName)
        {
            var message = Resources.ValidationMessages.Property_Required.Replace("{PropertyName}", propertyName);
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (propertyName == nameof(Description)) return; // Description is not required
                AddError(propertyName, message);
            }
            else
            {
                RemoveError(propertyName, message);
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

﻿using GreenLight.DX.Config.Studio.Events;
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

        [Required(ErrorMessage = "Key is required.")]
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

        [Required(ErrorMessage = "Description is required.")]
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

        [Required(ErrorMessage = "Type is required.")]
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

        protected ConfigurationRowViewModel(IServiceProvider services, T model, PropertyChangedEventHandler propertyChanged, int row)
        {
            _eventAggregator = services.GetService<IEventAggregator>();
            Model = model;
            PropertyChanged += propertyChanged;
            DeleteRowCommand = new AsyncRelayCommand(OnDelete);
            Row = row;
        }

        protected virtual async Task OnDelete()
        {
            _eventAggregator.GetEvent<ConfigurationRowDeletedEvent<T>>().Publish(this);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
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
                errors = new List<string>();
                _errors[propertyName] = errors;
            }
            if (!errors.Contains(error))
            {
                errors.Add(error);
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

            OnErrorsChanged(propertyName);
        }

        // Helper method to raise the ErrorsChanged event
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }
    }
}

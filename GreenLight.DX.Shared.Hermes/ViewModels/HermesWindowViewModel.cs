using GreenLight.DX.Shared.Commands;
using GreenLight.DX.Shared.Hermes.Models;
using GreenLight.DX.Shared.Hermes.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using UiPath.Studio.Api.Theme;

namespace GreenLight.DX.Shared.Hermes.ViewModels
{
    public class HermesWindowViewModel : INotifyPropertyChanged
    {
        private readonly IHermesService _logService;
        public ListCollectionView FilteredLogs { get; }

        public ObservableCollection<SelectableItemViewModel<LogLevel>> LogLevels { get; }
        public ObservableCollection<SelectableItemViewModel<string>> Contexts { get; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    RefreshDisplay();
                }
            }
        }

        private int _theme;

        public ICommand ClearCommand { get; }
        public ICommand ExportCommand { get; }

        public HermesWindowViewModel(HermesService service, int theme)
        {
            _logService = service;
            _theme = theme;
            _searchText = string.Empty;

            FilteredLogs = (ListCollectionView)CollectionViewSource.GetDefaultView(_logService.Logs);

            LogLevels = new ObservableCollection<SelectableItemViewModel<LogLevel>>(
                Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>().Select(level =>
                {
                    var item = new SelectableItemViewModel<LogLevel> { Value = level, IsSelected = true };
                    item.PropertyChanged += (sender, e) => RefreshDisplay();
                    return item;
                }));

            Contexts = new ObservableCollection<SelectableItemViewModel<string>>();
            UpdateContexts();

            // Subscribe to changes in LogLevels and Contexts
            _logService.Logs.CollectionChanged += Logs_CollectionChanged;
            LogLevels.CollectionChanged += LogLevels_CollectionChanged;
            Contexts.CollectionChanged += Contexts_CollectionChanged;
            PropertyChanged += MainWindowViewModel_PropertyChanged;

            // Commands
            ClearCommand = new RelayCommand(ClearLogs);
            ExportCommand = new RelayCommand(ExportLogs);
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            RefreshDisplay();
        }

        private void Contexts_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshDisplay();
        }

        private void LogLevels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshDisplay();
        }

        private void Logs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateContexts();
        }
        private void UpdateContexts()
        {
            // Use a HashSet to track unique contexts efficiently
            var uniqueContexts = new HashSet<string>();

            foreach (var log in _logService.Logs)
            {
                uniqueContexts.Add(log.Context);
            }

            var existingContexts = Contexts.Select(c => c.Value).ToHashSet();


            // Clear existing contexts (but preserve selections if possible)
            var selectedContexts = Contexts.Where(c => c.IsSelected).Select(c => c.Value).ToHashSet();
            Contexts.Clear();

            foreach (var context in uniqueContexts)
            {
                var alreadyExisted = existingContexts.Contains(context);
                var wasSelected = selectedContexts.Contains(context);
                var contextOptions = new SelectableItemViewModel<string> { Value = context, IsSelected = alreadyExisted ? wasSelected : true };
                contextOptions.PropertyChanged += (sender, e) => RefreshDisplay();
                Contexts.Add(contextOptions);
            }


            RefreshDisplay(); // Refresh the log display after updating contexts
        }
        public void AddContext(string context)
        {
            if (Contexts.Any(c => c.Value == context)) return;
            Contexts.Add(new SelectableItemViewModel<string> { Value = context, IsSelected = true });
        }

        public void RefreshDisplay()
        {
            FilteredLogs.Filter = item =>
            {
                if (!(item is LogMessage log)) return false;

                return LogLevels.Any(ll => ll.Value == log.Level && ll.IsSelected) &&
                       Contexts.Any(c => c.Value == log.Context && c.IsSelected) &&
                       (string.IsNullOrEmpty(SearchText) || log.Message.ToLower().Contains(SearchText.ToLower()));
            };
            FilteredLogs.SortDescriptions.Clear();
            FilteredLogs.SortDescriptions.Add(new SortDescription("Timestamp", ListSortDirection.Descending));
            FilteredLogs.Refresh();
        }

        public Brush GetColorForLevel(LogLevel level) => level switch
        {
            LogLevel.Debug => _theme == (int)ThemeType.Light ? Brushes.Blue : Brushes.DodgerBlue,
            LogLevel.Info => _theme == (int)ThemeType.Light ? Brushes.Black : Brushes.White,
            LogLevel.Warning => Brushes.Orange,
            LogLevel.Error => Brushes.Red,
            _ => Brushes.Black,
        };

        private void ClearLogs()
        {
            _logService.Logs.Clear();
            RefreshDisplay();
        }

        private void ExportLogs()
        {
            var logContent = string.Join(Environment.NewLine, FilteredLogs.SourceCollection.Cast<LogMessage>().Select(log => log.ToString()));

            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (dialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(dialog.FileName, logContent);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
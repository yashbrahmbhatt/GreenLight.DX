using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreenLight.DX.Shared.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _executeAsync;
        private readonly Func<bool>? _canExecute;
        private bool _isExecuting; // Flag to track execution state

        public AsyncRelayCommand(Func<Task> executeAsync, Func<bool>? canExecute = null)
        {
            _executeAsync = executeAsync;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !_isExecuting && (_canExecute == null || _canExecute()); // Check _isExecuting
        }

        public async Task ExecuteAsync(object? parameter) // Add an async ExecuteAsync method
        {
            if (_isExecuting) return; // Prevent concurrent executions

            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty); // Update CanExecute state

            try
            {
                await _executeAsync();
            }
            finally
            {
                _isExecuting = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty); // Update CanExecute state
            }
        }

        public void Execute(object? parameter)
        {
            // Don't await here; let the async method handle it.
            _ = ExecuteAsync(parameter); // Fire and forget (intentional)
        }
    }
}

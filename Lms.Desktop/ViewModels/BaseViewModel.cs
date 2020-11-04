using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Navigation;
using Lms.Core;

namespace Lms.Desktop.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        protected readonly ValidationContext ValidationContext;
        protected readonly NavigationService NavigationService;

        protected string GetFirstPropertyError(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);

            var propertyValue = property?.GetValue(this);

            if (propertyValue is null) return string.Empty;

            var validationResults = new List<ValidationResult>();
            var valueValid = Validator.TryValidateValue(
                propertyValue,
                new ValidationContext(propertyValue),
                validationResults,
                property
                    .GetCustomAttributes()
                    .OfType<ValidationAttribute>()
                    .ToList());
            return valueValid ? string.Empty : validationResults.First().ErrorMessage;
        }

        protected string GetFirstGlobalError()
        {
            var validationResults = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(this, ValidationContext, validationResults);
            return valid ? string.Empty : validationResults.First().ErrorMessage;
        }

        protected BaseViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            ValidationContext = new ValidationContext(this);
        }

        protected static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Error => GetFirstGlobalError();

        public string this[string propertyName] => GetFirstPropertyError(propertyName);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class BaseViewModel<TEntity> : BaseViewModel where TEntity : class, new()
    {
        public TEntity Entity { get; }

        protected BaseViewModel(NavigationService navigationService) : base(navigationService)
        {
            Entity = new TEntity();
        }
    }
}
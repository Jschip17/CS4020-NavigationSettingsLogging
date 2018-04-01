using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace NavigationSettingsLogging.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Value = "Designtime value";
            }
        }

        string _Value = "Gas";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        //public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        //{
        //    if (state.Any())
        //    {

        //    }
        //    var key = parameter as string;

        //    if (SessionState.ContainsKey(key))
        //    {
        //        // Just use it
        //    }
        //    else
        //    {
        //        // Hard way
        //    }

        //    return base.OnNavigatedToAsync(parameter, mode, state);
        //}

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        //public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        //{
        //    if (suspending)
        //    {
        //        pageState["FirstName"] = "";
        //    }
        //    return base.OnNavigatedFromAsync(pageState, suspending);
        //}

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        //public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        //{
        //    args.Cancel = true;
        //    return base.OnNavigatingFromAsync(args);
        //}

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), Value);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

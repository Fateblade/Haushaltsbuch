using System;
using System.Windows;
using Infrastructure.Mappings;
using Prism.Ioc;
using Prism.Ninject;

namespace UI.Haushaltsbuch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App :  PrismApplication
    {
        public App()
        {
        }

        protected override Window CreateShell()
        {
            return new Shell();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            new KernelInitializer().Initialize(containerRegistry, Container);
        }


        //https://www.davidbritch.com/2013/06/changing-default-conventions-used-in.html
        protected override void ConfigureViewModelLocator() //view and viewmodel have to be in the same folder (XXX.xaml XXXViewModel.cs)
        {
            base.ConfigureViewModelLocator();
            Prism.Mvvm.ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                (viewType) =>
                {
                    string viewModelTypeName = $"{viewType.Namespace}.{viewType.Name}ViewModel, {viewType.Assembly}";
                    Type viewModelType = Type.GetType(viewModelTypeName);
                    return viewModelType;
                }
                );
        }
    }
}

namespace Haushaltsbuch 
{
    //Shell.g.cs will not compile without this. something went wrong in the refactoring to UI.Haushaltsbuch
}
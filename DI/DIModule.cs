namespace EquationDraw.DI
{
    /// <summary>
    /// My DI Module
    /// </summary>
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            // Binding the MainWindow
            Bind<IStartupWindow>().To<MainWindow>().InSingletonScope();

            // Di Bindings
            Bind<IUIProvider>().To<UIProvider>().InSingletonScope();
        }
    }
}

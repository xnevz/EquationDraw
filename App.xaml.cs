using Ninject;
using System.Windows;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IReadOnlyKernel DIKernel { get; set; }

        public App()
        {
            // init app components
            InitializeComponent();

            // Initialising the DI
            DIKernel = new KernelConfiguration(new DI.DIModule()).BuildReadonlyKernel();

            // main window
            var mWindow = DIKernel.Get<IStartupWindow>();

            // setting the main window
            Current.MainWindow = (Window)mWindow;

            // show the main window
            mWindow.ShowWindow();
        }
    }
}

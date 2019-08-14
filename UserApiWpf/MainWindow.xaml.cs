using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserApiWpf.Mapping;
using UserApiWpf.Model;
using UserApiWpf.View;
using UserApiWpf.ViewModel;

namespace UserApiWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected IKernel kernel;

        protected UserProperties _userProps;

        protected AuthView _authView;
        public MainWindow()
        {
            InitializeComponent();
            Init();

        }
        public void Init()
        {
            kernel = new StandardKernel(new NinjectMappings());

            _userProps = kernel.Get<UserProperties>();
            _authView = kernel.Get<AuthView>();

            this.Content = _authView;

            (_authView.DataContext as AuthViewModel).OnSuccessAuth += OnSuccessAuth;
        }

        private void OnSuccessAuth(object sender, EventArgs e)
        {
            this.Title = _userProps.Name;
        }
    }
}

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
using UserApiWpf.ViewModel;

namespace UserApiWpf.View
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class AuthView : UserControl
    {
        public AuthView(AuthViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

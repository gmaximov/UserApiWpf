using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserApiWpf.Infrastructure;
using UserApiWpf.Model;
using UserApiWpf.Service;

namespace UserApiWpf.ViewModel
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private AuthService _service;

        public AuthViewModel(AuthService service)
        {
            _service = service;
            apiPath = "https://localhost:44395/";
        }
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private string apiPath;
        public string ApiPath
        {
            get { return apiPath; }
            set
            {
                apiPath = value;
                OnPropertyChanged("ApiPath");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public event EventHandler OnSuccessAuth;

        public RelayCommand SignInCommand => new RelayCommand(async obj =>
                  {
                      var result = await _service.Authenticate(login, password, apiPath);
                      if (result) OnSuccessAuth?.Invoke(this, null);
                  });
  
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

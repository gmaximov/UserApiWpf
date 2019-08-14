using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApiWpf.Infrastructure;
using UserApiWpf.Model;
using UserApiWpf.Service;
using UserApiWpf.View;
using UserApiWpf.ViewModel;

namespace UserApiWpf.Mapping
{
    public class NinjectMappings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<UserProperties>().ToSelf().InSingletonScope();
            Bind<ConnectionHandler>().ToSelf().InSingletonScope();

            Bind<AuthService>().ToSelf().InTransientScope();

            Bind<AuthViewModel>().ToSelf().InTransientScope();
            Bind<AuthView>().ToSelf().InTransientScope();
        }
    }
}

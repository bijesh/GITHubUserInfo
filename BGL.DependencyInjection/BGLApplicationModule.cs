using BGL.Services;
using BGL.Services.Interface;
using BGL.Services.Interface.Config;
using BGL.Services.Interface.Utilities;
using BGL.Services.Interface.ViewModelFactory;
using BGL.Services.Interface.ViewModelService;
using BGL.Services.ViewModelFactory;
using BGL.Services.ViewModelService;
using BGL.Utilities;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.DependencyInjection
{
    public class BGLApplicationModule : NinjectModule
    {
        public override void Load()
        {
            LoadUtilities();
            LoadConfigs();
            LoadServices();
            LoadViewModelFactories();
            LoadViewModelServices();
        }

        private void LoadUtilities()
        {
            Bind<IWebApiClient>().To<WebApiClient>().InRequestScope();
        }
        private void LoadConfigs()
        {            
            Bind<IGitHubRepoConfig>().To<GitHubRepoConfig>().InRequestScope();
        }
        private void LoadServices()
        {            
           
            Bind<IGitHubRepoService>().To<GitHubRepoService>().InSingletonScope();
            Bind<IGitHubUserInfoService>().To<GitHubUserInfoService>().InSingletonScope();
        }
        private void LoadViewModelFactories()
        {
            Bind<IGitHubUserViewModelFactory>().To<GitHubUserViewModelFactory>().InRequestScope();
        }
        private void LoadViewModelServices()
        {
            Bind<IGitHubUserViewModelService>().To<GitHubUserViewModelService>().InRequestScope();
        }

    }
}

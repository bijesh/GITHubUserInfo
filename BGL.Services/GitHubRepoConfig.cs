using BGL.Services.Interface.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services
{
   public class GitHubRepoConfig : IGitHubRepoConfig
    {
        private readonly string gitHubUserApiUrl;
        public GitHubRepoConfig()
        {
            this.gitHubUserApiUrl = ConfigurationManager.AppSettings["GitHubUserApi"];
        }
        public GitHubRepoConfig(string gitHubUserApiUrl)
        {
            this.gitHubUserApiUrl = gitHubUserApiUrl;
        }
        public string GitHubUserApiUrl
        {
            get
            {
               return gitHubUserApiUrl;
            }
        }


    }
}

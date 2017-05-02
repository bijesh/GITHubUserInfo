using BGL.Services.Contract;
using BGL.Services.Interface;
using BGL.Services.Interface.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BGL.Services.Interface.Utilities;

namespace BGL.Services
{
    public class GitHubUserInfoService : IGitHubUserInfoService
    {
       private readonly IWebApiClient client;
       private readonly IGitHubRepoConfig config;
       public GitHubUserInfoService(IWebApiClient client, IGitHubRepoConfig config)
       {
            this.client = client;
            this.config = config;
       }

        public async Task<GitUser> GetGitUserinfo(string gitUserName)
        {
            if(string.IsNullOrEmpty(gitUserName))
            {
                throw new ArgumentNullException("Invalid user Name");
            }
            return await this.client.GetAsync<GitUser>(string.Format(config.GitHubUserApiUrl, gitUserName));
        }
              
    }
}

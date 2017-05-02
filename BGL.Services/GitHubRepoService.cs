using BGL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGL.Services.Contract;
using BGL.Services.Interface.Config;
using System.Net.Http;
using BGL.Services.Interface.Utilities;

namespace BGL.Services
{
   public class GitHubRepoService : IGitHubRepoService
    {
        private readonly IWebApiClient client;
        public GitHubRepoService(IWebApiClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<GitRepository>> GetGitRepositoryInfo(string repoUrl)
        {
            if (string.IsNullOrEmpty(repoUrl))
            {
                throw new ArgumentNullException("Invalid repository URL");
            }

            return await this.client.GetAsync<IEnumerable<GitRepository>>(repoUrl);
        }
    }
}

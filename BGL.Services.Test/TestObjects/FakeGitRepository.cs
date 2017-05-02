using BGL.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.TestObjects
{
   public static class FakeGitRepository
    {
        internal static List<GitRepository> gitRepositoryList = new List<GitRepository>() {
                                                                                           new GitRepository {
                                                                                                               name="capistrano-rails-server",
                                                                                                               stargazers_count=200
                                                                                                            },
                                                                                            new GitRepository {
                                                                                                               name="commented",
                                                                                                               stargazers_count=400
                                                                                                            },
                                                                                             new GitRepository {
                                                                                                               name="cogno",
                                                                                                               stargazers_count=300
                                                                                                            },
                                                                                               new GitRepository {
                                                                                                               name="country-codes",
                                                                                                               stargazers_count=500
                                                                                                            },
                                                                                                 new GitRepository {
                                                                                                               name="crowdsourcedhomepage",
                                                                                                               stargazers_count=600
                                                                                                            },
                                                                                            };
    }
}

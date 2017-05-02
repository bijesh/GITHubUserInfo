using BGL.Services.Interface;
using BGL.Services.Interface.ViewModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BGLMVC.Controllers
{
    public class GitHubUsersController : Controller
    {
        private readonly IGitHubUserViewModelService gitHubUserViewModelService;
        public GitHubUsersController(IGitHubUserViewModelService gitHubUserViewModelService)
        {
            this.gitHubUserViewModelService = gitHubUserViewModelService;

        }

        // GET: GitHubUsers
        public ActionResult Index()
        {
            return View("Index");
        }

        public async virtual Task<ActionResult> GetUser(string userName)
        {
            //if( string.IsNullOrEmpty(userName))
            //{
            //    throw new ArgumentNullException("Empty UserName");
            //}
            var gitHubUser = await this.gitHubUserViewModelService.GetGitHubUser(userName);
            
            return View("GetUser",gitHubUser);
        }
    }
}
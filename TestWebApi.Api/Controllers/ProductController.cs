using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApi.AuthenticationFilter;

namespace TestWebApi.Api.Controllers
{
    public class AuthenticationFilter: AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
        }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class ProductController : ApiController
    {
        #region Get

        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage Get()
        {
            var products = new List<Product>()
            {
                new Product() {Id=1,Title="Product1" },
                new Product() {Id=2,Title="Product2" }
            };
            return Request.CreateResponse(HttpStatusCode.OK, new { products = products });
        }

        #endregion
    }
}
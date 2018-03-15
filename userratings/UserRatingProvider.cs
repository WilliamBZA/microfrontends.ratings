using ITOps.Composition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace userratings
{
    public class UserRatingProvider : IProvideData
    {
        public bool Matches(RouteData routeData, HttpRequest request)
        {
            var controller = ((string)routeData.Values["controller"]).ToLowerInvariant();
            var action = ((string)routeData.Values["action"]).ToLowerInvariant();

            return controller == "data" && request.Query.ContainsKey("moviedetails");
        }

        public Task PopulateData(dynamic viewModel, RouteData routeData, HttpRequest request)
        {
            viewModel.userRating = "1 / 10";

            return Task.CompletedTask;
        }
    }
}
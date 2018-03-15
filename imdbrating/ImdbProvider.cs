using IMDBCore;
using ITOps.Composition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace imdbrating
{
    public class ImdbProvider : IProvideData
    {
        static Random random = new Random();

        public bool Matches(RouteData routeData, HttpRequest request)
        {
            var controller = ((string)routeData.Values["controller"]).ToLowerInvariant();
            var action = ((string)routeData.Values["action"]).ToLowerInvariant();

            return controller == "data" && request.Query.ContainsKey("moviedetails");
        }

        public async Task<string> GetImdbRating(string movieId)
        {
            var imdb = new Imdb("8c75101");
            var movie = await imdb.GetMovieAsync(movieId);

            return movie.ImdbRating;
        }

        public async Task PopulateData(dynamic viewModel, RouteData routeData, HttpRequest request)
        {
            if (random.Next(5) == 1)
            {
                throw new Exception("Boooom!");
            }

            viewModel.imdbRating = await GetImdbRating(request.Query["moviedetails"]);
            viewModel.userRating = "1 / 10";
        }
    }
}
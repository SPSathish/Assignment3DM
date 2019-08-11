using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Xamarin.Forms;
using AssignmentDM3.Models;

namespace AssignmentDM3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var client = new GraphQLClient("http://swapi.apis.guru/");
            GraphQLRequest graphQLRequest = new GraphQLRequest
            {
                Query = "query{ allFilms { films {id, title, director } } }"
            };
            GraphQLResponse graphQLReponse = await client.PostAsync(graphQLRequest);
            filmList.ItemsSource = graphQLReponse.Data.allFilms.films.ToObject<List<film>>();

        }
    }
}

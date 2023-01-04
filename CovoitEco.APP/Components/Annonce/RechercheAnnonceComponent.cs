﻿using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Annonce
{
    public class RechercheAnnonceComponent : BaseComponent
    {
        
        //public AnnonceRechercheFormular requestAnnonceRechercheFormular { get; set; } = new AnnonceRechercheFormular();

        //[Inject]
        //public IAnnonceQueriesService AnnonceQueries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            responseAnnonce = await AnnonceQueries.GetAnnonceRecherche(requestAnnonceRechercheFormular.departureDate, requestAnnonceRechercheFormular.departureCity, requestAnnonceRechercheFormular.arrivalCity);
        }
    }
}

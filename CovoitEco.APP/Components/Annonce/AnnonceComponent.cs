using System.Reflection.Metadata;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Annonce.Commands;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;


namespace CovoitEco.APP.Components.Annonce
{
    public class AnnonceComponent : BaseComponent
    {
        
        //public AnnonceProfileFormular requestAnnonceProfileFormular { get; set; } = new AnnonceProfileFormular(); // complete the request name


        //[Inject]
        //public IAnnonceQueriesService AnnonceQueries { get; set; }

        //[Inject]
        //public IAnnonceCommandsService AnnonceCommands { get; set; }



        /// <summary>
        /// add get id user current
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        protected override async Task OnInitializedAsync()
        {
            responseAnnonce = await AnnonceQueries.GetAllAnnonceProfile(1); // Id user current 
        }

        protected async Task CreateAnnonceProfile()
        {
            await SetIdVehCurrent();
            requestAnnonceProfileFormular.ANN_UTL_Id = 1; // to recuperate automatically 
            requestAnnonceProfileFormular.ANN_VEH_Id = idVehicule; // to recuperate automatically (always the current veh)
            await AnnonceCommands.CreateAnnonce(requestAnnonceProfileFormular);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.ServiceModel.Web;

namespace IceWAService
{
        [ServiceContract(Namespace = "http://student.mydesign.central.wa.edu.au/IceWA_Virtual")]
    public interface IIceWAService
    {

		[OperationContract]
            [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getGames")]
            IceWAService.Content getGames();

		[OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getVenue")]
		IceWAService.Content getVenue();

		[OperationContract]
		String[] getGamePeriods();

		

		[OperationContract]
		String[] getGameNotes();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getTeams")]
		IceWAService.Content getTeams();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getPerson")]
        IceWAService.Content getPerson();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getTeamPersonNumber/{id}")]
        IceWAService.Content getTeamPersonNumber(String id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getGameTeamPerson/{id}")]
        IceWAService.Content getGameTeamPerson(String id);

		[OperationContract]
		String[] getGamePersonAction();

		[OperationContract]
		String[] getGamePersonActionExtended();

		[OperationContract]
		String[] getGamePersonActionGoal();

		[OperationContract]
		String[] getInjuries();

		[OperationContract]
		String[] getCatagories();

		[OperationContract]
		String[] getPenalties();

		[OperationContract]
		String[] getRoles();

		[OperationContract]
		String[] getRoleIdentifiers();

		[OperationContract]
		String[] getIdentifier();

		[OperationContract]
		String[] getGameTeamGoalie();

		[OperationContract]
		String[] getTimeouts();

		[OperationContract]
		String[] getDivision();

		[OperationContract]
		String[] getSignoff();

		[OperationContract]
		String[] getPeriod();

		/*
        [OperationContract]
        List<String> returnTeams(string div);

        [OperationContract]
        List<String> getDivisions();

        [OperationContract]
        TempGameDetails returnGameDetails(int gameID);

        [OperationContract]
        List<TempGame> returnSchedule(DateTime date, string division);

        [OperationContract]
        List<TempPlayer> returnPlayers(Int32 teamID);

        [OperationContract]
        List<string> getPenaltyOptions(string type);

        [OperationContract]
        IDictionary<string, int> getPenaltyTypes();
            
        [OperationContract]
        List<TempPlayer> searchPlayers(string query);

        [OperationContract]
        string addGoals(List<TempGoal> goals); // as list obj

        [OperationContract]
        string addPenalties(List<TempPenalty> penalties); // as list obj
/*
        [OperationContract]
        string addInjuries(List<TempInjury> penalties); 
            **/
		/*
        [OperationContract]
        string insertPlayer(Int32 id, Int32 stupidID, Int32 teamID, string pos, int number, string name , string adress, string phone, string email, int parent, string dob);
		*/
            //injuries
            //notes
            //
    }
}

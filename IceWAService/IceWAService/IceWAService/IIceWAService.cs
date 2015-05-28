using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace IceWAService
{
        [ServiceContract]
    public interface IIceWAService
    {

		[OperationContract]
		string[] getGames();

		[OperationContract]
		String[] getVenue();

		[OperationContract]
		String[] getGamePeriods();

		

		[OperationContract]
		String[] getGameNotes();

		[OperationContract]
		String[] getTeams();

		[OperationContract]
		String[] getPerson();

		[OperationContract]
		String[] getTeamPersonNumber(int id);

		[OperationContract]
		String[] getGameTeamPerson(int id);

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

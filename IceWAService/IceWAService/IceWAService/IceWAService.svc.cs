using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;
using System.Web.Services;
using System.Data;
using System.Threading;
using System.Globalization;
using System.ServiceModel.Web;

//Done by jack kitchener

namespace IceWAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IceWAService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IceWAService.svc or IceWAService.svc.cs at the Solution Explorer and start debugging.
    public class IceWAService : IIceWAService
    {

		[WebMethod]
		public string[] getGames()
		{
			String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
			try
			{
				using (MySqlConnection cnn = new MySqlConnection(conString))
				{
					cnn.Open();

					String sql = String.Format("SELECT * FROM Game WHERE Date >= Convert(datetime,'"+DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+"');");
					// String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

					MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
					DataSet ds = new DataSet();
					da.Fill(ds, "Game");

					string[] returns = new string[1+(ds.Tables[0].Rows.Count*13)];
                    
					int pos = 0;

					foreach(DataRow row in ds.Tables[0].Rows)
					{
						returns[pos] = "[Game "+(pos/13)+1+"]";
                    	returns[pos+1] = "ID " + row[0].ToString();
                    	returns[pos+2] = "VENUE_ID " + row[1].ToString();
						returns[pos+3] = "HOME_TEAM_ID " + row[2].ToString();
						returns[pos+4] = "AWAY_TEAM_ID " + row[3].ToString();
						returns[pos+5] = "HOME_TEAM_MANAGER_ID " + row[4].ToString();
						returns[pos+6] = "AWAY_TEAM_MANAGER_ID " + row[5].ToString();
						returns[pos+7] = "REFEREE_ID " + row[6].ToString();
						returns[pos+8] = "LINESMAN_1_ID " + row[7].ToString();
						returns[pos+9] = "LINESMAN_2_ID " + row[8].ToString();
						returns[pos+10] = "SCOREKEEPER_ID " + row[9].ToString();
						returns[pos+11] = "DATE " + row[10].ToString();
						returns[pos+12] = "\n";
						pos+=13;
					}

					returns[pos+1] = "[END]";

                   

				


					/*
                    List<string> teamList = new List<string>();
                    teamList.Add(ds.Tables[0].Columns[0].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[4].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[1].ToString());
                    */

					// Restore original culture.
					
                    return returns;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
				return new String[]{"you fucked up"};
            }
		}

        [DataContract]
        public class Content
        {
            [DataMember]
            public string[] content { get; set; }
        }

		[WebMethod]
        
        public Content getVenue()
		{
            Content lols = new Content();
            lols.content = new String[] { "The databse is broken" };
            return lols;
			String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
			try
			{
				using (MySqlConnection cnn = new MySqlConnection(conString))
				{
					cnn.Open();

					String sql = String.Format("SELECT * FROM Venue;");
					// String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

					MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
					DataSet ds = new DataSet();
					da.Fill(ds, "Venue");

					string[] returns = new string[1+(ds.Tables[0].Rows.Count*10)];

					int pos = 0;

					foreach(DataRow row in ds.Tables[0].Rows)
					{
						returns[pos] = "["+row[1].ToString()+"]";
						returns[pos+1] = "ID " + row[0].ToString();
						returns[pos+2] = "NAME " + row[1].ToString();
						returns[pos+3] = "STREET " + row[2].ToString();
						returns[pos+4] = "SUBURB " + row[3].ToString();
						returns[pos+5] = "POSTCODE " + row[4].ToString();
						returns[pos+6] = "CITY " + row[5].ToString();
						returns[pos+7] = "STATE " + row[6].ToString();
						returns[pos+8] = "COUNTRY " + row[7].ToString();
						returns[pos+9] = "\n";
						pos+=10;
					}
					returns[pos] = "[END]";
                    Content lol = new Content();
                    lol.content = returns;
                    return lol;


				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
                Content lol = new Content();
                lol.content = new String[] { "you fucked up" };
				return lol;
			}

		}

		[WebMethod]
        public String[] getGamePeriods()
		{
            return null;
		}

		
	
		[WebMethod]
        public String[] getGameNotes()
		{
            return null;
		}

		[WebMethod]
        public String[] getTeams()
		{
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT * FROM Team;");
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Team");

                    string[] returns = new string[1 + (ds.Tables[0].Rows.Count * 6)];

                    int pos = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        returns[pos] = "[" + row[1].ToString() + "]";
                        returns[pos + 1] = "ID " + row[0].ToString();
                        returns[pos + 2] = "NAME " + row[1].ToString();
                        returns[pos + 3] = "IMAGE " + row[2].ToString();
                        returns[pos + 4] = "DIVISION_ID " + row[3].ToString();
                        returns[pos + 5] = "\n";
                        pos += 6;
                    }
                    returns[pos] = "[END]";
                    return returns;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return new String[] { "you fucked up" };
            }
		}

		[WebMethod]
        public String[] getPerson()
		{
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT * FROM Person;");
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Venue");

                    string[] returns = new string[1 + (ds.Tables[0].Rows.Count * 5)];

                    int pos = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        returns[pos] = "[" + row[1].ToString() + "]";
                        returns[pos + 1] = "ID " + row[0].ToString();
                        returns[pos + 2] = "NAME " + row[1].ToString();
                        returns[pos + 3] = "IDENTIFIER_ID " + row[2].ToString();
                        returns[pos + 4] = "\n";
                        pos += 4;
                    }
                    returns[pos] = "[END]";
                    return returns;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return new String[] { "you fucked up" };
            }
		}

		[WebMethod]
        public String[] getTeamPersonNumber(int id)
		{
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT Number FROM Team_Person_Number WHERE Id = '"+id+ "';");
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Venue");

                    string[] returns = new string[1 + (ds.Tables[0].Rows.Count * 5)];

                    int pos = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        returns[pos] = "[TEAM PERSON NYMBER]";
                        returns[pos + 1] = "ID " + row[0].ToString();
                        returns[pos + 2] = "NAME " + row[1].ToString();
                        returns[pos + 3] = "IDENTIFIER_ID " + row[2].ToString();
                        returns[pos + 4] = "\n";
                        pos += 4;
                    }
                    returns[pos] = "[END]";
                    return returns;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return new String[] { "you fucked up" };
            }
		}

		[WebMethod]
        public String[] getGameTeamPerson(int id)
		{
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT * FROM Person;");
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Venue");

                    string[] returns = new string[1 + (ds.Tables[0].Rows.Count * 5)];

                    int pos = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        returns[pos] = "[Person]";
                        returns[pos + 1] = "ID " + row[0].ToString();
                        returns[pos + 2] = "NAME " + row[1].ToString();
                        returns[pos + 3] = "IDENTIFIER_ID " + row[2].ToString();
                        returns[pos + 4] = "\n";
                        pos += 4;
                    }
                    returns[pos] = "[END]";
                    return returns;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return new String[] { "you fucked up" };
            }
		}

		[WebMethod]
        public String[] getGamePersonAction()
		{
            return null;
		}

		[WebMethod]
        public String[] getGamePersonActionExtended()
		{
            return null;
		}

		[WebMethod]
        public String[] getGamePersonActionGoal()
		{
            return null;
		}

		[WebMethod]
        public String[] getInjuries()
		{
            return null;
		}

		[WebMethod]
        public String[] getCatagories()
		{
            return null;
		}

		[WebMethod]
        public String[] getPenalties()
		{
            return null;
		}

		[WebMethod]
        public String[] getRoles()
		{
            return null;
		}

		[WebMethod]
        public String[] getRoleIdentifiers()
		{
            return null;
		}

		[WebMethod]
        public String[] getIdentifier()
		{
            return null;
		}

		[WebMethod]
        public String[] getGameTeamGoalie()
		{
            return null;
		}

		[WebMethod]
        public String[] getTimeouts()
		{
            return null;
		}

		[WebMethod]
        public String[] getDivision()
		{
            return null;
		}

		[WebMethod]
        public String[] getSignoff()
		{
            return null;
		}

		[WebMethod]
        public String[] getPeriod()
		{
            return null;
		}

		/*
        
        [WebMethod]
        public List<String> returnTeams(String div)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<String> teamList = new List<string>();

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();

                String sql = String.Format("SELECT name FROM team WHERE division =\"{0}\"", div);

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "teams");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    teamList.Add(Convert.ToString(dr["name"]));
                }
                
                return teamList;

            }


           // return "BlackHawks";
        }

        [WebMethod]
        public List<TempPlayer> returnPlayers(Int32 teamID)
        {

            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<TempPlayer> tempList = new List<TempPlayer>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT player_team.ID, c1.name, player_team.number FROM player_team INNER JOIN `contact` AS `c1` ON c1.ID = player_team.contact_ID WHERE player_team.team_ID = {0};", teamID);
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "player_team");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TempPlayer temp = new TempPlayer(
                            int.Parse(ds.Tables[0].Rows[i][0].ToString()),
                            ds.Tables[0].Rows[i][1].ToString(),
                            int.Parse(ds.Tables[0].Rows[i][2].ToString())

                        );
                        tempList.Add(temp);
                    }
                }
                    /*
                    List<string> teamList = new List<string>();
                    teamList.Add(ds.Tables[0].Columns[0].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[4].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[1].ToString());
                    */

                    // Restore original culture.
		/*
                    return tempList;


                }
            
            catch (Exception ex)
            {
                tempList.Add(new TempPlayer(-1,ex.StackTrace,-1));
                return tempList;
            }


           // return null;
        }

        [WebMethod]
        public List<string> getPenaltyOptions(string type)
        {

            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<string> list = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT offence FROM `penalty_type` WHERE type = \"{0}\";", type);
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "penalty_offence");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                       list.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
                /*
                List<string> teamList = new List<string>();
                teamList.Add(ds.Tables[0].Columns[0].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[4].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[1].ToString());
                */

                // Restore original culture.
		/*
                return list;


            }

            catch (Exception ex)
            {
                list.Add("Error");
                return list;
            }


            // return null;
        }

        [WebMethod]
        public IDictionary<string, int> getPenaltyTypes()
        {

            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            IDictionary<string, int> list = new Dictionary<string, int>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT DISTINCT type, time FROM `penalty_type`;");
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "penalty_type");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list.Add(ds.Tables[0].Rows[i][0].ToString(), int.Parse(ds.Tables[0].Rows[i][1].ToString()));
                    }
                }
                /*
                List<string> teamList = new List<string>();
                teamList.Add(ds.Tables[0].Columns[0].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[4].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[1].ToString());
                */

                // Restore original culture.
		/*
                return list;


            }

            catch (Exception ex)
            {
                list.Add("Error", 404);
                return list;
            }


            // return null;
        }

        [WebMethod]
        public List<TempPlayer> searchPlayers(string query,String username)
        {

            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<TempPlayer> tempList = new List<TempPlayer>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT player_team.ID, c1.name, player_team.number FROM player_team INNER JOIN `contact` AS `c1` ON c1.ID = player_team.contact_ID WHERE c1.name LIKE \"%{0}%\";", query);
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "player_team");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TempPlayer temp = new TempPlayer(
                            int.Parse(ds.Tables[0].Rows[i][0].ToString()),
                            ds.Tables[0].Rows[i][1].ToString(),
                            int.Parse(ds.Tables[0].Rows[i][2].ToString())

                        );
                        tempList.Add(temp);
                    }
                }
                /*
                List<string> teamList = new List<string>();
                teamList.Add(ds.Tables[0].Columns[0].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[4].ToString());
                teamList.Add(ds.Tables[0].Columns[3].ToString());
                teamList.Add(ds.Tables[0].Columns[1].ToString());
                */

                // Restore original culture.
		/*
                return tempList;


            }

            catch (Exception ex)
            {
                tempList.Add(new TempPlayer(-1, ex.StackTrace, -1));
                return tempList;
            }


            // return null;
        }

        [WebMethod]
        public string insertTeam(Int32 id, string name, Int32 managerID, Int32 managerID2, string division, Int32 coachID, Int32 coachID2)
        {
            String sql = "";
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {


                    cnn.Open();
                    sql = String.Format("Insert into team (ID, name, manager_ID, manager_ID2, division, coach_ID, coach_ID2) values ('{0}', '{1}','{2}', '{3}','{4}','{5}','{6}')", id, name, managerID, managerID2, division, coachID, coachID2);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [WebMethod]
        public string addGoals(List<TempGoal> tg)
        {
            String sql = "";
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    for (int i = 0; i < tg.Count; i++) { 
                        cnn.Open();
                    sql = String.Format("Insert into goals (ID, game_ID, team_ID, player_ID,period,time,player_assist_ID,player_assist_ID2) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",  tg[i].goalID, tg[i].gameID, tg[i].teamID, tg[i].playerID, tg[i].period, tg[i].eventTime, tg[i].assist1Player, tg[i].assist2Player);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                }
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /*
 * INSERT INTO `contact` VALUES (26,'testy testy',041402465,19191919,'test@test.com',null,STR_TO_DATE('16/11/2014', '%d/%m/%Y'));
 * INSERT INTO `player_team` VALUES (026,26,201,'fwd',9);
 * 
 **/
		/*
        [WebMethod]
        public string insertPlayer(Int32 id,Int32 stupidID,Int32 teamID,string pos,int number, string name, string adress, string phone, string email, int parent, string dob)
        {
            String sql = "";
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {


                    cnn.Open();
                    sql = String.Format("Insert into contact values ('{0}', '{1}','{2}', '{3}','{4}','{5}',STR_TO_DATE('{6}', '%d/%m/%Y'))", id, name, adress, phone, email, parent, dob);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();

                    sql = String.Format("INSERT INTO `player_team` VALUES ({0},{1},{2},'{3}',{4})", stupidID, id, teamID, pos, number);
                    cmd = new MySqlCommand(sql, cnn);  
                    cmd.ExecuteNonQuery();
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [WebMethod]
        public string addPenalties(List<TempPenalty> p)
        {
            String sql = "";
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    for (int i = 0; i < p.Count; i++) { 
                        cnn.Open();
                    sql = String.Format("Insert into penalties (ID, game_ID, team_ID, player_ID,period,time,offence,mins_given) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",p[i].penaltyID,p[i].gameID,p[i].teamID,p[i].playerID,p[i].period,p[i].eventTime,p[i].offence,p[i].minutes);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                }
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [WebMethod]
        public List<TempGame> returnSchedule(DateTime date ,string division) {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            // Change culture to en-US.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string mydate = date.ToShortDateString();

            List<TempGame> tempList = new List<TempGame>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID WHERE schedule.date = str_to_date(\"{0}\", '%m/%d/%Y') and t1.division = \"{1}\"", mydate,division);
                   // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");
                    
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "schedule");
                  
                    for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
                    {
                        TempGame temp = new TempGame(
                            int.Parse(ds.Tables[0].Rows[index][0].ToString()),
                            ds.Tables[0].Rows[index][1].ToString(),
                            ds.Tables[0].Rows[index][2].ToString(),
                            // Convert.ToDateTime(ds.Tables[0].Columns[3].ToString()),
                           Convert.ToDateTime(ds.Tables[0].Rows[index][3].ToString()),
                            ds.Tables[0].Rows[index][4].ToString()
                        );

                        tempList.Add(temp);
                    }
                    /*
                    List<string> teamList = new List<string>();
                    teamList.Add(ds.Tables[0].Columns[0].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[4].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[1].ToString());
                    */
					/*
                    // Restore original culture.
                    Thread.CurrentThread.CurrentCulture = originalCulture;
                    
                    return tempList;


                }
            }
            catch (Exception ex)
            {
                TempGame temp = new TempGame();
                temp.setfucked(mydate+":"+ex.StackTrace);

                tempList.Add(temp);
                return tempList;
            }

        }
        [WebMethod]
        public TempGameDetails returnGameDetails(int gameID){
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();

                    String sql = String.Format(
                        " SELECT t2.manager_ID, t1.manager_ID, manager2.name, manager1.name"+
                        ", schedule.homeID, schedule.awayID, myRef.name, myLine1.name, myLine2.name FROM"+
                        " `schedule` INNER JOIN `team` AS `t1` ON t1.ID = schedule.homeID INNER JOIN `team`"+
                        " AS `t2` ON t2.ID = schedule.awayID INNER JOIN `contact` AS `manager1` ON manager1.ID = t1.manager_ID"+
                        " INNER JOIN `contact` AS `manager2` ON manager2.ID = t2.manager_ID INNER JOIN `contact` AS `myLine1`"+
                        " ON myLine1.ID = schedule.linesman1ID INNER JOIN `contact` AS `myLine2` ON myLine2.ID = schedule.linesman2ID"+
                        " INNER JOIN `contact` AS `myRef` ON myRef.ID = schedule.refereeID WHERE schedule.ID= {0}", gameID);
                    // String sql = String.Format("SELECT schedule.ID, t1.name, t2.name, schedule.time, location.name FROM `schedule`  inner join `team` as `t1` on t1.id = schedule.homeID inner join `location` on location.ID = schedule.locationID inner join `team` as `t2` on t2.id = schedule.awayID;");

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "schedule");

                        TempGameDetails temp = new TempGameDetails(
                            int.Parse(ds.Tables[0].Rows[0][0].ToString()),
                            int.Parse(ds.Tables[0].Rows[0][1].ToString()),
                            ds.Tables[0].Rows[0][2].ToString(),
                            ds.Tables[0].Rows[0][3].ToString(),
                            int.Parse(ds.Tables[0].Rows[0][4].ToString()),
                            int.Parse(ds.Tables[0].Rows[0][5].ToString()),
                            ds.Tables[0].Rows[0][6].ToString(),
                            ds.Tables[0].Rows[0][6].ToString(),
                            ds.Tables[0].Rows[0][6].ToString()
                        );

                    
                    /*
                    List<string> teamList = new List<string>();
                    teamList.Add(ds.Tables[0].Columns[0].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[4].ToString());
                    teamList.Add(ds.Tables[0].Columns[3].ToString());
                    teamList.Add(ds.Tables[0].Columns[1].ToString());
                    */

                    // Restore original culture.
					/*
                    return temp;


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return null;
            }

        }



        [WebMethod]
        public List<String> getDivisions()
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<String> teamList = new List<string>();

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();

                String sql = String.Format("SELECT distinct division FROM team");

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "division");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    teamList.Add(Convert.ToString(dr["division"]));
                }

                return teamList;

            }


            // return "BlackHawks";
        }

*/




    }


}

        

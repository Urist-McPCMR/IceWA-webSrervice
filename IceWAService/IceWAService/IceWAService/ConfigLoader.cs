using System;
using System.Collections.Generic;
using System.IO;

namespace IceWAService
{
	public class ConfigLoader
	{

			private static Dictionary<string,string> tempHash = new Dictionary<string,string>();
			private static Dictionary<string, Dictionary<string,string>> _content;
		public static Dictionary<string, Dictionary<string,string>> content
		{
			get{return _content;}
			set{_content = value;}
		}

		public static void read(string file) 
			{
				
				content = new Dictionary<String, Dictionary<String,String>>();

				String tempSection = "";
				

			string[] lines = File.ReadAllLines(file);

				foreach(string liney in lines)
				{
				string line = liney;
				if(line.Equals(""))
						add(tempSection);
					if(line.Contains(";"))
						line = line.Substring( line.IndexOf(";")).ToString();
					if(line.Contains("[")&&line.Contains("]"))
						tempSection = line;
				if( !line.Equals("")&&!line.Contains("["))
						seperateKey(line);

				}

			}

        public static void readStrings(string[] lines)
        {

            content = new Dictionary<String, Dictionary<String, String>>();

            String tempSection = "";

            foreach (string liney in lines)
            {
                string line = liney;
                if (line.Equals(""))
                    add(tempSection);
                if (line.Contains(";"))
                    line = line.Substring(line.IndexOf(";")).ToString();
                if (line.Contains("[") && line.Contains("]"))
                    tempSection = line;
                if (!line.Equals("") && !line.Contains("["))
                    seperateKey(line);

            }

        }

		public static  Dictionary<String, Dictionary<String,String>> returnDictionary(string file) 
			{
				read(file);
				return content;
			}

			public static  ConfigContent returnConfigContent(string file) 
			{
				read(file);
				ConfigContent cfgContent = new ConfigContent(content);
				return cfgContent;
			}

            public static Dictionary<String, Dictionary<String, String>> returnDictionary(string[] file)
            {
                readStrings(file);
                return content;
            }

            public static ConfigContent returnConfigContent(string[] file)
            {
                readStrings(file);
                ConfigContent cfgContent = new ConfigContent(content);
                return cfgContent;
            }

			private static void seperateKey(String line){

			string key;
			string value;
			string[] keyValPair;
			keyValPair = line.Split(' ');

				key = keyValPair[0];
				value = keyValPair[1];

				if(keyValPair.Length>2)
					for(int i = 2; i < keyValPair.Length;i++)
						value+=" "+keyValPair[i];

			tempHash.Add(key.Trim(),value.Trim());
			}


			private static void add(String section)
			{
				content.Add(section.Replace("[","").Replace("]", "").Trim(),tempHash);
				tempHash = new Dictionary<String,String>();
			}
		
	}
}


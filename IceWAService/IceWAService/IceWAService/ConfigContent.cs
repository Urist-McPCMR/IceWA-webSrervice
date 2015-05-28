using System;
using System.Collections.Generic;

namespace IceWAService
{
	public class ConfigContent
	{
		private Dictionary<String,Dictionary<String,String>> _contentGlobal;
		private String sectionView = "";
		public Dictionary<String,Dictionary<String,String>> contentGlobal
		{
			get
			{
				return _contentGlobal;
			}
			set
			{
				_contentGlobal = value;
			}
		}


		public ConfigContent(Dictionary<String,Dictionary<String,String>> content)
		{
			contentGlobal = content;
		}

		public ConfigContent()
		{				

		}


		public string[] getKeys(string section){
			Dictionary<string,string> tempo; 
			contentGlobal.TryGetValue(section,out tempo);
			Object[] contentArray = new object[0];
			string[] keys = new string[0];
			tempo.Keys.CopyTo(keys,0);
			 keys= new string[contentArray.Length];
			int count = 0;
			foreach(Object str in contentArray)
			{
				keys[count] = str.ToString();
				count++;
			}
			return keys ;

		}

		public String[] getKeysFromSectionView(){
			Dictionary<string,string> tempo; 
			contentGlobal.TryGetValue(sectionView,out tempo);
			Object[] contentArray = new object[0];
			string[] keys = new string[0];
			tempo.Keys.CopyTo(keys,0);
			keys= new string[contentArray.Length];
			int count = 0;
			foreach(Object str in contentArray)
			{
				keys[count] = str.ToString();
				count++;
			}
			return keys ;
		}

		public String getValue(String section,String key){
			Dictionary<string,string> temp = new Dictionary<string,string>();
			if (contentGlobal.TryGetValue(section, out temp))
			{
				string ret="";
				temp.TryGetValue(key,out ret);
				return ret;
			}
			else
			{
				Console.WriteLine(" is not found.");
				return"not found";
			}

		}

		public void setSectionView(String section)
		{
			sectionView = section;
		}

		public String getValueFromSectionView(String key)
		{
			Dictionary<string,string> temp;
			contentGlobal.TryGetValue(sectionView,out temp);
			string ret;
			temp.TryGetValue(key,out ret);
			return ret;
		}

		public bool hasKeyInSection(String section,String key)
		{
			Dictionary<string,string> tempo; 
			contentGlobal.TryGetValue(section,out tempo);
			return tempo.ContainsKey (key);
		}

		public bool hasSection(String section)
		{
			return contentGlobal.ContainsKey(section);
		}
	}
}


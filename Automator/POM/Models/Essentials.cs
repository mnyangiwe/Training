using Newtonsoft.Json;
using System;
using System.IO;

namespace Automator.Framework.Data
{
    public class Essentials
    {
        private string siteUrl = ""; // field
        public string SiteUrl   // property
        {
            get { return siteUrl; }
            set { siteUrl = value; }
        }
        public Essentials basicData()
        {
            Essentials essentials=new Essentials();
            try
            {
                //getting file directory
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + @"Automator\POM\Data\SiteEssentials.json")));
                //coping json into the class
                essentials = JsonConvert.DeserializeObject<Essentials>(File.ReadAllText(directory.ToString()));
                return essentials;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return essentials;
        }
    }
}
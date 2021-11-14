using Newtonsoft.Json;
using System;
using System.IO;

namespace Automator.Framework.Data
{
    public class FormFillingTest
    {
        private string samplepagetest = "";
        private string selectDropdownMenu = "";
        private string profilePic = "";
        private string name = "";
        private string email = "";
        private string webSite = "";
        private string yearsOfExperience = "";
        private string[] skills = { };
        private string qualification = "";
        private string comment = "";
        private string[] images = { };
        private string countryName = "";
        public string ProfilePic { get => profilePic; set => profilePic = value; }
        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
        public string WebSite { get => webSite; set => webSite = value; }
        public string YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
        public string[] Skills { get => skills; set => skills = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Samplepagetest { get => samplepagetest; set => samplepagetest = value; }
        public string SelectDropdownMenu { get => selectDropdownMenu; set => selectDropdownMenu = value; }
        public string[] Images { get => images; set => images = value; }
        public string CountryName { get => countryName; set => countryName = value; }

        public FormFillingTest getTestData()
        {

            FormFillingTest test = new FormFillingTest();
           try{
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + @"Automator\POM\Data\TestInfor.json")));
                test = JsonConvert.DeserializeObject<FormFillingTest>(File.ReadAllText(directory.ToString()));
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return test;
        }
    }
}
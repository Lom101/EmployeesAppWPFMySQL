using EmployeesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Services
{
    class FileIOService
    {
        private string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<EmployeeModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<EmployeeModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<EmployeeModel>>(fileText);
            }
        }

        public void SaveData(object _employeeDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_employeeDataList); 
                writer.Write(output);
            }
        }
    }
}

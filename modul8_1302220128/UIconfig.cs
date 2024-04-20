using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302220128
{
    internal class UIconfig
    {
        public UIconfig()
        { 
            try
            {
                ReadConfig();
            }
            catch 
            {
                SetDefault();
                WriteConfig();
            }
        }
        public BankTransferConfig bankConfig;
        public void ReadConfig()
        {
            string text = File.ReadAllText("C:\\Users\\mrizk\\Documents\\Rizki\\Tugas\\Semester 4\\KPL\\jurnal\\modul8_1302220128\\modul8_1302220128\\bank_transfer_config.json");
            bankConfig = JsonSerializer.Deserialize<BankTransferConfig>(text);
        }
        public void WriteConfig()
        {
            var options = new
            JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(bankConfig, options);
            File.WriteAllText("C:\\Users\\mrizk\\Documents\\Rizki\\Tugas\\Semester 4\\KPL\\jurnal\\modul8_1302220128\\modul8_1302220128\\bank_transfer_config.json");
    }
        public void SetDefault()
        {
            List<string> method = new List<string>{"RTO(real - time)",
		"SKN",
		"RTGS",
		"BI FAST"};
            bankConfig = new
            BankTransferConfig("en", 25000000, 6500, 15000, method, "yes", "ya");
        }
        public void ChangeLang()
        {
            if(bankConfig.lang == "en")
            {
                bankConfig.lang = "id";
                WriteConfig();
            }
            else
            {
                bankConfig.lang = "en";
                WriteConfig();
            }
        }
}
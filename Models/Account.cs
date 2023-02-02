using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Password_Guardian.Models
{
    internal class Account
    {

        public string _name { get; set; }
        public string _password { get; set; }
        public string _username { get; set; }
        public string _card1Name { get; set; }
        public string _card1User { get; set; }
        public string _card1Pass { get; set; }
        public string _card2Name { get; set; }
        public string _card2User { get; set; }
        public string _card2Pass { get; set; }
        public string _card3Name { get; set; }
        public string _card3User { get; set; }
        public string _card3Pass { get; set; }
        public string _card4Name { get; set; }
        public string _card4User { get; set; }
        public string _card4Pass { get; set; }
        public string _card5Name { get; set; }
        public string _card5User { get; set; }
        public string _card5Pass { get; set; }


        public Account()
        {
        }

        public Account(string name, string username, string password)
        {
            _name = name;
            _username = username.ToLower().Trim();
            _password = password;
        }

        public void createPasscard(string name, string username, string password)
        {
            if (_card1Name == null)
            {
                _card1Name = name;
                _card1User = username;
                _card1Pass = password;
            }
            else if (_card2Name == null)
            {
                _card2Name = name;
                _card2User = username;
                _card2Pass = password;
            }
            else if (_card3Name == null)
            {
                _card3Name = name;
                _card3User = username;
                _card3Pass = password;
            }
            else if (_card4Name == null)
            {
                _card4Name = name;
                _card4User = username;
                _card4Pass = password;
            }
            else if (_card5Name == null)
            {
                _card5Name = name;
                _card5User = username;
                _card5Pass = password;
            }
        }

        public bool Login(string username, string password)
        {
            if (username.ToLower().Trim() == _username && password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void SaveAccount(Account account)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            await SecureStorage.Default.SetAsync("Account", JsonSerializer.Serialize(account, options));
        }
    }
}

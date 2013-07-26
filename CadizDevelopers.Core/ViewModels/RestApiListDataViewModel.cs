using CadizDevelopers.Core.Model;
using CadizDevelopers.Core.Utils;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CadizDevelopers.Core.ViewModels
{
    public class RestApiListDataViewModel : MvxViewModel
    {
        public RestApiListDataViewModel()
        {
            GetData();
        }

        #region Properties

        private List<User> m_users;

        public List<User> Users
        {
            get { return m_users; }
            set 
            { 
                m_users = value;
                this.UsersSearched = value;
            }
        }

        private List<User> m_usersSearched;

        public List<User> UsersSearched
        {
            get { return m_usersSearched; }
            set 
            { 
                m_usersSearched = value;
                RaisePropertyChanged(() => this.UsersSearched);
            }
        }

        private string m_searchTerm;

        public string SearchTerm
        {
            get { return m_searchTerm; }
            set { m_searchTerm = value; }
        }


        #endregion

        #region Command

        public ICommand SearchCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    this.UsersSearched = this.Users.Where(x => x.Name.Contains(this.SearchTerm)).ToList();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.ShowViewModel<AddUserViewModel>();
                    });
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        GetData();
                    });
            }
        }

        #endregion

        #region Methods

        private void GetData()
        {
            new HttpCalls().Get(
                "http://cadizdevelopersapi.herokuapp.com/users",
                (stream) =>
                {
                    var reader = new StreamReader(stream);
                    string rawUsers = reader.ReadToEnd();

                    var values = JObject.Parse(rawUsers);

                    var a = values.ToString();

                    //this.Users = new ParserApi().ParseUser(JObject.Parse(rawUsers).ToList());
                },                    
                (exception) =>                    
                {
                    //TODO: Handle with exception   
                    
                });
        }

        #endregion



    }
}

using CadizDevelopers.Core.Resources;
using CadizDevelopers.Core.Services;
using CadizDevelopers.Core.Services.Interfaces;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using CadizDevelopers.Core.ExtensionMethods;

namespace CadizDevelopers.Core.ViewModels
{
    public class FacebookListDataViewModel : MvxViewModel
    {        
        #region Services

        private IFacebookService m_facebookService;

        #endregion

        #region Constructor

        public FacebookListDataViewModel(IFacebookService facebookService)
        {
            m_facebookService = Mvx.GetSingleton<IFacebookService>();            
        }

        private void GetData()
        {
            m_facebookService.GetGraph(
                new FacebookRouting().GetGroups(this.GroupId),                
                (data) =>
                {
                    var what = data;
                    var wtf = (List<object>)what["data"];

                    List<FacebookTip> tips = new List<FacebookTip>();

                    foreach (object obj in wtf)
                    {
                        var a = JObject.Parse(obj.ToString());

                        string userName = a.SelectToken("from").SelectToken("name").Value<string>();
                        string message = a.SelectToken("message").ValueOrDefault<string>();

                        if (message == null)
                        {
                            message = string.Empty;
                        }

                        tips.Add(new FacebookTip() { User = userName, Message = message });
                    }

                    this.Tips = tips;
                },                    

                (error) =>                  
                {
                    //Please mens haven't exceptions...
                });

        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            this.OptionName = parameters.Data["Option"];

            if (this.OptionName == "CadizDevelopers")
            {
                this.GroupId = AppResources.CadizDeveloperId;
            }
            else if(this.OptionName == "CadizDevelopersJobs")
            {
                this.GroupId = AppResources.CadizDeveloperJobsId;
            }

            GetData();
        }

        #endregion

        #region Properties

        private string m_option;

        public string OptionName
        {
            get { return m_option; }
            set 
            { 
                m_option = value;
                this.RaisePropertyChanged(() => this.OptionName);
            }
        }

        private string m_groupId;

        public string GroupId
        {
            get { return m_groupId; }
            set { m_groupId = value; }
        }

        private List<FacebookTip> m_tips;

        public List<FacebookTip> Tips
        {
            get { return m_tips; }
            set 
            { 
                m_tips = value;
                this.ElementsListed = value;
            }
        }

        private List<FacebookTip> m_elementsListed;

        public List<FacebookTip> ElementsListed
        {
            get { return m_elementsListed; }
            set 
            { 
                m_elementsListed = value;
                this.RaisePropertyChanged(() => this.ElementsListed);
            }
        }
        
        private string m_searchText;

        public string SearchText
        {
            get { return m_searchText; }
            set 
            {
                m_searchText = value;
                RaisePropertyChanged(() => this.SearchText);
            }
        }

        #endregion

        #region Command

        public ICommand SearchCommand
        {
            get
            {
                return new MvxCommand(() =>                    
                {
                    this.ElementsListed = this.Tips.Where(x => x.Message.ToLower().Contains(m_searchText.ToLower())).ToList();
                });
            }
        }

        #endregion




    }
}

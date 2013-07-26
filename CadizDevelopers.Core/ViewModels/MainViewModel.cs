using CadizDevelopers.Core.Model;
using CadizDevelopers.Core.Services.Interfaces;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace CadizDevelopers.Core.ViewModels
{
    public class MainViewModel 
		: MvxViewModel
    {

        #region Services

        IMvxFileStore m_fileStore;

        #endregion

        #region Constructor

        public MainViewModel(IMvxFileStore fileStore)
        {
            m_options = new List<string>() {"CadizDeveloper" , "CadizDeveloperJobs" , "Users"};

            m_fileStore = fileStore;

            var data = new DataFile(m_fileStore);
            data.Read();

            if (string.IsNullOrEmpty(data.AccessTokenFacebook) == true)
            {
                IFacebookService service = Mvx.GetSingleton<IFacebookService>();

                if (string.IsNullOrEmpty(service.AccessToken) == true)
                {
                    this.ShowViewModel<FacebookLoginViewModel>();
                }
                else
                {
                    data.AccessTokenFacebook = service.AccessToken;
                }                
            }            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents the aviable options
        /// </summary>
        private List<string> m_options;

        public List<string> Options
        {
            get { return m_options; }
            set { m_options = value; }
        }

        #endregion

        #region Commands

        public ICommand OptionSelectedCommand
        {
            get
            {
                return new MvxCommand<string>((option) =>
                    {
                        MvxBundle bundle = new MvxBundle();
                        
                        if (option == "CadizDeveloper")
                        {                            
                            bundle.Data.Add("Option" , "CadizDevelopers");
                            this.ShowViewModel<FacebookListDataViewModel>(bundle);                           
                        }
                        else if (option == "CadizDeveloperJobs")
                        {                            
                            bundle.Data.Add("Option", "CadizDevelopersJobs");
                            this.ShowViewModel<FacebookListDataViewModel>(bundle);
                        }
                        else if (option == "Users")
                        {
                            bundle.Data.Add("Option", "Users");
                            this.ShowViewModel<RestApiListDataViewModel>(bundle);
                        }
                    });
            }
        }

        #endregion
    }
}

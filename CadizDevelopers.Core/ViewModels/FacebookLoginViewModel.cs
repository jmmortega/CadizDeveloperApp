

using CadizDevelopers.Core.Services.Interfaces;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CadizDevelopers.Core.ViewModels
{
    public class FacebookLoginViewModel : MvxViewModel
    {
        #region Fields

        private readonly IFacebookService m_facebookService;
        
        #endregion

        #region Constructor

        public FacebookLoginViewModel()
        {
            m_facebookService = Mvx.GetSingleton<IFacebookService>();
        }

        public FacebookLoginViewModel(IFacebookService facebookService)
        {
            m_facebookService = facebookService;
        }

        #endregion

        #region Properties

        public Uri LoginUri
        {
            get
            {
                return m_facebookService.AuthenticateUri();
            }
        }

        private static Type m_goBefore;

        public static Type GoBefore
        {
            get { return m_goBefore; }
            set { m_goBefore = value; }
        }

        private bool m_ProgressBarVisibility;

        public bool ProgressBarVisibility
        {
            get { return m_ProgressBarVisibility; }
            set 
            { 
                m_ProgressBarVisibility = value;
                RaisePropertyChanged(() => this.ProgressBarVisibility);
            }
        }
        
        #endregion

        #region Commands

        public ICommand ProcessUriCommand
        {
            get
            {
                return new MvxCommand<Uri>(uri =>
                    {
                        this.ProgressBarVisibility = true;

                        m_facebookService.GetAccessToken(uri,
                        (login) =>
                        {
                            if (m_goBefore == null)
                            {                                                                
                                this.Close(this);                                
                            }
                            else
                            {                                                                
                                MvxBundle bundle = new MvxBundle();                                
                                bundle.Data.Add("from", "FB");
                                bundle.Data.Add("AccessToken", login.AccessToken);
                                bundle.Data.Add("User", login.Id.ToString());
                                this.ShowViewModel(m_goBefore , bundle);                                
                            }
                        },                            
                        (error) =>                           
                        {
                            //TODO: Do something...
                        });                                                                                                
                    });
            }
        }
        
        public ICommand RequestLoadComplete
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.ProgressBarVisibility = false;
                    });
            }
        }
        
        #endregion        
    }
}

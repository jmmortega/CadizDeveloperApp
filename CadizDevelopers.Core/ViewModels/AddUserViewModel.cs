
using CadizDevelopers.Core.Utils;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CadizDevelopers.Core.ViewModels
{
    public class AddUserViewModel : MvxViewModel
    {
        #region Fields

        private IMvxPictureChooserTask m_pictureChooser;

        #endregion

        #region Constructor

        public AddUserViewModel(IMvxPictureChooserTask pictureChooser)
        {
            m_pictureChooser = pictureChooser;
        }

        #endregion

        #region Properties

        private string m_userName;

        public string UserName
        {
            get { return m_userName; }
            set { m_userName = value; }
        }

        private string m_mail;

        public string Mail
        {
            get { return m_mail; }
            set { m_mail = value; }
        }

        private Stream m_image;

        public Stream Image
        {
            get { return m_image; }
            set { m_image = value; }
        }

        private string m_message;

        public string Message
        {
            get { return m_message; }
            set 
            { 
                m_message = value;
                this.RaisePropertyChanged(() => this.Message);
            }
        }

        
        #endregion

        #region Commands

        public ICommand FromCamera
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        m_pictureChooser.TakePicture(400, 95, (stream) => { m_image = stream; }, () => { });
                    });
            }
        }

        public ICommand FromGallery
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        m_pictureChooser.ChoosePictureFromLibrary(400, 95, (stream) => { m_image = stream; }, () => { });
                    });
            }
        }


        public ICommand AddImageCommand
        {
            get
            {
                return new MvxCommand<bool>((fromCamera) =>
                    {
                        if (fromCamera == true)
                        {
                            m_pictureChooser.TakePicture(400, 95, (stream) => { m_image = stream; }, () => { });
                        }
                        else
                        {
                            m_pictureChooser.ChoosePictureFromLibrary(400, 95, (stream) => { m_image = stream; }, () => { });
                        }
                    });
            }
        }

        private const string c_saveUser = "http://cadizdevelopersapi.herokuapp.com/Add?name={0}&mail={1}";        

        public ICommand SaveCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        new HttpCalls().Post(
                            string.Format(c_saveUser, new object[] { this.UserName, this.Mail }),
                            "x-www-form-urlencoded",
                            (stream) =>
                            {
                                this.Message = "Saved";
                                this.Close(this);
                            },
                            (error) =>
                            {
                                this.Message = error.Message;   
                            });                        
                    });
            }
        }
        
        #endregion


    }
}

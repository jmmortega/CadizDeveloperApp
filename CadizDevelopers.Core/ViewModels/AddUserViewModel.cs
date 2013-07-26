
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
        
        #endregion

        #region Commands

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

        public ICommand SaveCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        //Send post with data.
                    });
            }
        }
        
        #endregion


    }
}

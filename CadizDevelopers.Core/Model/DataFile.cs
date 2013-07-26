using Cirrious.MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Model
{
    public class DataFile 
    {
        #region Consts

        private const string c_DataFileName = "Datafile.cdz";

        #endregion

        #region Fields

        private IMvxFileStore m_fileStore;

        #endregion

        #region Constructor

        public DataFile(IMvxFileStore fileStore)
        {
            m_fileStore = fileStore;
        }

        #endregion

        #region Properties
                
        private string m_accessTokenFacebook = string.Empty;

        public string AccessTokenFacebook
        {
            get { return m_accessTokenFacebook; }
            set 
            { 
                m_accessTokenFacebook = value;
                this.Write();
            }
        }
                        
        #endregion

        #region Methods

        #region IO Actions

        public Exception Read()
        {
            string content;

            try
            {
                bool ok = m_fileStore.TryReadTextFile(c_DataFileName, out content);
                this.ParsingData(content);

                if (ok == false)
                {
                    throw new IOException();
                }
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        public Exception Write()
        {
            string content = this.PrepareContentToWrite();

            try
            {                
                m_fileStore.WriteFile(c_DataFileName, content);                
            }
            catch(Exception e)
            {
                return e;
            }

            return null;
        }

        public Exception Write(string content)
        {
            try
            {
                m_fileStore.WriteFile(c_DataFileName, content);
                this.ParsingData(content);
            }
            catch (Exception e)
            {
                return e; 
            }

            return null;
        }

        public bool Exists()
        {

            return m_fileStore.Exists(c_DataFileName);
        }

        public Exception Delete()
        {
            try
            {
                m_fileStore.DeleteFile(c_DataFileName);                
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        #endregion

        private void ParsingData(string content)
        {
            string[] values = content.Split(';');
            
            this.AccessTokenFacebook = values[0];
        }

        private string PrepareContentToWrite()
        {
            string content = string.Empty;
            
            content += this.AccessTokenFacebook.ToString() + ";";

            return content;
        }

        #endregion    
    
        


    

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign
{
    // (a) Interface for page
    public interface PageWorker
    {
        void LoadPage(string pathToPage);
    }

    // (b.i) Interface for element
    public interface ILoggable
    {
        void Log(string login, string password);
    }

    // (b) Abstract class for element
    public abstract class ElementWorker : ILoggable
    {
        public string PathLogin { get; set; }
        public string PathPassword { get; set; }
        public string ButtonName { get; set; }

        void ILoggable.Log(string login, string password)
        {
            SetText(login, PathLogin);
            SetText(password, PathPassword);
            Click(ButtonName);
        }

        public abstract void Click(string buttonName);

        public abstract void SetText(string text, string xPath);

        // (c) Override toString
        public override string ToString()
        {
            return String.Format("Login: {0}, password:{1}, button:{2}", PathLogin, PathPassword, ButtonName);
        }
    }

    // (d) WebDriver initialisation abstract class
    public abstract class DriverInitialisation
    {
        // (d.iii) Browsers enumeration
        public enum Browsers {};

        // (d.i) Check browsers type
        public abstract void SwitchCase(string browserName);

        // (d.ii) Read config file and add browser to enum
        public abstract void BrowserName(string configFile);
    }

    // (e) Class for a logger
    public abstract class Log
    {
        public string PathLogFile { get; set; }

        public abstract void LogWriter();
    }

    // (f) Read config interface 
    interface IReadConfig {
        void Read(string filePath);
    }

    // (f.i) DBWorker
    public abstract class DBWorker
    {
        private string filePath;
        public string ConfigString { get; set; }

        public abstract void Read(string filePath);
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public class ProjectConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("environments", IsDefaultCollection = false)]
        public ProjectConfigCollection Configs
        {
            get
            {
                return (ProjectConfigCollection)base["environments"];
            }
        }
    }

    public class ProjectConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProjectConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProjectConfigElement)element).Name;
        }
    }

    public class ProjectConfigElement : ConfigurationElement
    {
        private List<string> dbhandlerBackupConnections = new List<string>();

        public ProjectConfigElement(string name, string display)
        {
            Name = name;
            Display = display;
        }

        public ProjectConfigElement() { }

        [ConfigurationProperty("name", DefaultValue = "FedEx", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("display", IsRequired = true)]
        public string Display
        {
            get { return (string)this["display"]; }
            set { this["display"] = value; }
        }



        public string GetDBHandlerBackup(int num)
        {
            if (num <= dbhandlerBackupConnections.Count)
                return dbhandlerBackupConnections[num - 1];
            return null;
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();

            if (!string.IsNullOrEmpty(Name))
            {
                dbhandlerBackupConnections.Clear();
                string backups = ConfigurationManager.AppSettings["DBHandlerBackups-" + Name];
                if (!string.IsNullOrEmpty(backups))
                {
                    foreach (string connection in backups.Split(','))
                        dbhandlerBackupConnections.Add(connection);
                }
            }
        }
    }
}

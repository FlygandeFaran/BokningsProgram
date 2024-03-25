using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BokningsProgram
{
    public class SSKmanager
    {
        private string filename;
        private List<SSK> _listOfSSK;

        public List<SSK> ListOfSSK
        {
            get { return _listOfSSK; }
        }

        public SSKmanager()
        {
            _listOfSSK = new List<SSK>();
            filename = "SSK.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public void ImportFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SSK>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                _listOfSSK = (List<SSK>)serializer.Deserialize(fileStream);
            }
        }
        public void ExportToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SSK>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, _listOfSSK);
            }
        }
        public void RemoveSSK(string HSAid)
        {
            // Find the person with the given name and remove them from the list
            SSK personToRemove = _listOfSSK.FirstOrDefault(s => s.HSAID == HSAid);
            if (personToRemove != null)
            {
                _listOfSSK.Remove(personToRemove);
                Console.WriteLine($"SSK '{HSAid}' borttagen.");
            }
            else
            {
                Console.WriteLine($"SSK '{HSAid}' not found.");
            }
        }
        public void AddSSK(SSK newSSK)
        {
            _listOfSSK.Add(newSSK);
            ExportToXml();
        }
    }
}

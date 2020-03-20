using Remeberme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Remeberme.DataAccess
{
    public class DataManager
    {
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        private DataManager()
        {
            _lisfOfContacts = new ObservableCollection<Contato>();
        }

        private static volatile DataManager _instance;

        private ObservableCollection<Contato> _lisfOfContacts;

        public static DataManager Instance { get { return _instance ?? (_instance = new DataManager()); } }

        public void AddContato(Contato contato)
        {
            StorageFile sampleFile = null;

            contato.Id = Guid.NewGuid();
            contato.DataDeCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (File.Exists($"{storageFolder.Path}\\contatos.txt"))
            {
                Task getFilesTask = Task.Run(async () =>
                {
                    sampleFile = await storageFolder.GetFileAsync("contatos.txt");
                });

                getFilesTask.Wait();

                Task readFileTask = Task.Run(async () =>
                {
                    string json = await FileIO.ReadTextAsync(sampleFile);
                    _lisfOfContacts = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Contato>>(json);
                });

                readFileTask.Wait();
            }

            _lisfOfContacts.Add(contato);
        }

        public void SaveList()
        {
            string listaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(_lisfOfContacts);
            SaveFile(listaSerializada);
        }

        private void SaveFile(string data)
        {
            using (StreamWriter sw = new StreamWriter($"{storageFolder.Path}\\contatos.txt"))
            {
                sw.Write(data);
            }
        }
    }
}

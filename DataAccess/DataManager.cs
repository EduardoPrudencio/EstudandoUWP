using Remeberme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace Remeberme.DataAccess
{
    public class DataManager
    {
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private object _lock = new object();

        private DataManager()
        {
            _lisfOfContacts = new ObservableCollection<Contato>();
        }

        private static volatile DataManager _instance;

        private ObservableCollection<Contato> _lisfOfContacts;

        public static DataManager Instance { get { return _instance ?? (_instance = new DataManager()); } }

        public ObservableCollection<Contato> Contatos { get { UpdateList(); return _lisfOfContacts; } }

        public bool AddContato(Contato contato)
        {
            try
            {
                contato.Id = Guid.NewGuid();
                contato.DataDeCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                UpdateList();

                _lisfOfContacts.Add(contato);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveContato(Contato contato)
        {
            try
            {
                UpdateList();

                List<Contato> listaFiltrada = _lisfOfContacts.Where(x => !x.Id.ToString().Equals(contato.Id.ToString())).ToList();
                _lisfOfContacts = new ObservableCollection<Contato>(listaFiltrada);

                this.SaveList();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveList()
        {
            lock (_lock)
            {
                try
                {
                    List<Contato> _listaOrdenada = _lisfOfContacts.OrderBy(c => c.Nome).ToList();
                    _lisfOfContacts = new ObservableCollection<Contato>(_listaOrdenada);

                    string listaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(_lisfOfContacts);
                    SaveFile(listaSerializada);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void SaveFile(string data)
        {
            using (StreamWriter sw = new StreamWriter($"{storageFolder.Path}\\contatos.txt"))
            {
                sw.Write(data);
            }
        }

        private void UpdateList()
        {
            lock (_lock)
            {
                StorageFile sampleFile = null;

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
            }
        }
       
    }
}

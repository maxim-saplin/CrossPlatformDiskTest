using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(Saplin.CPDT.WPF.Deserializer))]
namespace Saplin.CPDT.WPF
{
    public class Deserializer : IDeserializer
    {
        const string PropertyStoreFile = "PropertyStore.forms";

        #pragma warning disable CS1998
        public async Task<IDictionary<string, object>> DeserializePropertiesAsync()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            if (!isoStore.FileExists(PropertyStoreFile))
                return new Dictionary<string, object>(4);

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(PropertyStoreFile, FileMode.Open, isoStore))
            {
                if (stream.Length == 0)
                    return new Dictionary<string, object>(4);

                try
                {
                    var serializer = new DataContractSerializer(typeof(IDictionary<string, object>));
                    return (IDictionary<string, object>)serializer.ReadObject(stream);
                }
                catch (Exception e)
                {
                    Log.Warning("Xamarin.Forms PropertyStore", $"Exception while reading Application properties: {e}");
                }

                return null;
            }
        }

        public async Task SerializePropertiesAsync(IDictionary<string, object> properties)
        {
            try
            {
                IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(PropertyStoreFile, FileMode.Create, isoStore))
                {
                    var serializer = new DataContractSerializer(typeof(IDictionary<string, object>));
                    serializer.WriteObject(stream, properties);
                    await stream.FlushAsync();
                }
            }
            catch
            {
            }
        }
    }
}

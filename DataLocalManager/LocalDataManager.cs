using Newtonsoft.Json;
using ProdTrace.HMI;
using ProdTrace.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProdTrace.DataLocalManager
{
    /*public class LocalDataManager
    {
        private static LocalDataManager instance;
        private static object lockObject = new object();

        private DataConfig localData;

        //private readonly string fileNameConfig = "config.txt";
        private string fileName;

        private LocalDataManager(string fileName)
        {
            localData = new DataConfig();
            this.fileName = fileName;
            ReadConfigFromFile();

        }

        public static LocalDataManager GetInstance(string filename)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new LocalDataManager(filename);
                }
            }
            return instance;
        }

        private void ReadConfigFromFile()
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                if (lines.Length >= 5)
                {
                    localData.Machine = lines[0];
                    localData.Site = lines[1];
                    localData.Line = lines[2];
                    localData.Host_ip = lines[3];
                    localData.Database_name = lines[4];
                    localData.User = lines[5];
                    localData.Password = lines[6];
                    localData.Hmi_ip = lines[7];
                    localData.Hmi_port = lines[8];
                    localData.Server_qrcode_ip = lines[9];
                    localData.Server_qrcode_port = lines[10];
                }
            }
        }

        private void SaveConfigToFile()
        {
            string[] lines = new string[]
            {
                localData.Machine,
                localData.Site,
                localData.Line,
                localData.Host_ip,
                localData.Database_name,
                localData.User,
                localData.Password,
                localData.Hmi_ip,
                localData.Hmi_port,
                localData.Server_qrcode_ip,
                localData.Server_qrcode_port
        };

            File.WriteAllLines(fileName, lines);
        }

        public void UpdateLocalData(DataConfig newData)
        {
            localData = newData;
            SaveConfigToFile();
        }

        public DataConfig GetLocalData()
        {
            return localData;
        }
    }*/

    public class LocalDataManager<T> : MyConst
    {
        private static LocalDataManager<T> instance;
        private static object lockObject = new object();

        private T localData;
        private string fileName;

        private bool hasInitializedDefaults = false;

        private LocalDataManager(string fileName)
        {
            localData = default(T); // Initialize with the default value for T.
            this.fileName = fileName;

            // Khởi tạo giá trị mặc định nếu chưa được khởi tạo
            /*if (!hasInitializedDefaults)
            {
                InitializeDefaultsRegister();
            }*/

            ReadConfigFromFile();
        }

        public static LocalDataManager<T> GetInstance(string filename)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new LocalDataManager<T>(filename);
                }
            }
            return instance;
        }

        private void ReadConfigFromFile()
        {
            if (File.Exists(fileName))
            {
                // Read and deserialize the configuration data from the file.
                string json = File.ReadAllText(fileName);
                localData = JsonConvert.DeserializeObject<T>(json);
            }
        }

        private void SaveConfigToFile(bool isHiden)
        {
            // Serialize and save the configuration data to the file.
            string json = JsonConvert.SerializeObject(localData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, json);

            if (isHiden)
            {
                // Thêm thuộc tính "ẩn" cho file
                FileInfo fileInfo = new FileInfo(fileName);
                fileInfo.Attributes |= FileAttributes.Hidden;
            }
        }

        public void DeleteFile()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        public void UpdateLocalData(T newData, bool isHide)
        {
            localData = newData;
            SaveConfigToFile(isHide);
        }

        public T GetLocalData()
        {
            return localData;
        }

        /* public void InitializeDefaultsRegister()
         {
             if (typeof(T) == typeof(List<Addr_hmi_registers>))
             {
                 List<Addr_hmi_registers> defaultRegisters = new List<Addr_hmi_registers>();

                 foreach (var entry in hmiBitsMap)
                 {
                     defaultRegisters.Add(new Addr_hmi_registers(entry.Key, entry.Value.ToString(), BIT));
                 }

                 foreach (var entry in hmiWordsMap)
                 {
                     defaultRegisters.Add(new Addr_hmi_registers(entry.Key, entry.Value.ToString(), WORD));
                 }

                 localData = (T)Convert.ChangeType(defaultRegisters, typeof(T));

                 // Đánh dấu đã khởi tạo giá trị mặc định
                 //hasInitializedDefaults = true;

                 // Lưu giá trị mặc định vào file
                 SaveConfigToFile(false);
             }
         }*/

        public T InitializeDefaultsRegister()
        {
            if (typeof(T) == typeof(List<Addr_hmi_registers>))
            {
                List<Addr_hmi_registers> defaultRegisters = new List<Addr_hmi_registers>();

                foreach (var entry in hmiBitsMap)
                {
                    defaultRegisters.Add(new Addr_hmi_registers(entry.Key, entry.Value.ToString(), BIT));
                }

                foreach (var entry in hmiWordsMap)
                {
                    defaultRegisters.Add(new Addr_hmi_registers(entry.Key, entry.Value.ToString(), WORD));
                }

                localData = (T)Convert.ChangeType(defaultRegisters, typeof(T));

                // Trả về giá trị mặc định
                return localData;
            }

            // Trong trường hợp khác, trả về một giá trị mặc định hoặc null tùy vào kiểu T của bạn.
            return default(T);
        }

    }
}

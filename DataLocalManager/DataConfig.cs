using ProdTrace.QR_Scanner;
using ProdTrace.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdTrace.DataLocalManager
{
    public class DataConfig
    {
        // QR scanner
        private string server_qrcode_ip;
        private string server_qrcode_port;
        private List<Scanner> scanners;
        // Database
        private RedcertRemote redcertRemote;
        // HMI
        private string hmi_ip;
        private string hmi_port;
        // File path
        private string filePath;

        private bool isAutoStartMornitoring;
        public DataConfig()
        {
        }

        public DataConfig(string server_qrcode_ip, string server_qrcode_port, List<Scanner> scanners, RedcertRemote redcertRemote, string hmi_ip, string hmi_port, string filePath, bool isAutoStartMornitoring)
        {
            this.Server_qrcode_ip = server_qrcode_ip;
            this.Server_qrcode_port = server_qrcode_port;
            this.Scanners = scanners;
            this.RedcertRemote = redcertRemote;
            this.Hmi_ip = hmi_ip;
            this.Hmi_port = hmi_port;
            this.FilePath = filePath;
            this.IsAutoStartMornitoring = isAutoStartMornitoring;
        }

        public string Server_qrcode_ip { get => server_qrcode_ip; set => server_qrcode_ip = value; }
        public string Server_qrcode_port { get => server_qrcode_port; set => server_qrcode_port = value; }
        public List<Scanner> Scanners { get => scanners; set => scanners = value; }
        public RedcertRemote RedcertRemote { get => redcertRemote; set => redcertRemote = value; }
        public string Hmi_ip { get => hmi_ip; set => hmi_ip = value; }
        public string Hmi_port { get => hmi_port; set => hmi_port = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public bool IsAutoStartMornitoring { get => isAutoStartMornitoring; set => isAutoStartMornitoring = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdTrace.DataLocalManager
{
    public class StationConfig
    {
        private string sel_func;
        private string factoryID;
        private string productionID;
        private string lineNum;
        private string machineID;
        private string locationID;
        private string machineCode;
        private string stationID;
        private bool isStartShowing;

        public StationConfig()
        {
        }

        public StationConfig(string sel_func, string factoryID, string productionID, string lineNum, string machineID, string locationID, string machineCode, string stationID, bool isStartShowing)
        {
            this.Sel_func = sel_func;
            this.FactoryID = factoryID;
            this.ProductionID = productionID;
            this.LineNum = lineNum;
            this.MachineID = machineID;
            this.LocationID = locationID;
            this.MachineCode = machineCode;
            this.StationID = stationID;
            this.IsStartShowing = isStartShowing;
        }

        public string Sel_func { get => sel_func; set => sel_func = value; }
        public string FactoryID { get => factoryID; set => factoryID = value; }
        public string ProductionID { get => productionID; set => productionID = value; }
        public string LineNum { get => lineNum; set => lineNum = value; }
        public string MachineID { get => machineID; set => machineID = value; }
        public string LocationID { get => locationID; set => locationID = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string StationID { get => stationID; set => stationID = value; }
        public bool IsStartShowing { get => isStartShowing; set => isStartShowing = value; }

        public bool IsValid()
        {
            // Kiểm tra tính hợp lệ của StationConfig
            return !string.IsNullOrEmpty(FactoryID) &&
                   !string.IsNullOrEmpty(ProductionID) &&
                   !string.IsNullOrEmpty(LineNum) &&
                   !string.IsNullOrEmpty(MachineID) &&
                   //!string.IsNullOrEmpty(LocationID) &&
                   !string.IsNullOrEmpty(MachineCode) &&
                   !string.IsNullOrEmpty(StationID);
        }

        public string GetValidationErrorMessage()
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(FactoryID))
            {
                errorMessage.AppendLine("FactoryID can't empty");
            }

            if (string.IsNullOrEmpty(ProductionID))
            {
                errorMessage.AppendLine("ProductionID can't empty");
            }

            if (string.IsNullOrEmpty(LineNum))
            {
                errorMessage.AppendLine("LineNum can't empty");
            }

            if (string.IsNullOrEmpty(MachineID))
            {
                errorMessage.AppendLine("MachineID can't empty");
            }

            if (string.IsNullOrEmpty(LocationID))
            {
                errorMessage.AppendLine("LocationID can't empty");
            }

            if (string.IsNullOrEmpty(MachineCode))
            {
                errorMessage.AppendLine("MachineCode can't empty");
            }

            if (string.IsNullOrEmpty(StationID))
            {
                errorMessage.AppendLine("StationID can't empty");
            }

            return errorMessage.ToString();
        }

    }
}

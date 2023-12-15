using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class UserInterface
    {
        private enum Options
        {
            Start = 1,
            Stop,
            ConfigureCompliance,
            RefreshConfigurations,
            Exit = 0,
        }
        public void StartUserInterface()
        {
            FileOperations fileOperations = new FileOperations();
            DataAcquisitionModule dataAcquisitionModule = fileOperations.LoadSettingsFromJson();
            ComplianceModule complianceModule = new ComplianceModule();
            ProcessTimer processTimer = new ProcessTimer(dataAcquisitionModule, complianceModule);
            bool continueProcess = true;
            while (continueProcess)
            {
                Console.WriteLine("Welcome to Data Acquisition System");
                Console.WriteLine("\n1.Start\n2.Stop\n3.Configure Compliance\n4.Refresh Configurations\n0.Exit");
                int userSelectedOption = ;
                Options userOption = (Options)userSelectedOption;
                switch (userOption)
                {
                    case Options.Start:
                        processTimer.StartProcess();
                        break;
                    case Options.Stop:
                        processTimer.StopProcess();
                        break;
                    case Options.ConfigureCompliance:
                        break;
                    case Options.RefreshConfigurations:
                        break;
                    case Options.Exit:
                        break;
                }
            }
        }
    }
}

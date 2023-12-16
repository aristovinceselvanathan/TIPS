using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class UserInterface
    {
        ComplianceModule complianceModule = new ComplianceModule();
        DataAcquisitionSettings dataAcquisitionSettings = FileOperations.LoadSettingsFromJson();

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
            ProcessTimer processTimer = new ProcessTimer(dataAcquisitionSettings, complianceModule);
            bool continueProcess = true;

            while (continueProcess)
            {
                Console.WriteLine("Welcome to Data Acquisition System");
                Console.WriteLine("\n1.Start\n2.Stop\n3.Configure Compliance\n4.Refresh Configurations\n0.Exit");
                int userSelectedOption = Utility.GetIntegerInput("Choice");
                Options userOption = (Options)userSelectedOption;
                switch (userOption)
                {
                    case Options.Start:
                        Start(complianceModule, processTimer);
                        break;
                    case Options.Stop:
                        Stop(processTimer);
                        break;
                    case Options.ConfigureCompliance:
                        configureCompliance();
                        break;
                    case Options.RefreshConfigurations:
                        RefreshConfigurations(processTimer);
                        break;
                    case Options.Exit:
                        continueProcess = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option - Please select the operation from 0 to 4");
                        break;
                }
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void configureCompliance()
        {
            Console.Clear();
            Console.WriteLine("Configure Compliance Menu");
            string parameterName = Utility.GetStringInput("Parameter");
            if (dataAcquisitionSettings.Parameters.Where(x => x.parameterType.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase)).Count() >= 1)
            {
                Parameter selectedParameter = new Parameter();
                selectedParameter.parameterType = dataAcquisitionSettings.Parameters.FirstOrDefault(x => x.parameterType.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase)).parameterType;
                Console.WriteLine($"{selectedParameter.parameterType}");
                selectedParameter.HighValue = Utility.GetIntegerInput("High Value");
                selectedParameter.LowValue = Utility.GetIntegerInput("Low Value");
                Console.WriteLine("Updated the Parameter");
                complianceModule.ChangeParameters(selectedParameter);
            }
            else
            {
                Console.WriteLine("Not Exists in the Data Acquisition Module");
            }
        }

        public void RefreshConfigurations(ProcessTimer processTimer)
        {
            processTimer.acquisitionSettings = FileOperations.LoadSettingsFromJson();
            Console.WriteLine("Data Loaded from the Json to the DAQ");
        }
        public void Start(ComplianceModule complianceModule, ProcessTimer processTimer)
        {
            if (processTimer.timer.Enabled == false)
            {
                Console.Clear();
                if (complianceModule.Parameters != null && complianceModule.Parameters.Count == dataAcquisitionSettings.Parameters.Count)
                {
                    processTimer.StartProcess();
                }
                else if(complianceModule.Parameters != null && complianceModule.Parameters.Count != dataAcquisitionSettings.Parameters.Count)
                {
                    Console.WriteLine("Please Configure the all the compliance module");
                }
                else
                {
                    Console.WriteLine("Please Configure the Compliance to Start it.");
                }
            }
            else
            {
                Console.WriteLine("Timer should be stopped");
            }
        }
        public void Stop(ProcessTimer processTimer)
        {
            if (processTimer.timer.Enabled == true)
            {
                processTimer.StopProcess();
            }
            else
            {
                Console.WriteLine("Please start the operation");
            }
        }
    }
}

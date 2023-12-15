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
        List<Parameter> parameters;
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
            DataAcquisitionSettings dataAcquisitionSettings = fileOperations.LoadSettingsFromJson();
            ProcessTimer processTimer = new ProcessTimer(dataAcquisitionSettings, complianceModule);
            fileOperations.Load();
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
                        refreshConfigurations();
                        break;
                    case Options.Exit:
                        continueProcess = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option - Please select the operation from 0 to 4");
                        break;
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void configureCompliance()
        {
            parameters = new List<Parameter>();
            Console.WriteLine("Configure Compliance Menu");
            Parameter current = new Parameter(Utility.GetIntegerInput("Maximum Current Value"), Utility.GetIntegerInput("Minimum Current Value"), Parameter.ParameterType.Current);
            Parameter temperature = new Parameter(Utility.GetIntegerInput("Maximum Temperature Value"), Utility.GetIntegerInput("Minimum Temperature Value"), Parameter.ParameterType.Temperature);
            parameters.Add(current);
            parameters.Add(temperature);
            complianceModule.ChangeParameters(parameters);
        }

        public void refreshConfigurations()
        {
            if (parameters != null && parameters.Count == 2)
            {
                complianceModule.ChangeParameters(parameters);
            }
            Console.WriteLine("Compliance Module Parameter is to be changed to start the operation");
        }
        public void Start(ComplianceModule complianceModule, ProcessTimer processTimer)
        {
            if (complianceModule.Parameters != null && complianceModule.Parameters.Count == 2)
            {
                processTimer.StartProcess();
            }
            else
            {
                Console.WriteLine("Please Configure the Compliance to Start it.");
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

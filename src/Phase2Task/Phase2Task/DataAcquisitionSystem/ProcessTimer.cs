using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace DataAcquisitionSystem
{
    public class ProcessTimer
    {
        private DataAcquisitionModule dataAcquisitionModule;
        private ComplianceModule complianceModule;
        private DataAcquisitionSettings acquisitionSettings;
        public System.Timers.Timer timer { get; private set; }
        public ProcessTimer(DataAcquisitionSettings dataAcquisitionSettings, ComplianceModule compliance)
        {
            dataAcquisitionModule = new DataAcquisitionModule(compliance);
            timer = new System.Timers.Timer(dataAcquisitionSettings.Rate * 1000);
            acquisitionSettings = dataAcquisitionSettings;
            complianceModule = compliance;
        }
        public void StartProcess()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        public void StopProcess() 
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();
        }
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            dataAcquisitionModule.GenerateData(acquisitionSettings);
            Console.SetCursorPosition(40, 0);
            Console.WriteLine($"Current Value : {dataAcquisitionModule.current} Temperature Value : {dataAcquisitionModule.temperature}");
        }
    }
}

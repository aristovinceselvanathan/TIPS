using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace DataAcquisitionSystem
{
    public class ProcessTimer
    {
        private System.Timers.Timer timer;
        private DataAcquisitionModule dataAcquisitionModule;
        private ComplianceModule complianceModule;

        public ProcessTimer(DataAcquisitionModule dataAcquisition, ComplianceModule compliance)
        {
            timer = new System.Timers.Timer(dataAcquisition.Rate);
            dataAcquisitionModule = dataAcquisition;
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
            dataAcquisitionModule.GenerateData();
            if(dataGenerated.Item1 > complianceModule.Parameters.ElementAt(0).HighValue)
            {
                throw new Exception("Current is above compliance limit");
            }
            else if(dataGenerated.Item1 < complianceModule.Parameters.ElementAt(0).LowValue)
            {
                throw new Exception("Current is below compliance limit");
            }
            if (dataGenerated.Item2 > complianceModule.Parameters.ElementAt(1).HighValue)
            {
                throw new Exception("Temperature is below compliance limit");
            }
            if (dataGenerated.Item2 < complianceModule.Parameters.ElementAt(1).LowValue)
            {
                throw new Exception("Temperature is below compliance limit");
            }

        }
    }
}

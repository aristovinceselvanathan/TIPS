using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace DataAcquisitionSystem
{
    /// <summary>
    /// The process timer.
    /// </summary>
    public class ProcessTimer
    {
        private DataAcquisitionModule dataAcquisitionModule;
        private ComplianceModule complianceModule;
        private DataAcquisitionSettings acquisitionSettings;

        /// <summary>
        /// Gets the timer.
        /// </summary>
        public System.Timers.Timer timer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessTimer"/> class.
        /// </summary>
        /// <param name="dataAcquisitionSettings">The data acquisition settings.</param>
        /// <param name="compliance">The compliance.</param>
        public ProcessTimer(DataAcquisitionSettings dataAcquisitionSettings, ComplianceModule compliance)
        {
            dataAcquisitionModule = new DataAcquisitionModule(compliance);
            timer = new System.Timers.Timer(dataAcquisitionSettings.Rate * 1000);
            acquisitionSettings = dataAcquisitionSettings;
            complianceModule = compliance;
        }

        /// <summary>
        /// Starts the process.
        /// </summary>
        public void StartProcess()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        /// <summary>
        /// Stops the process.
        /// </summary>
        public void StopProcess() 
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();
        }

        /// <summary>
        /// Timer_S the elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            dataAcquisitionModule.GenerateData(acquisitionSettings);
            Console.SetCursorPosition(40, 0);
            Console.WriteLine($"Current Value : {dataAcquisitionModule.current} Temperature Value : {dataAcquisitionModule.temperature}");
        }
    }
}

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
        public DataAcquisitionSettings acquisitionSettings { get; set;}

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
            (var a, var b) = Console.GetCursorPosition();
            int cursorPosition = 0;
            Console.SetCursorPosition(70, 0);
            dataAcquisitionModule.GenerateData(acquisitionSettings);
            foreach(var data in dataAcquisitionModule.Parameters)
            {
                Console.WriteLine($"{data.Key} : {data.Value}");
                Console.SetCursorPosition(70, ++cursorPosition);
            }
            Console.SetCursorPosition(a, b);
        }
    }
}

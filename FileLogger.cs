using System;
using System.Collections.Generic;
using System.Text;

namespace lv_2
{
    class FileLogger : ILogger
    {
        private string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(ILogable data)
        {
            using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(this.filePath))

            {
                fileWriter.WriteLine(data.GetStringRepresentation());
            }
        }
    }
}

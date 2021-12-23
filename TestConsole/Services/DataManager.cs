using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Data;
using TestConsole.Services.Interface;

namespace TestConsole.Services
{
    public class DataManager : IDataManager, IDisposable
    {
        private readonly IDataProcessor _Processor;

        public DataManager(IDataProcessor Processor)
        {
            _Processor = Processor;
        }

        public void ProcessData(IEnumerable<DataValue> Values)
        {
            foreach (var value in Values)
                _Processor.Process(value);
        }

        public void Dispose()
        {
            Console.WriteLine("Менеджер обработки данных уничтожен");
        }
    }
}

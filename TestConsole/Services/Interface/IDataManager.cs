using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Data;

namespace TestConsole.Services.Interface
{
    public interface IDataManager
    {
        void ProcessData(IEnumerable<DataValue> Values);
    }


    public interface IDataProcessor
    {
        void Process(DataValue Value);
    }
}

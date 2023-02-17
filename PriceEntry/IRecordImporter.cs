using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceEntry
{
    public interface IRecordImporter<T>
    {
        List<T> ImportRecords();
    }
}

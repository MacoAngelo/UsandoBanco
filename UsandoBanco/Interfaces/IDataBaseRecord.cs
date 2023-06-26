using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBanco.Interfaces
{
    internal interface IDataBaseRecord
    {
        int Id { get; }
        string TableName { get; }

        void Delete();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreapi.Services
{
    public interface ILoggerService
    {
        public void Write(string message);

    }
}
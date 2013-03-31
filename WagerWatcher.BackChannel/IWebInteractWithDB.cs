using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WagerWatcher.BackChannel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebInteractWithDB" in both code and config file together.
    [ServiceContract]
    public interface IWebInteractWithDB
    {
        [OperationContract]
        void DoWork();
    }
}

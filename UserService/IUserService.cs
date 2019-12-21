using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract (IsOneWay = true)]
        void AddToCart(int Id, string Username);

        [OperationContract (IsOneWay = true)]
        void RemoveFromCart(int Id, string Username);
    }
}

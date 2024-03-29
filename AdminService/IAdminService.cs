﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        int AddItem(string Name, string Description, float Price, string Category);

        [OperationContract]
        int DeleteItemById(int Id);

        [OperationContract]
        int EditItem(int Id, string Name, string Description, float Price, string Category);
    }
}

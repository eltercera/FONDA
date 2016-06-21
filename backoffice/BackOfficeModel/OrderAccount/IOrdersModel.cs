﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace BackOfficeModel.OrderAccount
{
    public interface IOrdersModel : IModel
    {
        Table OrdersTable { get; set; }

        string Session { get; set; }

        Button CloseButton { get; set; }

    }
}

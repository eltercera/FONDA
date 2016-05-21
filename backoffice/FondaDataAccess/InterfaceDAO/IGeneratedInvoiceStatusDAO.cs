using System;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    interface IGeneratedInvoiceStatusDAO : IStatusDAO<GeneratedInvoiceStatus>
    {
        GeneratedInvoiceStatus getGeneatedInvoiceStatus();
    }
}

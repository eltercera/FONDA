using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateTableDAO : HibernateBaseEntityDAO<Table>, ITableDAO
    {
    }
}

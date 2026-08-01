using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer.Global
{
    public interface IAddServices<AddDTO>
    {
        int AddNew(AddDTO AddDTO);

    }
}

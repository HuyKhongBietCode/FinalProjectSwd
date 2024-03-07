using FinalProjectSwd.Managements;
using FinalProjectSwd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSwd.Repositorys
{
    public class AreaRepository : IAreaRepository
    {
        public List<Area> GetAllAreas()
        {
            return AreaManagement.Instance.GetAll();
        }
    }
}

using FinalProjectSwd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSwd.Repositorys
{
    public interface IAreaRepository
    { 
        public List<Area> GetAllAreas();    
    }
}

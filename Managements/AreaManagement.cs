using FinalProjectSwd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSwd.Managements
{
    public class AreaManagement
    {
        private static AreaManagement instance;
        public static AreaManagement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AreaManagement();
                }
                return instance;
            }
        }

        public List<Area> GetAll()
        {
            using (var _context = new CafeSystemContext())
            {
                return _context.Areas.ToList();
            }
        }
        public List<Area> GetAllByCondition(Expression<Func<Area, bool>> filter)
        {
            using (var _context = new CafeSystemContext())
            {
                
                return _context.Areas.Where(filter)
                    .ToList();
            }
        }
        public Area GetByid(string id)
        {
            using (var _context = new CafeSystemContext())
            {
                return _context.Areas.FirstOrDefault(a => a.AreaId == id);
            }
        }
        public Area GetByCondition(Expression<Func<Area, bool>> filter)
        {
            using (var _context = new CafeSystemContext())
            {
                return _context.Areas.FirstOrDefault(filter);

            }
        }
        public void Update(string id, Area area)
        {
            using (var _context = new CafeSystemContext())
            {
                Area check = _context.Areas.FirstOrDefault(a => a.AreaId == id);
                if (check != null)
                {
                    check.AreaName = area.AreaName;
                    check.Description = area.Description;
                    _context.Areas.Update(check);
                    _context.SaveChanges();
                }


            }
        }

        public void Add(Area area)
        {
            using (var _context = new CafeSystemContext())
            {
                _context.Areas.Add(area);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _context = new CafeSystemContext())
            {

            }
        }
    }
}

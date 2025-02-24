using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;

namespace Free_Course_For_Student.Repository.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ElearningContext _context;
        public ModuleRepository(ElearningContext context)
        {
            _context = context;
        } public List<Module> GetModuleListbycourseid(int courseId)
        {
            return _context.Modules.Where(m => m.CourseId == courseId).ToList();
        }

        public Module GetById(int moduleId)
        {
            return _context.Modules.FirstOrDefault(m => m.ModuleId == moduleId);
        }

        public void Add(Module module)
        {
            _context.Modules.Add(module);
            _context.SaveChanges();
        }

        public void Update(Module module)
        {
            _context.Modules.Update(module);
            _context.SaveChanges();
        }

        public void Delete(int moduleId)
        {
            var module = GetById(moduleId);
            if (module != null)
            {
                _context.Modules.Remove(module);
                _context.SaveChanges();
            }
        }
    }
}
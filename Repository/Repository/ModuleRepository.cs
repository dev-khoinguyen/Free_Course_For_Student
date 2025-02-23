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
        }
        public void Add(Module module)
        {
            throw new NotImplementedException();
        }

        public void Delete(int moduleid)
        {
            throw new NotImplementedException();
        }

        public List<Module> GetModuleList(int moduleid)
        {
            throw new NotImplementedException();
        }

        public List<Module> GetModuleListbycourseid(int courseId)
        {
            throw new NotImplementedException();
        }

        public void Update(Module module)
        {
            throw new NotImplementedException();
        }
    }
}
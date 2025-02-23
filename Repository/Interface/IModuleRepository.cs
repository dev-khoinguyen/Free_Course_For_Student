using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface IModuleRepository
    {
        public List<Module> GetModuleListbycourseid(int courseId);
        public List<Module> GetModuleList(int moduleid);
        public void Add(Module module);
        public void Update(Module module);
        public void Delete(int moduleid);

    }
}
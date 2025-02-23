using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface IModuleRepository
    {
        List<Module> GetModuleListbycourseid(int courseId);
        Module GetById(int moduleId);
        void Add(Module module);
        void Update(Module module);
        void Delete(int moduleId);

    }
}
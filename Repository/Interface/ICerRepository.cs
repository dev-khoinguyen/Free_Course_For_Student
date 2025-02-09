using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface ICerRepository
    {
        public IEnumerable<Certificate> GetAllCer();
        public Certificate GetCerById(int id);
        public void AddCer(Certificate cer);
        public void UpdateCer(Certificate cer);
        public void DeleteCer(Certificate cer);
        public List<Certificate> GetAllCerByCourse();
    }
}
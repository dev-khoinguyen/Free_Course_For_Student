using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;

namespace Free_Course_For_Student.Repository.Interface
{
    public interface ISubmissionRepository
    {
        public List<Submission> GetSubmissionsbymodule(int id);
        public void Add(Submission submission);
        public void Update(Submission submission);
        public void Delete(int id);
    }
}
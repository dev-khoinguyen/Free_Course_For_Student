using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;

namespace Free_Course_For_Student.Repository.Repository
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly ElearningContext _context;
        public SubmissionRepository(ElearningContext context)
        {   
            _context = context;
        }
        public void Add(Submission submission)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Submission> GetSubmissionsbymodule(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Submission submission)
        {
            throw new NotImplementedException();
        }
    }
}
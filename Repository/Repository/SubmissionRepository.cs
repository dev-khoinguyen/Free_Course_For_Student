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
        public List<Submission> GetAllSubmissions()
        {
            return _context.Submissions.ToList();
        }

        public Submission GetById(int id)
        {
            return _context.Submissions.FirstOrDefault(s => s.SubmissionId == id);
        }


        // 🟢 Lấy danh sách bài nộp theo module
        public List<Submission> GetSubmissionsbymodule(int moduleId)
        {
            return _context.Submissions.Where(s => s.ModuleId == moduleId).ToList();
        }

        // 🟢 Thêm bài nộp mới
        public void Add(Submission submission)
        {
            _context.Submissions.Add(submission);
            _context.SaveChanges();
        }

        // 🟢 Cập nhật bài nộp
        public void Update(Submission submission)
        {
            var existing = _context.Submissions.FirstOrDefault(s => s.SubmissionId == submission.SubmissionId);
            if (existing != null)
            {
                existing.SubmissionUrl = submission.SubmissionUrl;
                existing.Score = submission.Score;
                existing.Status = submission.Status;
                existing.SubmittedAt = submission.SubmittedAt;
                _context.SaveChanges();
            }
        }

        // 🟢 Xóa bài nộp
        public void Delete(int id)
        {
            var submission = _context.Submissions.FirstOrDefault(s => s.SubmissionId == id);
            if (submission != null)
            {
                _context.Submissions.Remove(submission);
                _context.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ManagerRepository:IManagerRepository
    {
        private readonly ScheduleMasterContext _context;

        public ManagerRepository(ScheduleMasterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return _context.Managers.ToList();
        }
        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _context.Managers.FindAsync(id);
        }
        public async Task<Manager> UpdateAsync(int id, Manager manager)
        {
            manager.Id = id;
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
            return manager;
        }
        public async Task<int> AddAsync(Manager manager)
        {
            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
            return manager.Id;
        }
        public async Task<IEnumerable<TeacherDetailsDTO>> GetTeachersByParametersAsync(int id, string? firstName, string? lastName, string? mail, List<string>? subjectsList, string? cellPhone, string? telephone)
        {
            var teachers = await _context.ManagerSchoolTeachers.Where(mt => mt.SchoolManager.ManagerId == id 
            && firstName == null || mt.Teacher.User.FirstName == null ? true : mt.Teacher.User.FirstName.Contains(firstName)
            && lastName == null || mt.Teacher.User.LastName == null ? true : mt.Teacher.User.LastName.Contains(lastName)
            && mail == null ? true : mt.Teacher.User.Username.Equals(mail)
            && subjectsList == null ? true : mt.Teacher.TeacherSubjects.Any(ts => subjectsList.Contains(ts.Subject.Name))
            && cellPhone == null || mt.Teacher.User.CellPhone == null ? true : mt.Teacher.User.CellPhone.Contains(cellPhone)
            && telephone == null || mt.Teacher.User.Telephone == null ? true : mt.Teacher.User.Telephone.Contains(telephone)
            ).Select(t =>
                new TeacherDetailsDTO
                {
                    TeacherId = t.TeacherId,
                    Mail = t.Teacher.User.Username,
                    FirstName = t.Teacher.User.FirstName,
                    LastName = t.Teacher.User.LastName,
                    ProfileImageURL = t.Teacher.User.ProfileImageUrl,
                    Telephone = t.Teacher.User.Telephone,
                    CellPhone = t.Teacher.User.CellPhone,
                    Subjects = t.Teacher.TeacherSubjects.Select(ts =>
                        new SubjectDTO
                        {
                            SubjectId = ts.SubjectId,
                            SubjectName = ts.Subject.Name,
                            CategoryName = ts.Subject.SubjectCategory.Name
                        }).ToList()
                }).ToListAsync();

            return teachers;
        }
    }
}

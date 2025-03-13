using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services.Contracts;
using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Services
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherManager(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public void AddTeacher(TeacherCreateDto teacher)
        {
            throw new NotImplementedException();
        }

        public TeacherDto GetTeacher(Func<Teacher, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<TeacherDto> GetTeachers(Expression<Func<Teacher, bool>>? predicate = null)
        {
            var teachers = _repository.GetAll(predicate);

            var teacherDtoList = new List<TeacherDto>();

            foreach (var item in teachers)
            {
                var teacherDto = new TeacherDto
                {
                    Id = item.Id,
                    Name = item.Name
                };

                foreach (var teacherGroup in item.TeacherGroups)
                {
                    teacherDto.Groups.Add(new GroupDto
                    {
                        Id = teacherGroup.GroupId,
                        Name = teacherGroup.Group?.Name
                    });
                }

                teacherDtoList.Add(teacherDto);
            }

            return teacherDtoList;
        }

        public void RemoveTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeacher(int id, Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}

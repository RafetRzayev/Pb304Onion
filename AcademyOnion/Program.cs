using Academy.Application.DTOs;
using Academy.Application.Repositories;
using Academy.Application.Services;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using Academy.Infrastructure.Repositories;
using System.ComponentModel.DataAnnotations;

namespace AcademyOnion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appDbContext = new AppDbContext();

            var groupRepo = new GroupRepository(appDbContext);
            var groupMan = new GroupManager(groupRepo);

            groupMan.AddGroup(new GroupCreateDto
            {
                Name = "DG123",
                TeacherIds = [1, 2]
            });


            foreach (var item in groupMan.GetGroups())
            {
                Console.WriteLine(item.Name);

                foreach (var teacher in item.Teachers)
                {
                    Console.WriteLine(teacher.Name);
                }
            }

            //TeacherRepository teacherRepository = new TeacherRepository(appDbContext);
            //TeacherManager teacherManager = new TeacherManager(teacherRepository);

            //foreach (var item in teacherManager.GetTeachers())
            //{
            //    Console.WriteLine(item.Name);

            //    foreach (var group in item.Groups)
            //    {
            //        Console.WriteLine(group.Name);
            //    }
            //}
        }
    }
}

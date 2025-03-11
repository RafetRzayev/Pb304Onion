using Academy.Application.DTOs;
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
            GroupRepository groupRepository = new GroupRepository(appDbContext);
            GroupManager groupManager = new GroupManager(groupRepository);

            foreach (var item in groupManager.GetGroups(x=>x.Id>0))
            {
                Console.WriteLine(item.Name);

                foreach (var st in item.Students)
                {
                    Console.WriteLine("--" + st.Name);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Teacher : Entity
    {
        public string Name { get; set; }
        public List<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();
    }
}

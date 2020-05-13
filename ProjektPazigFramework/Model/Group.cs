using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework.Model
{
    public class Group
    {

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public override string ToString()
        {
            
                return $"{GroupId}  |   {GroupName}";
          
        }
       
        public virtual ICollection<Person> PeopleInGroup { get; set; }
        public virtual ICollection<Expense> ExpenseInGroup { get; set; }

    }
}

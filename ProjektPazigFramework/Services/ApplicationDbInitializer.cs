using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjektPazigFramework.Model;

namespace ProjektPazigFramework.Services
{
    class ApplicationDbInitializer: DropCreateDatabaseAlways<ApplicationDb>
    {
        protected override void Seed(ApplicationDb context)
        {
            IList<Person> defaultStandards = new List<Person>();
            Group g = new Group() { GroupName = "Pierwsza" };
            Group h= new Group() { GroupName = "Mieszkanie" };
            Group i = new Group() { GroupName = "Wycieczka" };

            defaultStandards.Add(new Person() { Name = "Kasia", PersonId=1, Group=g});
            defaultStandards.Add(new Person() { Name = "Zuzia", PersonId=2, Group = g });

            context.Groups.Add(g);
            context.Groups.Add(h);
            context.Groups.Add(i);

            context.People.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}

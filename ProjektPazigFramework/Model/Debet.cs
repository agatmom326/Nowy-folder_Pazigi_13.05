using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework.Model
{
    public class Debet
    {
        [Key]
        public int DebetId { get; set; }
        public int WhoId { get; set; }
        public string WhoName { get; set; }
        public int ForWhoId { get; set; }
        public string ForWhoName { get; set; }
        public int GroupId { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"Osoba {WhoName} powinna zwrócić  {Amount} zł osobie {ForWhoName}";
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework.Model
{
    public class Expense
    {   
        public string Name { get; set; }
        public int ExpenseId { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {

            return $"{Name} | kwota: {Amount} zł";

        }
    }
}

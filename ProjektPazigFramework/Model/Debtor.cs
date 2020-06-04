using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework.Model
{
    public class Debtor
    {
        [Key]
        public int DebtorId { get; set; }
        public int PersonId { get; set; }
        public int ExpenseId { get; set; }


    }
}

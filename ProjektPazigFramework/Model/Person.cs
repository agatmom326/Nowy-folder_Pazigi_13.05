using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework.Model
{
    public class Person: ObservableObject
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }
        public int NrIndexInGroup { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { Set(ref _isChecked, value); }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

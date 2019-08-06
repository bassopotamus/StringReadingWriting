using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StringReadingWriting
{
    public class Password
    {
        [Key]
        public int Index { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string NewPass { get; set; }

    }

    
}

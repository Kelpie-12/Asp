using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiFramework.Model
{
  public  class UserReview
    {
        public int Id { get; set; }
        public long IdProduct { get; set; } = -1;
        public string? UserName { get; set; }

        public int Mark { get; set; }
        public string? Desc { get; set; }
    }
}

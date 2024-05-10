using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_EDU.Core.Models
{
    public class IndexTopModel
    {
        public List<Post?> TopLikesPosts { get; set; }
        public List<Post?> TopDatePosts { get; set; }
    }
}

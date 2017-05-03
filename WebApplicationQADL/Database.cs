using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApplicationQATL;


namespace WebApplicationQADL
{
   public static class Database
   {
      public static List<AboutDto> HomeAbout { get; set; } = new List<AboutDto>();

      public static List<ContactDto> HomeContact { get; set; } = new List<ContactDto>();
   }
}

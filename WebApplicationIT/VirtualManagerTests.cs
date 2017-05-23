using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using WebApplicationQABL;

using WebApplicationQATL;


namespace WebApplicationIT
{
   [TestFixture]
   class VirtualManagerTests
   {
      [Test]
      public void ReadTest()
      {
         VirtualManager virtualManager = new VirtualManager();

         VirtualDto result = virtualManager.Read();

         Assert.AreEqual("This is the original hard coded name", result.HardCodedName());
         Assert.AreEqual(new VirtualDto().HardCodedName(), result.HardCodedName());
         //
      }
   }
}

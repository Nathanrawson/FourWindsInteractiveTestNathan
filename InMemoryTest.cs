using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class InMemoryTest : IStoreable
    {
        public IComparable Id { get; set; }

        public string Name { get; set; }
    }
}

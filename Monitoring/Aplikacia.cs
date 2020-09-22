using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring
{
    public class Aplikacia
    {
        private static int velkostStanice;
        public static float ramSize = 8;
        public static float ssdSize = 128;


        public static  int VelkostStanice
        {
            get { return velkostStanice; }
            set { velkostStanice = value; }
        }
        public Aplikacia()
        {
            VelkostStanice = 15;
        }
    }
}

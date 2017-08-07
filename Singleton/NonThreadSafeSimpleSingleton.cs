using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class NonThreadSafeSimpleSingleton
    {
        private NonThreadSafeSimpleSingleton()
        {
            InstanceCounter++;
        }

        public static int InstanceCounter = 0;

        private static NonThreadSafeSimpleSingleton _instance;
        public static NonThreadSafeSimpleSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (InstanceCounter == 0)
                        Thread.Sleep(10);
                    _instance = new NonThreadSafeSimpleSingleton();
                }

                return _instance;
            }
            private set
            {

            }
                
        }
    }
}

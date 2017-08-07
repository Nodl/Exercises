using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ThreadSafeSimpleSingleton
    {
        private ThreadSafeSimpleSingleton()
        {
            InstanceCounter++;
        }

        public static int InstanceCounter = 0;
        private static object sync = new object();

        private static ThreadSafeSimpleSingleton _instance;
        public static ThreadSafeSimpleSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThreadSafeSimpleSingleton();
                        }
                    }
                }

                return _instance;
            }
            private set
            {

            }

        }
    }
}

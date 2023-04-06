using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSamples.Singleton
{
    public class LiasseVierge
    {
        private static LiasseVierge instance = null;
        // Private constructor
        private LiasseVierge()
        {}

        // Public constructor
        public static LiasseVierge GetInstance()
        {
            if (instance == null)
            {
                instance = new LiasseVierge();
            }
            return instance;
        }
    }

}

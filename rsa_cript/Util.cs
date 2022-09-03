using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsa_cript
{
    class Util
    {
        public static int modInverse(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q is quotient
                int q = a / m;

                int t = m;

                // m is remainder now, process
                // same as Euclid's algo
                m = a % m;
                a = t;
                t = y;

                // Update x and y
                y = x - q * y;
                x = t;
            }

            // Make x positive
            if (x < 0)
                x += m0;

            return x;
        }

        // Returns gcd of a and b
        public static int gcd(int a, int b)
        {
            int aux;
            while (true)
            {
                aux = a % b;
                if (aux == 0)
                    return b;
                a = b;
                b = aux;
            }
            //return -1;
        }
    }
}

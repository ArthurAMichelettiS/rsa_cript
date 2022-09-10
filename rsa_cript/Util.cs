using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace rsa_cript
{
    class Util
    {
        // a*D % m = 1
        public static BigInteger modInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q é o quociente
                BigInteger q = a / m;

                BigInteger t = m;

                // m se torna o resto, processa
                // Euclid alg
                m = a % m;
                a = t;
                t = y;

                // atualizar x & y
                y = x - q * y;
                x = t;
            }

            // Tornar x positivo
            if (x < 0)
                x += m0;

            return x;
        }

        // Retorna o gcd (maximo divisor comum) de a & b
        public static BigInteger gcd(BigInteger a, BigInteger b)
        {
            BigInteger aux;
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

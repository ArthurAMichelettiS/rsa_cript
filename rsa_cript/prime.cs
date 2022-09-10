using System;
using System.Numerics;

namespace rsa_cript
{
    class prime
    {
        
        public static BigInteger obtemPrimo(int numeroDeBits)
        {


            int[] first_primes_list = new int[]

            { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
                31, 37, 41, 43, 47, 53, 59, 61, 67,
                71, 73, 79, 83, 89, 97, 101, 103,
                107, 109, 113, 127, 131, 137, 139,
                149, 151, 157, 163, 167, 173, 179,
                181, 191, 193, 197, 199, 211, 223,
                227, 229, 233, 239, 241, 251, 257,
                263, 269, 271, 277, 281, 283, 293,
                307, 311, 313, 317, 331, 337, 347, 349 };

            //N1 RSA
            int nbit = numeroDeBits; //número de bits

            BigInteger nBitRandom(int n)
            {
                Random r = new Random();
                byte[] data = new byte[n];
                r.NextBytes(data);
                BigInteger valor = new BigInteger(data);
                if (valor.Sign == -1)
                    valor *= -1;
                return valor;
                //return (int)r.Next((int)Math.Pow(2, n - 1) + 1, (int)Math.Pow(2, n) - 1);
            }

            BigInteger getLowLevelPrime(int n)
            {
                while (true)
                {
                    BigInteger prime_candidate = nBitRandom(nbit);

                    foreach (int divisor in first_primes_list)
                    {
                        if ((prime_candidate % divisor == 0) && (divisor * divisor <= prime_candidate))
                        {
                            break;
                        }
                        else
                        {
                            return prime_candidate;
                        }
                    }
                }
            }

            bool isMillerRabinPassed(BigInteger miller_rabin_candidate)
            {
                int maxDivisionsByTwo = 0;
                BigInteger evenComponent = miller_rabin_candidate + BigInteger.MinusOne;

                while ((evenComponent % 2) == 0)
                {
                    evenComponent >>= 1;
                    maxDivisionsByTwo += 1;
                }

                // assert(2**maxDivisionsByTwo * evenComponent == miller_rabin_candidate-1)

                bool trialComposite(BigInteger round_tester)
                {
                    if (BigInteger.ModPow(round_tester, evenComponent, miller_rabin_candidate) == 1)
                    {
                        return false;
                    }
                    for (int i = 0; i <= maxDivisionsByTwo; i++)
                    {
                        if (BigInteger.ModPow(round_tester, new BigInteger(Math.Pow(2, i)) * evenComponent,miller_rabin_candidate) == 1)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                int numberOfTrials = 20;

                for (int i = 0; i <= numberOfTrials; i++)
                {
                    Random rr = new Random();
                    //int round_tester = rr.Next(2, miller_rabin_candidate);
                    BigInteger round_tester = RandomIntegerBelow(miller_rabin_candidate);
                    if (trialComposite(round_tester))
                    {
                        return false;
                    }
                }
                return true;
            }

            

            while (true){
                int n = numeroDeBits;
                BigInteger prime_candidate = getLowLevelPrime(n);
                if (isMillerRabinPassed(prime_candidate))
                    return prime_candidate;
            }
                    
        }

        public static BigInteger RandomIntegerBelow(BigInteger N)
        {
            byte[] bytes = N.ToByteArray();
            BigInteger R;
            Random r = new Random();
            do
            {
                r.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F; //force sign bit to positive
                R = new BigInteger(bytes);
            } while (R >= N);
            //Console.WriteLine(R);
            return R;
        }
    }
}
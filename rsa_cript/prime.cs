using System;

namespace rsa_cript
{
    class prime
    {
        static void Main(string[] args)
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
            int nbit = 128; //número de bits

            int nBitRandom(int n)
            {
                Random r = new Random();
                return (int)r.Next((int)Math.Pow(2, n - 1) + 1, (int)Math.Pow(2, n) - 1);
            }

            int getLowLevelPrime(int n)
            {
                while (true)
                {
                    int prime_candidate = nBitRandom(nbit);

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

            int isMillerRabinPassed(int miller_rabin_candidate)
            {
                int maxDivisionsByTwo = 0;
                int evenComponent = miller_rabin_candidate - 1;

                while ((evenComponent % 2) == 0)
                {
                    evenComponent >>= 1;
                    maxDivisionsByTwo += 1;
                }
                return 0;
                // assert(2**maxDivisionsByTwo * evenComponent == miller_rabin_candidate-1)

                //difficultttttttt
            }
        }
    }
}
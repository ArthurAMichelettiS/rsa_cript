using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace rsa_cript
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    rsa();
                    break;
                }
                catch
                {
                    //Console.WriteLine("teste");
                    //empty
                }
            }
            
        }

        public static void rsa()
        {
            BigInteger primoP, primoQ;
            primoP = prime.obtemPrimo(32); //primos de 32 bits
            primoQ = prime.obtemPrimo(32);
            //primoP = 239;
            //primoQ = 331;

            if (primoP > primoQ)
            {
                BigInteger aux = primoQ;
                primoQ = primoP;
                primoP = aux;
            }
            BigInteger valorN = primoQ * primoP;

            BigInteger phi = (primoP - 1) * (primoQ - 1);

            BigInteger coprimeE = 3;
            while (Util.gcd(phi, coprimeE) != 1)
            {
                coprimeE = coprimeE + 2;
            }

            //                   coprimeE*valorD % phi = 1
            BigInteger valorD = Util.modInverse(coprimeE, phi);


            // The information security is of significant importance to ensure the privacy of communications
            Console.WriteLine(" Digite a mensagem:");
            string msg = Console.ReadLine();

            //E & N > chave publica
            long[] msgCript = criptografa(msg, coprimeE, valorN);

            //D & N > chave privada
            string msgDeCript = decriptografa(msgCript, valorD, valorN);

            Console.WriteLine(" Mensagem criptografada: " + numPraString(msgCript));
            Console.WriteLine(" Mensagem decriptografada: " + msgDeCript);
            Console.ReadKey();
        }


        public static string numPraString(long[] val)
        {
            string txt = "";
            foreach (long item in val)
            {
                txt += (char)item;
            }
            return txt;
        }

        public static long[] criptografa(string msg,BigInteger e, BigInteger N)
        {
            long[] novaMsg = new long[msg.Length];
            int cont = 0;
            foreach (char c in msg)
            {
                long novoVal = (long)BigInteger.ModPow(c, e, N);

                novaMsg[cont]= (novoVal);
                cont += 1;
            }

            # region a;
            //for (int i = 0; i < msg.Length; i += 3)
            //{
            //    string temp = msg.Substring(i, 3);
            //    BigInteger txtConvertido = new BigInteger(Encoding.UTF8.GetBytes(temp));
            //    byte[] bytes = BigInteger.ModPow(txtConvertido, e, N).ToByteArray();
            //    novaMsg += Encoding.UTF8.GetString(bytes);
            //}
            //BigInteger txtConvertido = new BigInteger(Encoding.UTF8.GetBytes(msg));
            //byte[] bytes = BigInteger.ModPow(txtConvertido, e, N).ToByteArray();
            //novaMsg = Encoding.UTF8.GetString(bytes);
            #endregion

            return novaMsg;
        }

        public static string decriptografa(long[] msg, BigInteger d, BigInteger N)
        {
            string novaMsg = "";
            foreach (long c in msg)
            {
                long novoVal = (long)BigInteger.ModPow(c, d, N);

                novaMsg += (char)(novoVal);
            }

            # region a;
            //for (int i = 0; i < msg.Length; i += 3)
            //{
            //    string temp = msg.Substring(i, 3);
            //    BigInteger txtConvertido = new BigInteger(Encoding.UTF8.GetBytes(temp));
            //    byte[] bytes = BigInteger.ModPow(txtConvertido, d, N).ToByteArray();
            //    novaMsg += Encoding.UTF8.GetString(bytes);
            //}

            //BigInteger txtConvertido = new BigInteger(Encoding.UTF8.GetBytes(msg));
            //byte[] bytes = BigInteger.ModPow(txtConvertido, d, N).ToByteArray();
            //novaMsg = Encoding.UTF8.GetString(bytes);
            #endregion

            return novaMsg;
        }

    }
}

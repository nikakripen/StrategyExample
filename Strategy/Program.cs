using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            String key = "key";
            String text = "text";
            Encryption encryption = new Encryption(new DESAlgorithm());
            String cryptedText = encryption.crypt(text, key);

            Console.WriteLine(cryptedText);

            encryption.Algorithm = new RSAAlgorythm();
            cryptedText = encryption.crypt(text, key);

            Console.WriteLine(cryptedText);
        }    
    }

    public interface Algorithm
    {
        String crypt(String text, String key);
    }

    public class DESAlgorithm : Algorithm
    {
        public String crypt(String text, String key)
        {
            String cryptedString = null;
            // тело алгоритма

            cryptedString = "I'm cripted by DES";
            return cryptedString;
        }
    }

    public class RSAAlgorythm : Algorithm
    {
        public String crypt(String text, String key)
        {
            String cryptedString = null;
            // тело алгоритма
            cryptedString = "I'm cripted by RSA";
                return cryptedString;
        }
    }

    public class Encryption
    {
        private Algorithm algorithm;

        public Encryption(Algorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        public Algorithm Algorithm
        {
            set
            {
                this.algorithm = value;
            }
        }

        public string crypt(String text, String key)
        {
            return algorithm.crypt(text, key);
        }
    }
}

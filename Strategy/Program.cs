using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "key";
            string text = "text";
            var encryption = new Encryption(new DesAlgorithm());
            string cryptedText = encryption.Crypt(text, key);

            Console.WriteLine(cryptedText);

            encryption.SetAlgorithm( new RsaAlgorythm());
            cryptedText = encryption.Crypt(text, key);

            Console.WriteLine(cryptedText);
        }    
    }

    public interface IAlgorithm
    {
        String Crypt(string text, string key);
    }

    public class DesAlgorithm : IAlgorithm
    {
        public string Crypt(string text, string key)
        {
            string cryptedString = "I encripted by DES";
            return cryptedString;
        }
    }

    public class RsaAlgorythm : IAlgorithm
    {
        public string Crypt(string text, string key)
        {
            string cryptedString = "I encripted by RSA";
                return cryptedString;
        }
    }

    public class Encryption
    {
        private IAlgorithm _algorithm;

        public Encryption(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void SetAlgorithm(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public string Crypt(string text, string key)
        {
            return _algorithm.Crypt(text, key);
        }
    }
}

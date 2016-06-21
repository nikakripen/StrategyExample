using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Strategy
{
    class TestClass
    {
        [Test]
        public void TestCryptByDes()
        {
            string key = "key";
            string text = "text";

            var encryption = new Encryption(new DesAlgorithm());
            string cryptedText = encryption.Crypt(text, key);
            Assert.AreEqual(cryptedText, "I encripted by DES");
            Console.WriteLine(cryptedText);
        }

        [Test]
        public void TestCryptByRsa()
        {
            string key = "key";
            string text = "text";

            var encryption = new Encryption(new RsaAlgorithm());
            string cryptedText = encryption.Crypt(text, key);
            Assert.AreEqual(cryptedText, "I encripted by RSA");
            Console.WriteLine(cryptedText);
        }

        [Test]
        public void TestSetAlgorithm()
        {
            string key = "key";
            string text = "text";
            var encryption = new Encryption(new DesAlgorithm());
            string cryptedText = encryption.Crypt(text, key);

            Console.WriteLine(cryptedText);

            encryption.SetAlgorithm(new RsaAlgorithm());
            cryptedText = encryption.Crypt(text, key);

            Console.WriteLine(cryptedText);

            Assert.AreEqual(cryptedText, "I encripted by RSA");
        }


    }
}

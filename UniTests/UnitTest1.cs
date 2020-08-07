using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Enc;

namespace UniTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Encryption cry = new Encryption();
            bool check = cry.TMethod();
            Assert.AreEqual(true, check);
        }


        [TestMethod]
        public void Changling()
        {
            Encryption cry = new Encryption();
            string s = cry.Change();
            Assert.AreEqual("Введите название файла", s) ;
        }

        [TestMethod]
        public void Crypt()
        {
            Encryption cry = new Encryption();
            string s = cry.EncVis("привет, я делаю тестики", "кодировка");
            Assert.AreEqual("ъямкхб, б оецов ыхафуку", s);
        }

    }
}

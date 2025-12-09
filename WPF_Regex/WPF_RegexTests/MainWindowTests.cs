using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_Regex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Testing.Platform.Extensions.Messages;

namespace WPF_Regex.Tests
{
    [TestClass()]


    public class MainWindowTests
    {
        [TestMethod()]
        [DataRow("123.123.123.123")]
        [DataRow("255.192.131.14")]
        [DataRow("127.0.0.1")]
        public void IpCheckTest(string ip)
        {
           
            Assert.IsTrue(MainWindow.IpCheck(ip));
        }

        [TestMethod()]
        [DataRow("127.100.100.100jdjk")]
        [DataRow("127.100.100.")]
        [DataRow("127.100.100:0")]
        [DataRow("127.100.éá.120")]
        [DataRow(".100.0.120")]
        [DataRow("255.192.600.120")]
        
        public void IpCheckFalseTest(string ip)
        {
          Assert.IsFalse(MainWindow.IpCheck(ip));
        }
    }
}
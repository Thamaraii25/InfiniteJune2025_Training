using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RailwayReservationADO
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow("admin@gmail.com", "admin123", true)]
        [DataRow("Thamarai@gmail.com", "thamarai123", true)]
        [DataRow("user1", "wrongPassword", false)]
        [DataRow("", "", false)]
        public void AdminLoginCheckTests(string email, string password, bool expectedResult)
        {
            bool result = Home.ValidateAdmin(email, password);
            Assert.AreEqual(expectedResult, result);
        }
    }
}

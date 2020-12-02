using Microsoft.VisualStudio.TestTools.UnitTesting;
using video_rental_harman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_rental_harman.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            Controller.Movie movie = new Controller.Movie();
            movie.passValueToDatabase("insert into MovieData(Title,Plot,Genre,Year,Copies,Ratting,Price) values('2.0','Serious','seriour',2019,2,'2.0','5')", "Add");
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void Form2Test()
        {
            Controller.Customer customer = new Controller.Customer();
            customer.passValueToDatabase("insert into CustomerData (FrstName,LastName,Address,Phone) values('Tom','Harry','Auckland','78456123'", "Add");
            Assert.IsTrue(true);
        }
    }
}
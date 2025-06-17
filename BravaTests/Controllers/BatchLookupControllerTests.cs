using Brava.Controllers;
using BravaTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Controllers
{
    public class BatchLookupControllerTests
    {
        [Fact]
        public void Index_ReturnsViewData()
        {
            //arrange
            var batchLookupControler = new BatchLookupController();

            //act
            var result = batchLookupControler.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using SouthernCrossPublicAPI;
using SouthernCrossPublicAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace APITestProject
{
    public class SchsMemberControllerTest
    {
        private Mock<IConfiguration> _config;
        private Mock<IHostingEnvironment> _env;
        private SchsMemberController _controller;

        public SchsMemberControllerTest()
        {
            _config = new Mock<IConfiguration>();
            _env = new Mock<IHostingEnvironment>();
            _config.SetupGet(x => x[It.Is<string>(s => s == "MOCK_DATA")]).Returns(@"DataFile\MOCK_DATA.json");
            _env.Setup(x => x.ContentRootPath).Returns(string.Empty);
            _controller = new SchsMemberController(_config.Object, _env.Object);
        }

        [Fact]
        public void Get_returns_OkObjectResult_When_Application_work()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAllMembers_returns_true_when_Data_Is_Available()
        {

            var methodInfo = typeof(SchsMemberController).GetMethod("GetAllMembers", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = methodInfo.Invoke(_controller, null);

            Assert.True(result is List<SchsMember>);
            Assert.True(((List<SchsMember>)result).Count > 0);
        }

        [Fact]
        public void SearchMembers_When_Pass_Invalid_Paramenters_ThrowsArgumentException()
        {
            Assert.Throws<Exception>(() => _controller.SearchMembers("", ""));
        }

        [Theory]
        [InlineData("0345353","")]
        [InlineData("32424", "24242")]
        [InlineData("42424", "2686")]
        [InlineData("00003453", "")]
        public void SearchMembers_When_Pass_Valid_Paramenters_ReturnsOkResult(string policyNumber,string memberCardNumber)
        {
            var reuslt = _controller.SearchMembers(policyNumber, memberCardNumber);

            Assert.IsType<OkObjectResult>(reuslt as OkObjectResult);
        }
    }
}

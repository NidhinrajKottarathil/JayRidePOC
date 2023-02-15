using Contracts.BusinessLogic;
using FluentAssertions;
using JayRidePOC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Candidate;
using NSubstitute;

namespace UnitTests
{
    public class CandidateControllerTests
    {
        private readonly CandidateController _candidateController;
        private readonly ICandidateLogic _candidateLogic;

        public CandidateControllerTests()
        {
            _candidateLogic = Substitute.For<ICandidateLogic>();
            _candidateController = new CandidateController(_candidateLogic);
        }

        [Fact]
        public async Task CandidateInfo_ShouldReturnCandidateInfo()
        {
            // Arrange
            _candidateLogic.GetCandidateInfo().Returns(new Candidate
            {
                Name = "test",
                Phone = "test"
            });

            // Act
            var actionResult = await _candidateController.CandidateInfo();
            var okResult = (OkObjectResult)actionResult.Result;
            var response = okResult.Value as Candidate;

            // Assert
            response.Should().NotBeNull();
            response.Name.Should().Be("test");
            response.Phone.Should().Be("test");
        }
    }
}
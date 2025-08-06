using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async Task Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //Arrange -- tanýmlamalarýn yapýldýðý parca, gerekli parametreler tanýmlanabilir.

            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new("Test arac", "Test Model", 1200);
            MessageResponse messageResponse = new("Arac basariyla kaydedildi!");
            CancellationToken cancellationToken = new CancellationToken();

            mediatorMock.Setup(m=> m.Send(createCarCommand, cancellationToken)).ReturnsAsync(messageResponse);

            CarsController carsController = new(mediatorMock.Object);

            //Act   -- iþlemi yaptýrýrz sonucu deðiþkene atariz.

            var result = await carsController.Create(createCarCommand, cancellationToken);
                
            //Assert -- kontrol kýsmý

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

            Assert.Equal(messageResponse, returnValue);

            mediatorMock.Verify(m=> m.Send(createCarCommand, cancellationToken),Times.Once());
        }
    }
}
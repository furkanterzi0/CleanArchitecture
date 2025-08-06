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
            //Arrange -- tan�mlamalar�n yap�ld��� parca, gerekli parametreler tan�mlanabilir.

            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new("Test arac", "Test Model", 1200);
            MessageResponse messageResponse = new("Arac basariyla kaydedildi!");
            CancellationToken cancellationToken = new CancellationToken();

            mediatorMock.Setup(m=> m.Send(createCarCommand, cancellationToken)).ReturnsAsync(messageResponse);

            CarsController carsController = new(mediatorMock.Object);

            //Act   -- i�lemi yapt�r�rz sonucu de�i�kene atariz.

            var result = await carsController.Create(createCarCommand, cancellationToken);
                
            //Assert -- kontrol k�sm�

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

            Assert.Equal(messageResponse, returnValue);

            mediatorMock.Verify(m=> m.Send(createCarCommand, cancellationToken),Times.Once());
        }
    }
}
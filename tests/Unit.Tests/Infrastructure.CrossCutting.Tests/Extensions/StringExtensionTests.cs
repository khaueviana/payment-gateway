namespace PaymentGateway.Infrastructure.CrossCutting.Tests.Extensions
{
    public class StringExtensionTests
    {
        [Fact]
        public void Mask_Text_ReturnsTextMasked()
        {
            // Arrange
            var text = "TEXT";

            // Act
            var result = text.Mask(0, text.Length - 1);

            // Assert
            result.Should().Be("XXXT");
        }
    }
}

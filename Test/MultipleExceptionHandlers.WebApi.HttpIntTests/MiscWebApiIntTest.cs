using System.Net;

using FluentAssertions;

using NUnit.Framework;

namespace MultipleExceptionHandlers.WebApi.HttpIntTests;

[TestFixture]
internal class MiscWebApiIntTest : WebApiIntTest
{
    private static string GetWeatherForecastUrl(string resourceId = "")
    {
        return $"/v1/weatherforecast/{resourceId}";
    }

    [Test]
    public void CanInvokeWeatherForecastEndpoint()
    {
        HttpClient.GetStringAsync(GetWeatherForecastUrl())
            .Result.Should()
            .NotBeEmpty();
    }

    [Test]
    public void GivenWeatherForecastIdIs666ThenItShouldReturnForbiddenFoundWithCustomErrorMessage()
    {
        HttpResponseMessage result = HttpClient.GetAsync(GetWeatherForecastUrl("666"))
            .Result;
        result.StatusCode.Should()
            .Be(HttpStatusCode.Forbidden);
        result.Content.ReadAsStringAsync()
            .Result.Should()
            .Contain("is a no-no");
    }

    [Test]
    public void GivenWeatherForecastIdIsZeroThenItShouldReturnNotFoundWithCustomErrorMessage()
    {
        HttpResponseMessage result = HttpClient.GetAsync(GetWeatherForecastUrl("0"))
            .Result;
        result.StatusCode.Should()
            .Be(HttpStatusCode.NotFound);
        result.Content.ReadAsStringAsync()
            .Result.Should()
            .Contain("Uh oh");
    }
}



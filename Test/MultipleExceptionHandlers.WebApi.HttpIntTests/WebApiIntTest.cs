using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Mvc.Testing;

namespace MultipleExceptionHandlers.WebApi.HttpIntTests;

internal abstract class WebApiIntTest
{
    #region Public members

    public static HttpClient HttpClient { get; }

    #endregion

    #region Non-Public members

    ///<summary>One-time only construction logic.</summary>
    [ExcludeFromCodeCoverage]
    static WebApiIntTest()
    {
        HttpClient = _factory.CreateClient();
    }

    private static readonly WebApplicationFactory<Program> _factory = new();

    #endregion
}



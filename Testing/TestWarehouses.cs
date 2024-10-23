global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestWarehouses
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestWarehouses()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

     [TestMethod]
     public async Task TestGetWarehouses()
     {

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/warehouses");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        // Check response
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");

        // Check content
        string responseBody = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBody, "Response body is null");
     }
}
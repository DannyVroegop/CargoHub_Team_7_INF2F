global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
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

        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/warehouses");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        // Check response
        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/warehouses");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");

        // Check one
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/warehouses/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");
        string expectedJson = @"{
            ""id"": 1,
            ""code"": ""RTRSPOL"",
            ""name"": ""Rotterdam Spaanse Polder Giessenweg"",
            ""address"": ""Giessenweg 20"",
            ""zip"": ""3044 BA"",
            ""city"": ""Rotterdam"",
            ""province"": ""Zuid-Holland"",
            ""country"": ""NL"",
            ""contact"": {
                ""name"": ""John Doe"",
                ""phone"": ""06-12345678"",
                ""email"": ""john@rtrspol.warehousing.eu""
            },
            ""created_at"": ""2024-02-03 13:12:00"",
            ""updated_at"": ""2024-02-03 13:12:00""
        }";
        // var responseJsonDocument = JsonDocument.Parse(responseBodyone);
        // var expectedJsonDocument = JsonDocument.Parse(expectedJson);
        string responseBodyonenowhite = responseBodyone.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string expectedJsonnowhite = expectedJson.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Console.WriteLine(responseBodyone);
        Console.WriteLine(expectedJson);
        Assert.AreEqual(responseBodyonenowhite, expectedJsonnowhite);

     }
}
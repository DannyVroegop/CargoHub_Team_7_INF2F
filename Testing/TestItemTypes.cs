global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestItem_Types
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestItem_Types()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }
    [TestMethod] //7.1
    public async Task TestGetItem_Types()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_types");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_types");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //7.2
    public async Task GetSingleItem_Type()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_types/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");

        string expectedBody = @"{
            ""id"": 1,
            ""name"": ""Power Tools"",
            ""description"": ""Tools powered by electric motors or batteries, including drills, saws, and sanders."",
            ""created_at"": ""2024-04-10T08:30:00Z"",
            ""updated_at"": ""2024-04-11T09:00:00Z""
        }";
        string expectednowhite = expectedBody.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBodyone.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectednowhite, responsenowhite);
    }

    [TestMethod] //7.3 
    public async Task TestGetItem_TypeItems()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_types/1/items");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBody = await one.Content.ReadAsStringAsync();

        Assert.IsNotNull(responseBody, "Response body is null");

            string expectedcontents = @"[
            ""item_id"": 1,
            ""item_id"": 2
        ]"; // moet nog verranderd worden

        string expectednowhite = expectedcontents.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBody.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectednowhite, responsenowhite);
    }
}
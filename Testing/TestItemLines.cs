global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Test;
[TestClass]
public class UnitTestItem_Lines
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestItem_Lines()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //5.1
    public async Task TestGetAllItem_Lines()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_lines");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_lines");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //5.2
    public async Task TestGetSingleItem_Line()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_lines/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        
        string expectedBodyItemLine = @"{
            ""id"": 1,
            ""name"": ""Construction Materials"",
            ""description"": ""A comprehensive range of building and construction materials including cement, bricks, and tiles."",
            ""created_at"": ""2024-03-05T09:00:00Z"",
            ""updated_at"": ""2024-03-06T10:00:00Z""
        }"; // moet nog verranderd worden

        string expectednowhite = expectedBodyItemLine.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBodyone.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");

        Assert.AreEqual(expectednowhite, responsenowhite);
    }

    [TestMethod] //5.3
    public async Task TestGetItem_LineItems()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/item_lines/1/items");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyitems = await one.Content.ReadAsStringAsync();
                
        string expectedcontents = @"[
            ""item_id"": 1,
            ""item_id"": 2
        ]"; // moet nog verranderd worden

        string expectednowhite = expectedcontents.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBodyitems.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectednowhite, responsenowhite);
    }
}
global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestInventories
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestInventories()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //8.1
    public async Task TestGetInventories()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/inventories");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/inventories");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod]
    public async Task TestGetSingleInventory()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/inventories/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");

        string expectedBody = @"{
            ""id"": 1,
            ""item_id"": 1,
            ""description"": ""High Precision Bearings"",
            ""item_reference"": ""REF123"",
            ""location_id"": 1,
            ""total_on_hand"": 150,
            ""total_expected"": 200,
            ""total_ordered"": 50,
            ""total_allocated"": 100,
            ""total_available"": 50,
            ""created_at"": ""2024-03-20T10:00:00Z"",
            ""updated_at"": ""2024-03-21T11:00:00Z""
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
}

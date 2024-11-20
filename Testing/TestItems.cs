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
public class UnitTestItems
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestItems()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //4.1
    public async Task TestGetItems()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/items");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/items");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //4.2
    public async Task TestGetSingleItem()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/items/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        string expectedTransfer = @"
        {
            ""id"": 1,
            ""reference"": ""TRANS001"",
            ""transfer_from"": 1,
            ""transfer_to"": 2,
            ""transfer_status"": ""Scheduled | Processed"",
            ""created_at"": ""2024-05-01T14:00:00Z"",
            ""updated_at"": ""2024-05-02T15:00:00Z"",
            ""items"": [
                {
                    ""item_id"": 1,
                    ""amount"": 50
                },
                {
                    ""item_id"": 2,
                    ""amount"": 30
                }
            ]
        }";

        string expectednowhite = expectedTransfer.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBodyone.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");

        Assert.AreEqual(expectednowhite, responsenowhite);
    }

    [TestMethod] //4.3
    public async Task TestGetInventoryOfItem()
    {
        var requestitems = new HttpRequestMessage(HttpMethod.Get, "/api/v1/items/1/inventory");
        requestitems.Headers.Add("API_KEY", ApiKey);
        var items = await _client.SendAsync(requestitems);

        Assert.IsTrue(items.IsSuccessStatusCode, "API call was not successful");

        string responseBodyitems = await items.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyitems, "Response body is null");
        // comparebodies

        string expectedcontents = @"
        {
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
        }"; // moet nog verranderd worden


        string responseBodylocnowhite = responseBodyitems.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string expectedJsonnowhite = expectedcontents.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectedJsonnowhite, responseBodylocnowhite);
    }

    [TestMethod] //4.4
    public async Task TestGetInventoryTotalsOfItem()
    {
        var requestitems = new HttpRequestMessage(HttpMethod.Get, "/api/v1/items/1/inventory/totals");
        requestitems.Headers.Add("API_KEY", ApiKey);
        var items = await _client.SendAsync(requestitems);

        Assert.IsTrue(items.IsSuccessStatusCode, "API call was not successful");

        string responseBodyitems = await items.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyitems, "Response body is null");
        // comparebodies

        string expectedcontents = @"{
            ""total_expected"": 200,
            ""total_ordered"": 50,
            ""total_allocated"": 100,
            ""total_available"": 50
        }"; // moet nog verranderd worden


        string responseBodylocnowhite = responseBodyitems.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string expectedJsonnowhite = expectedcontents.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectedJsonnowhite, responseBodylocnowhite);
    }
}
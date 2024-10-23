global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestTransfers
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestTransfers()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod]
    public async Task TestGetTransfers()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/transfers");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/transfers");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod]
    public async Task TestGetOneTransfer()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/transfers/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");
        string expectedTransfer = @"{
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
}
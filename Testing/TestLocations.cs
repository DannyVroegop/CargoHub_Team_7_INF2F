global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;

[TestClass]
public class UnitTestLocations
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestLocations()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod]
     public async Task TestGetAllLocations()
     {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/locations");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");


        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/locations");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
     }

     [TestMethod]
     public async Task TestGetOneLocation()
    {
        // Request one
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/locations/10");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseloc = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseloc, "Response body is null");

        string expectedlocation = "{\n" +
                    "    \"id\": 10,\n" +
                    "    \"warehouse_id\": 1,\n" +
                    "    \"code\": \"A.2.4\",\n" +
                    "    \"name\": \"Row: A, Rack: 2, Shelf: 4\",\n" +
                    "    \"created_at\": \"2024-04-24 10:23:44\",\n" +
                    "    \"updated_at\": \"2024-04-24 10:23:44\"\n" +
                    "}";
        string responseBodylocnowhite = responseloc.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string expectedJsonlocnowhite = expectedlocation.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectedJsonlocnowhite, responseBodylocnowhite);
    }
}
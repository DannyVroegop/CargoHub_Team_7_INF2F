global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestShippments
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestShippments()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //12.1
    public async Task TestGetShipments()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/shipments");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/shipments");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //12.2
    public async Task TestGetSingleShipment()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/shipments/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");

        string expectedBody = @"
        {
            ""id"": 1,
            ""order_id"": 1,
            ""source_id"": 501,
            ""order_date"": ""2024-05-01"",
            ""request_date"": ""2024-05-03"",
            ""shipment_date"": ""2024-05-05"",
            ""shipment_type"": ""Incoming | Outgoing"",
            ""shipment_status"": ""Scheduled | Transit | Delivered"",
            ""notes"": ""Express shipment for urgent requirement."",
            ""carrier_code"": ""UPS"",
            ""carrier_description"": ""United Parcel Service"",
            ""service_code"": ""NextDay"",
            ""payment_type"": ""Cash | Check | Bank | Bitcoin"",
            ""transfer_mode"": ""Freight | Ship | Air"",
            ""total_package_count"": 10,
            ""total_package_weight"": 200.5,
            ""created_at"": ""2024-05-01T12:00:00Z"",
            ""updated_at"": ""2024-05-02T14:00:00Z"",
            ""items"": [
                {
                    ""item_id"": 1,
                    ""amount"": 5
                },
                {
                    ""item_id"": 2,
                    ""amount"": 10
                }
            ]
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

    [TestMethod] //12.3
    public async Task TestGetShipmentOrders()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/shipments/1/orders");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBody = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBody, "Response body is null");

        string expectedBody = @"[
            1
        ]";

        string expectednowhite = expectedBody.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        string responsenowhite = responseBody.Replace(" ", "")
                     .Replace("\t", "")
                     .Replace("\n", "")
                     .Replace("\r", "");
        Assert.AreEqual(expectednowhite, responsenowhite);
    }

    [TestMethod] //12.4
    public async Task TestGetShipmentItems()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/shipments/1/items");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBody = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBody, "Response body is null");

                string expectedBody = @"[
    {
        ""item_id"": 1,
        ""amount"": 5
    },
    {
        ""item_id"": 2,
        ""amount"": 10
    }
]";

        string expectednowhite = expectedBody.Replace(" ", "")
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
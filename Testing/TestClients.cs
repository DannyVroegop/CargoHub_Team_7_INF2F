global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestClients
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestClients()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //11.1
    public async Task TestGetOrders()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/clients");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/clients");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //11.2
    public async Task TestGetSingleClient()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/clients/1");
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
            ""name"": ""Acme Corporation"",
            ""address"": ""123 Main Street"",
            ""city"": ""Anytown"",
            ""zip_code"": 12345,
            ""province"": ""Stateville"",
            ""country"": ""United States"",
            ""contact_name"": ""John Doe"",
            ""contact_Phone"": ""+1 (555) 123-4567"",
            ""contact_Email"": ""john.doe@acmecorp.com"",
            ""created_at"": ""2024-04-24 10:30:00"",
            ""updated_at"": ""2024-04-24 10:30:00""
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

    [TestMethod] //11.3
    public async Task TestGetClientOrders()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/clients/1/orders");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBody = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBody, "Response body is null");

        string expectedBody = @"
        [
            {
                ""id"": 1,
                ""source_id"": 101,
                ""order_date"": ""2024-05-01T13:45:00Z"",
                ""request_date"": ""2024-05-05T00:00:00Z"",
                ""reference"": ""ORD001"",
                ""reference_extra"": ""First bulk order"",
                ""order_status"": ""Scheduled | Packed | Delivered"",
                ""notes"": ""Please ensure timely delivery."",
                ""shipping_notes"": ""Handle with care."",
                ""picking_notes"": ""Verify items before dispatch."",
                ""warehouse_id"": 3,
                ""ship_to"": 1,
                ""bill_to"": 1,
                ""shipment_id"": 1,
                ""total_amount"": 5000.0,
                ""total_discount"": 100.0,
                ""total_tax"": 475.0,
                ""total_surcharge"": 30.0,
                ""created_at"": ""2024-05-01T13:45:00Z"",
                ""updated_at"": ""2024-05-02T09:30:00Z"",
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
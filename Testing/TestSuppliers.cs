global using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test;
[TestClass]
public class UnitTestSuppliers
{
    private readonly HttpClient _client;
    private const string ApiKey = "a1b2c3d4e5";
    public UnitTestSuppliers()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://127.0.0.1:3000");
    }

    [TestMethod] //9.1
    public async Task TestGetSuppliers()
    {
        var requestall_wo_key = new HttpRequestMessage(HttpMethod.Get, "/api/v1/suppliers");
        // Without key should be false
        var wo_key = await _client.SendAsync(requestall_wo_key);
        Assert.IsFalse(wo_key.IsSuccessStatusCode, "API call was successful (It should not be)");

        var requestall = new HttpRequestMessage(HttpMethod.Get, "/api/v1/suppliers");
        requestall.Headers.Add("API_KEY", ApiKey);
        var all = await _client.SendAsync(requestall);
        Assert.IsTrue(all.IsSuccessStatusCode, "API call was not successful");
        // Check content
        string responseBodyall = await all.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyall, "Response body is null");
    }

    [TestMethod] //9.2
    public async Task TestGetSingleSupplier()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/suppliers/1");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");

        string expectedBody = @"{
            ""id"": 1,
            ""code"": ""SUP001"",
            ""name"": ""TechMart Electronics"",
            ""address"": ""123 Main Street"",
            ""address_extra"": ""Suite 200"",
            ""city"": ""Metropolis"",
            ""zip_code"": ""12345"",
            ""province"": ""Techland"",
            ""country"": ""United States"",
            ""contact_name"": ""John Doe"",
            ""phonenumber"": ""+1 (555) 123-4567"",
            ""reference"": ""TM-SUP001"",
            ""created_at"": ""2024-02-03 13:12:00"",
            ""updated_at"": ""2024-02-03 13:12:00""
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

    [TestMethod] //9.3
    public async Task TestGetSupplierItems()
    {
        var requestone = new HttpRequestMessage(HttpMethod.Get, "/api/v1/suppliers/1/items");
        requestone.Headers.Add("API_KEY", ApiKey);
        var one = await _client.SendAsync(requestone);
        // response
        Assert.IsTrue(one.IsSuccessStatusCode, "API call was not successful");
        // content
        string responseBodyone = await one.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseBodyone, "Response body is null");

        string expectedBody = @"[
            {
                ""uid"": ""P001"",
                ""code"": ""ABC123"",
                ""description"": ""High-performance laptop"",
                ""short_description"": ""Laptop"",
                ""upc_code"": ""123456789012"",
                ""model_number"": ""LT-2024"",
                ""commodity_code"": ""IT-EQUIP"",
                ""item_line"": ""Tech Gadgets"",
                ""item_group"": ""Electronics"",
                ""item_type"": ""Laptop"",
                ""unit_purchase_quantity"": 1,
                ""unit_order_quantity"": 1,
                ""pack_order_quantity"": 1,
                ""supplier_id"": 1,
                ""supplier_code"": ""SUP001"",
                ""supplier_part_number"": ""LT-2024-ABC"",
                ""created_at"": ""2024-02-03 13:12:00"",
                ""updated_at"": ""2024-02-03 13:12:00""
            }
        ]";

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
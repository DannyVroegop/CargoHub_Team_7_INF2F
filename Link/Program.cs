using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private static string jsonFilePath;
    private static List<Dictionary<string, object>> previousData = new();
    private static DateTime lastReadTime = DateTime.MinValue;

    static async Task Main(string[] args)
    {
        // Determine the parent directory dynamically
        string basePath = Directory.GetParent(
            Directory.GetCurrentDirectory())?.ToString() ?? string.Empty;

        jsonFilePath = Path.Combine(basePath, "warehousing/data/warehouses.json");
        Console.WriteLine($"Monitoring JSON file at: {jsonFilePath}");

        // Initial read of the file
        if (File.Exists(jsonFilePath))
        {
            previousData = LoadJsonData();
        }

        // Set up file watcher
        using var watcher = new FileSystemWatcher
        {
            Path = Path.GetDirectoryName(jsonFilePath) ?? ".",
            Filter = Path.GetFileName(jsonFilePath),
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        watcher.Changed += async (sender, eventArgs) =>
        {
            try
            {
                await OnJsonFileChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        };

        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Monitoring changes to warehouses.json. Press [Enter] to exit.");
        Console.ReadLine();
    }

    private static List<Dictionary<string, object>> LoadJsonData()
    {
        try
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonData) ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load JSON data: {ex.Message}");
            return new();
        }
    }

    private static async Task OnJsonFileChanged()
    {
        var now = DateTime.Now;

        // Debounce file change events
        if ((now - lastReadTime).TotalMilliseconds < 500 || !IsFileReady(jsonFilePath))
            return;

        lastReadTime = now;

        var updatedData = LoadJsonData();

        // Avoid reprocessing if data hasn't changed
        if (previousData.SequenceEqual(updatedData, new DictionaryComparer()))
            return;

        // Detect added objects
        var newObjects = updatedData.Except(previousData, new DictionaryComparer()).ToList();

        if (newObjects.Any())
        {
            foreach (var obj in newObjects)
            {
                Console.WriteLine($"New object detected: {JsonSerializer.Serialize(obj)}");
                await SendHttpPost(obj);
            }

            // Update previous data
            previousData = updatedData;
        }
    }

    private static bool IsFileReady(string path)
    {
        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return true;
            }
        }
        catch (IOException)
        {
            return false;
        }
    }

    private static async Task SendHttpPost(Dictionary<string, object> obj)
    {
        using var client = new HttpClient();

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(obj),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var response = await client.PostAsync("http://127.0.0.1:3000/api/v2/warehouses", jsonContent);
            Console.WriteLine($"POST Response: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send HTTP POST: {ex.Message}");
        }
    }

    // Updated DictionaryComparer
    private class DictionaryComparer : IEqualityComparer<Dictionary<string, object>>
    {
        public bool Equals(Dictionary<string, object> x, Dictionary<string, object> y)
        {
            if (x == null || y == null) return false;
            return JsonSerializer.Serialize(x) == JsonSerializer.Serialize(y);
        }

        public int GetHashCode(Dictionary<string, object> obj)
        {
            return JsonSerializer.Serialize(obj).GetHashCode();
        }
    }
}

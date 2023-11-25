using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // 設定API的端點和授權金鑰
        string endpoint = "https://api.openai.com/v1/images/generations";
        string apiKey = "_____YOUR_API_KEY_HERE_____";

        // 創建HttpClient並設定授權頭部
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // 創建請求的內容
            string jsonContent = @"
            {
                ""model"": ""dall-e-3"",
                ""prompt"": ""機器人、繪畫、人工智慧"",
                ""n"": 1,
                ""size"": ""1792x1024""
            }";
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // 發送POST請求
            HttpResponseMessage response = await client.PostAsync(endpoint, content);

            // 檢查響應
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("成功接收到回應！");
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"錯誤：{response.StatusCode}");
            }
        }
    }
}

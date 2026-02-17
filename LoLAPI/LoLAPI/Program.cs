using LoLAPI.Models;
using System.Text.Json;

namespace LoLAPI
{
    public class Program
    {
        public static string version = "1.0";
        public static List<string> languages = new List<string>();
        public static List<Champion> champions = new List<Champion>();

        static async Task Main(string[] args)
        {
            await LoadLanguages();
            string selectedLanguage = "hu_HU";
            await LoadChampions(selectedLanguage);

            Console.WriteLine($"Betöltve {champions.Count} champion {selectedLanguage} nyelven.");
        }

        public static async Task LoadLanguages()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://ddragon.leagueoflegends.com/cdn/languages.json";
                    var responseAPI = await client.GetStringAsync(url);
                    var response = JsonSerializer.Deserialize<string[]>(responseAPI);
                    if (response != null)
                    {
                        languages = response.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a betöltés közben: {ex.Message}");
            }
        }

        public static async Task LoadVersion()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://ddragon.leagueoflegends.com/api/versions.json";
                    var responseAPI = await client.GetStringAsync(url);
                    var response = JsonSerializer.Deserialize<string[]>(responseAPI);

                    if (response != null && response.Length > 0)
                    {
                        version = response[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a verziók betöltése közben. {ex.Message}");
            }
        }

        public static async Task LoadChampions(string language)
        {
            await LoadVersion();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://ddragon.leagueoflegends.com/cdn/{version}/data/{language}/champion.json";
                    var responseAPI = await client.GetStringAsync(url);
                    var response = JsonSerializer.Deserialize<ChampionDatas>(responseAPI);

                    if (response != null && response.Data != null)
                    {
                        champions = response.Data.Values.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a championok betöltése közben: {ex.Message}");
            }
        }
    }
}

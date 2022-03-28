using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UiPath.Platform.ResourceHandling;

namespace UiPathTeam.BasicTypes.ViewModel
{
    [ExcludeFromCodeCoverage]
    public class DummyBrowserService : IBrowserService
    {
        private readonly HttpClient _httpClient = new();

        private const string BaseURL = "https://jsonplaceholder.typicode.com/";

        public async Task<IEnumerable<BrowserItem>> GetChildrenAsync(BrowserItem parent = null, string filter = null, CancellationToken ct = new CancellationToken())
        {
            if (parent == null)
                return new List<BrowserItem> { new BrowserItem { ID = "posts", FullName = "Posts", IsFolder = true }, new BrowserItem { ID = "albums", FullName = "Albums", IsFolder = true } };

            var response = await _httpClient.GetAsync(BaseURL + parent.ID, ct);
            var responseStr = await response.Content.ReadAsStringAsync(ct);
            

            var root = JsonSerializer.Deserialize<Root[]>(responseStr, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
            var ret = new List<BrowserItem>();
            foreach (var a in root)
            {
                ret.Add(new BrowserItem() {FullName = a.Title, ID = a.Id.ToString()});
            }

            return ret;
        }


        public class Root
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
        }


        public class AutoNumberToStringConverter : JsonConverter<object>
        {
            public override bool CanConvert(Type typeToConvert)
            {
                return typeof(string) == typeToConvert;
            }
            public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.TryGetInt64(out long l) ?
                        l.ToString() :
                        reader.GetDouble().ToString();
                }
                if (reader.TokenType == JsonTokenType.String)
                {
                    return reader.GetString();
                }
                using (JsonDocument document = JsonDocument.ParseValue(ref reader))
                {
                    return document.RootElement.Clone().ToString();
                }
            }

            public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
using Newtonsoft.Json;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Omnisend.DTO;

public class CategoryDto : IBatchSupport
{
    [JsonProperty("categoryID")] public string CategoryId { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
    [JsonProperty("createdAt")] public string CreatedAt { get; set; }
    [JsonProperty("updatedAt")] public string UpdatedAt { get; set; }
    public string AlternateVersion { get; set; }
}
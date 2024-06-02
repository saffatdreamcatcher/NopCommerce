using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Extension.HomePageBlockAdmin;

public record HomePageBlockModel :BaseNopEntityModel
{
    [NopResourceDisplayName("Admin.HomepageBlockTitle")]
    public string HomepageBlockTitle { get; set; }
    [NopResourceDisplayName("Admin.HomepageBlockDisplayOrder")]
    public int HomepageBlockDisplayOrder { get; set; }
    [NopResourceDisplayName("Admin.HomepageBlockIsActive")]
    public bool HomepageBlockIsActive { get; set; }
    [NopResourceDisplayName("Admin.HomepageBlockCreatedOnUtc")]
    public DateTime HomepageBlockCreatedOnUtc { get; set; }
    [NopResourceDisplayName("Admin.HomepageBlockUpdateOnUtc")]
    public DateTime HomepageBlockUpdateOnUtc { get; set; }
}


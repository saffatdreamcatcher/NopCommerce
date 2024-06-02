using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Extension.HomePageSliderAdmin;

public record HomepageSliderModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Plugins.Widgets.Left.Picture")]
    [UIHint("Picture")]
    public int HomepageSliderPictureId { get; set; }
    public string HomepageSliderUrl { get; set; }
    public string HomepageSliderAlt { get; set; }
    public string HomepageSliderTitle { get; set; }
    public string HomepageSliderNavigationUrl { get; set; }
    public bool HomepageSliderVisibility { get; set; }
    public int HomepageSliderDisplayOrder { get; set; }
}
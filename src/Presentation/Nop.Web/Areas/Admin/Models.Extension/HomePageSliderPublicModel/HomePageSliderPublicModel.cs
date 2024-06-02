using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Extension.HomePageSliderPublicModel;

public record HomePageSliderPublicModel : BaseNopEntityModel
{
    public HomePageSliderPublicModel()
    {
        homepageSliderLeftImageModels = new List<HomepageSliderImageModel>();
        homepageSliderRightImageModels = new List<HomepageSliderImageModel>();
    }
    public List<HomepageSliderImageModel> homepageSliderLeftImageModels { get; set; }
    public List<HomepageSliderImageModel> homepageSliderRightImageModels { get; set; }
}
public record HomepageSliderImageModel : BaseNopEntityModel
{
    public string ImageUrl { get; set; }
    public string ImageAlt { get; set; }
    public string ImageTitle { get; set; }
    public string NavigationUrl { get; set; }

}


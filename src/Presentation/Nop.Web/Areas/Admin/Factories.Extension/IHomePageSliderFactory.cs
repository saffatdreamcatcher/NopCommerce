using Nop.Web.Areas.Admin.Models.Extension.HomePageSliderAdmin;
namespace Nop.Web.Areas.Admin.Factories.Extension;

public interface IHomePageSliderFactory
{
    Task<HomepageSliderListModel> PrepareHomepageSliderListModel(HomepageSliderSearchModel searchModel);
    Task InsertHomepageSlider(HomepageSliderModel homepageSliderModel);
    Task<HomepageSliderModel> GetHomepageSliderById(int Id);
    Task UpdateHomepageSlider(HomepageSliderModel homepageSliderModel);
}

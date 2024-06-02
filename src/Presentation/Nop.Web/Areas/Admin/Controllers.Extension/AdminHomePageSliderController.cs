using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Infrastructure;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.PublicHomePageSlider.Extension;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories.Extension;
using Nop.Web.Areas.Admin.Models.Extension.HomePageSliderAdmin;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers.Extension;
public class AdminHomePageSliderController : BaseAdminController
{
    private readonly IHomePageSliderService _homepageSliderService;
    private readonly IPermissionService _permissionService;
    private readonly IHomePageSliderFactory _homepageSliderFactory;
    private readonly IPictureService _pictureService;
    private readonly INotificationService _notificationService;
    private readonly IStaticCacheManager _staticCacheManager = EngineContext.Current.Resolve<IStaticCacheManager>();
    protected readonly IWorkContext _workContext;

    public AdminHomePageSliderController(IHomePageSliderService homepageSliderService,
        IPermissionService permissionService,
        IHomePageSliderFactory homepageSliderFactory,
        IPictureService pictureService,
        INotificationService notificationService,
        IWorkContext workContext)
    {
        _homepageSliderService = homepageSliderService;
        _permissionService = permissionService;
        _homepageSliderFactory = homepageSliderFactory;
        _pictureService = pictureService;
        _notificationService = notificationService;
        _workContext = workContext;
    }
    public virtual async Task<IActionResult> List()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageManufacturers))
            return AccessDeniedView();

        HomepageSliderSearchModel model = new HomepageSliderSearchModel();
        return View(model);
    }

    [HttpPost]
    public virtual async Task<IActionResult> List(HomepageSliderSearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageManufacturers))
            return AccessDeniedView();

        //prepare model
        var model = await _homepageSliderFactory.PrepareHomepageSliderListModel(searchModel);

        return Json(model);
    }

    public virtual async Task<IActionResult> Create()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageManufacturers))
            return AccessDeniedView();

        HomepageSliderModel model = new HomepageSliderModel();

        return View(model);
    }

    //[HttpPost]
    //public virtual async Task<IActionResult> Create(HomepageSliderModel model)
    //{
    //    model.HomepageSliderUrl = await _pictureService.GetPictureUrlAsync(model.HomepageSliderPictureId);

    //    await _homepageSliderFactory.InsertHomepageSlider(model);
    //    //await _staticCacheManager.RemoveByPrefixAsync("HomepageSlider");
    //    //await _staticCacheManager.RemoveByPrefixAsync("GetHomePageSliderS3");
    //    _notificationService.SuccessNotification("Homepage Slider Has Been Created");

    //    //return View(model);
    //    return RedirectToAction("List");
    //}

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public virtual async Task<IActionResult> Create(HomepageSliderModel model, bool continueEditing)
    {
        model.HomepageSliderUrl = await _pictureService.GetPictureUrlAsync(model.HomepageSliderPictureId);

        await _homepageSliderFactory.InsertHomepageSlider(model);
        _notificationService.SuccessNotification("Homepage Slider Has Been Created");

        if (!continueEditing)
            return RedirectToAction("List");
        //return RedirectToAction("Edit", new { Id = model.Id });
        return View(model);
    }


    public virtual async Task<IActionResult> Edit(int Id)
    {

        var model = await _homepageSliderFactory.GetHomepageSliderById(Id);
        return View(model);
    }

    
    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public virtual async Task<IActionResult> Edit(HomepageSliderModel model, bool continueEditing)
    {

        await _homepageSliderFactory.UpdateHomepageSlider(model);
        _notificationService.SuccessNotification("Homepage Slider Has Been Updated");


        if (!continueEditing)
            return RedirectToAction("List");

        return RedirectToAction("Edit", new { Id = model.Id });
    }


    //public async Task<IActionResult> GenerateHomePageSlider()
    //{
    //    await _staticCacheManager.RemoveByPrefixAsync("HomepageSlider");
    //    await _staticCacheManager.RemoveByPrefixAsync("GetHomePageSliderS3");
    //    var homepageSlider = await this.RenderViewComponentToStringAsync("HomepageSlider");

    //    _notificationService.SuccessNotification("HomePageSlider Cache Has Been Cleared");

    //    return RedirectToAction("List");
    //}

    [HttpPost]
    public virtual async Task<IActionResult> Delete(int id)
    {

        //try to get a manufacturer with the specified id
        var homepageSlider = await _homepageSliderService.HomepageSliderId(id);
        if (homepageSlider == null)
            return RedirectToAction("List");

        await _homepageSliderService.DeleteHomepageSlider(homepageSlider);
        await _staticCacheManager.RemoveByPrefixAsync("Nop.homepages.custom.sliderquery");


        return new NullJsonResult();

    }

    [HttpPost]
    public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
    {

        //try to get a manufacturer with the specified id
        var homepageSlider = await _homepageSliderService.GetHomepageSliderByIdsAsync(selectedIds.ToArray());
        if (homepageSlider == null)
            return RedirectToAction("List");



        await _homepageSliderService.DeleteHomepageSlidersAsync(homepageSlider);
        await _staticCacheManager.RemoveByPrefixAsync("Nop.homepages.custom.sliderquery");

        //_notificationService.SuccessNotification("Selected homepage sliders have been deleted");


        return new NullJsonResult();


        //ALTERNATE IMPLEMENTATION


        //    if (selectedIds == null || !selectedIds.Any())
        //        return NoContent();

        //    var currentVendor = await _workContext.GetCurrentVendorAsync();
        //    await _homepageSliderService.DeleteHomepageSlidersAsync((await _homepageSliderService.GetHomepageSliderByIdsAsync(selectedIds.ToArray()))
        //        .Where(p => currentVendor == null).ToList());


        //    _notificationService.SuccessNotification("Selected homepage sliders have been deleted");

        //    return Json(new { Result = true });
        //}
    }
}


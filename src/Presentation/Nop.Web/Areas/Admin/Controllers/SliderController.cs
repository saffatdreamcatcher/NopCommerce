using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Slide;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Slide;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Slider;
using Nop.Web.Framework.Mvc.Filters;
using QuestPDF.Infrastructure;
using ShimSkiaSharp;

namespace Nop.Web.Areas.Admin.Controllers;
public class SliderController : BaseAdminController
{

    protected readonly ISliderModelFactory _sliderModelFactory;
    protected readonly INotificationService _notificationService;
    protected readonly ILocalizationService _localizationService;
    protected readonly IInfoService _infoService;
    private readonly   IPictureService _pictureService;
    private readonly IStaticCacheManager _staticCacheManager = EngineContext.Current.Resolve<IStaticCacheManager>();
    private readonly IWebHostEnvironment _webHostEnvironment;



    public SliderController(ISliderModelFactory sliderModelFactory, INotificationService notificationService, ILocalizationService localizationService,
                            IPictureService pictureService, IWebHostEnvironment webHostEnvironment, IInfoService infoService)
    {
        _sliderModelFactory = sliderModelFactory;
        _notificationService = notificationService;
        _localizationService = localizationService;
        _pictureService = pictureService;
        _webHostEnvironment = webHostEnvironment;
        _infoService = infoService;
      
    }
    public IActionResult Index()
    {
        return RedirectToAction("List");

    }
    public virtual async Task<IActionResult> List()
    {


        //prepare model   here
        var model = await _sliderModelFactory.PrepareInfoSearchModelAsync(new InfoSearchModel());
        return View(model);

    }

    [HttpPost]
    public virtual async Task<IActionResult> List(InfoSearchModel searchModel)
     {


        //prepare model
        var model = await _sliderModelFactory.PrepareInfoSummaryListModelAsync(searchModel);
            return Json(model);
    }

    public virtual async Task<IActionResult> Create()
    {

        ////prepare model
        //var model = await _sliderModelFactory.PrepareInfoSummaryModelAsync(new InfoSummaryModel(), null);
        //return View(model);
        InfoSummaryModel model = new InfoSummaryModel();
        return View(model);
    }


    //[HttpPost]
    //public virtual async Task<IActionResult> Create(InfoSummaryModel model, bool continueEditing)
    //{

    //    string wwwRootPath = _webHostEnvironment.WebRootPath;

    //    if (model.ImageFile != null)
    //    {
    //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
    //        string sliderPath = Path.Combine(wwwRootPath, "images", "sliders");
    //        Directory.CreateDirectory(sliderPath);

    //        string filePath = Path.Combine(sliderPath, fileName);
    //        using (var fileStream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await model.ImageFile.CopyToAsync(fileStream);
    //        }

    //        model.Image =  fileName;
    //        model.ImageUrl = filePath;
    //    }
    //    if (ModelState.IsValid)
    //    {

    //        var info = model.ToEntity<Info>();

    //        await _infoService.InsertInfoAsync(info);
    //        //await _staticCacheManager.RemoveByPrefixAsync("Slider");
    //        //await _staticCacheManager.RemoveByPrefixAsync("GetSliderS3");
    //        _notificationService.SuccessNotification("Slider Has Been Created");
    //    }

    //    model = await _sliderModelFactory.PrepareInfoSummaryModelAsync(model, null, true);
    //    return View(model);
    //}






    [HttpPost]
    public virtual async Task<IActionResult> Create(InfoSummaryModel model, bool continueEditing)
    {

        string wwwRootPath = _webHostEnvironment.WebRootPath;
        string navigationUrl = null;
        var baseUrl = "https://localhost:44369";

        if (model.ImageFile != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
            string sliderPath = Path.Combine(wwwRootPath, "images", "sliders");
            Directory.CreateDirectory(sliderPath);

            string filePath = Path.Combine(sliderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            model.Image = fileName; 
            // Generate relative URL based on the file path relative to the web root
            navigationUrl = baseUrl + "/images/sliders/" + fileName;
            model.ImageUrl = navigationUrl;

        }

        if (ModelState.IsValid)
        {
            var info = model.ToEntity<Info>();

            await _infoService.InsertInfoAsync(info);
            //await _staticCacheManager.RemoveByPrefixAsync("Slider");
            //await _staticCacheManager.RemoveByPrefixAsync("GetSliderS3");
            _notificationService.SuccessNotification("Slider Has Been Created");
        }

        model = await _sliderModelFactory.PrepareInfoSummaryModelAsync(model, null, true);

        return View(model);
    }



}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Slider;

public partial record InfoSummaryModel : BaseNopEntityModel, IStoreMappingSupportedModel
{
    public InfoSummaryModel()
    {
        SelectedStoreIds = new List<int>();
        AvailableStores = new List<SelectListItem>();
        AvailableInfos = new List<SelectListItem>();
    }

    #region Properties

    //[UIHint("Picture")]
    //public int PictureId {  get; set; }    

    [NopResourceDisplayName("Admin.Slider.Fields.Image")]
    //[UIHint("Picture")]
    public string Image { get; set; }

    [NopResourceDisplayName("Admin.Slider.Fields.ImageUrl")]
    public string ImageUrl { get; set; }

    [NopResourceDisplayName("Admin.Slider.Fields.AlterText")]
    public string AlterText { get; set; }

    [UIHint("Picture")]
    public IFormFile? ImageFile { get; set; }

    public IList<SelectListItem> AvailableInfos { get; set; }
    public IList<SelectListItem> AvailableStores { get; set; }
    public IList<int> SelectedStoreIds { get; set; } 

    #endregion
}

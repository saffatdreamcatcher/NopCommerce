using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Slider;

public partial record InfoSearchModel : BaseSearchModel
{
    public InfoSearchModel()
    {
        AvailableStores = new List<SelectListItem>();
      
    }

    public int SearchStoreId { get; set; }
    public IList<SelectListItem> AvailableStores { get; set; }
    public bool HideStoresList { get; set; }
}

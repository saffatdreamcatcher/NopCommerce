using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Extendion.Homepage;
public partial class HomePageSlider: BaseEntity
{
    public int HomepageSliderPictureId { get; set; }
    public string HomepageSliderUrl { get; set; }
    public string HomepageSliderAlt { get; set; }
    public string HomepageSliderTitle { get; set; }
    public string HomepageSliderNavigationUrl { get; set; }
    public bool HomepageSliderVisibility { get; set; }
    public int HomepageSliderDisplayOrder { get; set; }
}

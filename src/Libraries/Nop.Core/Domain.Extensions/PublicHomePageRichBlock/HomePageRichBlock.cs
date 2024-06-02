using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Extensions.PublicHomePageBlock;
internal class HomePageRichBlock  : BaseEntity 
{
    public int HomepageRichBlockPictureId { get; set; }
    public string HomepageRichBlockPictureUrl { get; set; }
    public string HomepageRichBlockPictureAlt { get; set; }
    public string HomepageRichBlockPictureTitle { get; set; }
    public int HomePageBlockId { get; set; }
    public HomePageBlock HomePageBlocks { get; set; }
    public string HomepageRichBlockNavigationUrl { get; set; }
    public bool HomepageRichBlockVisibility { get; set; }
    public int HomepageRichBlockDisplayOrder { get; set; }
}

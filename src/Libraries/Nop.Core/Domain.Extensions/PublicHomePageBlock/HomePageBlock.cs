using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Extensions.PublicHomePageBlock;
public class HomePageBlock : BaseEntity
{
    public string HomepageBlockTitle { get; set; }
    public int HomepageBlockDisplayOrder { get; set; }
    public bool HomepageBlockIsActive { get; set; }
    public DateTime HomepageBlockCreatedOnUtc { get; set; }
    public DateTime HomepageBlockUpdateOnUtc { get; set; }
}

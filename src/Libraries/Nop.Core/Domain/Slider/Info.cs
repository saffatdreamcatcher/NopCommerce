using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Nop.Core.Domain.Slide;
public partial class Info : BaseEntity
{
    public string Image { get; set; }
    public string ImageUrl { get; set; }
    public string AlterText { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }

}

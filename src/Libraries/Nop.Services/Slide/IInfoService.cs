using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Core;
using Nop.Core.Domain.Slide;
using Nop.Core.Domain.Polls;

namespace Nop.Services.Slide;
public partial interface IInfoService

{ 
    Task<IPagedList<Info>> GetAllInfosAsync(string image = null, string imageUrl = null, string alterText = null,
                                             int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

    Task InsertInfoAsync(Info info);
    Task UpdateInfoAsync(Info info);
    Task DeleteInfoAsync(Info info);


}

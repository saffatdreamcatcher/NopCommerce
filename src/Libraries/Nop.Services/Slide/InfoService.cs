using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Slide;
using Nop.Data;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Stores;

namespace Nop.Services.Slide;
public class InfoService : IInfoService
{
    private readonly IRepository<Info> _infoRepository;
    protected readonly IStoreMappingService _storeMappingService;
    

    public InfoService(IRepository<Info> infoRepository,
                       IStoreMappingService storeMappingService)
    { 
        _infoRepository = infoRepository;
        _storeMappingService = storeMappingService;
        
    }


    public virtual async Task<IPagedList<Info>> GetAllInfosAsync(string image, string imageUrl, string alterText, int pageIndex, int pageSize, bool showHidden = false)
    {
       
        var query = _infoRepository.Table;


        //if (!string.IsNullOrWhiteSpace(image))
        //    query = query.Where(i => i.Image.Contains(image));
        //if (!string.IsNullOrWhiteSpace(imageUrl))
        //        query = query.Where(i => i.ImageUrl.Contains(imageUrl));
        //    if (!string.IsNullOrWhiteSpace(alterText))
        //        query = query.Where(i => i.AlterText.Contains(alterText));

        //return paged list of infos
        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    public virtual async Task InsertInfoAsync(Info info)
    {
        await _infoRepository.InsertAsync(info);
    }

    public virtual async Task UpdateInfoAsync(Info info)
    {
        await _infoRepository.UpdateAsync(info);
    }

    public virtual async Task DeleteInfoAsync(Info info)
    {
        await _infoRepository.DeleteAsync(info);
    }
}

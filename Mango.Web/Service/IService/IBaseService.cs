﻿using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<CommonResponseDto> SendAsync(RequestDto request);
    }
}

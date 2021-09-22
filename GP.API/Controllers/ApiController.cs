using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Controllers
{
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    [ApiController]
    public abstract class ApiController : Controller
    {
        //protected bool VersionIsAtLeast(int majorVersion, int minorVersion)
        //{
        //    return HttpContext.GetRequestedApiVersion() >= new ApiVersion(majorVersion, minorVersion);
        //}

    }
}

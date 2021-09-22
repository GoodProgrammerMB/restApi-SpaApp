using GP.Domain.Contracts.Services;
using GP.Shared.Dto.PublishingHouses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingHouseController : ControllerBase
    {
        private readonly IPublishingHouseService _publishingHouseService;

        public PublishingHouseController(IPublishingHouseService publishingHouseService)
        {
            _publishingHouseService = publishingHouseService;
        }

        [HttpGet("all")]
        public async Task<List<PublishingHouseDto>> GetAll()
        {
            return await _publishingHouseService.Get();
        }

        [HttpPost("submit")]
        public async Task<PublishingHouseDto> Submit([FromBody] PublishingHouseDto model)
        {
            var result = await _publishingHouseService.Create(model);
            return model;
        }
    }
}

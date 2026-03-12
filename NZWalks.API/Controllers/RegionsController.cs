using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            var output = _mapper.Map<List<RegionDTO>>(regions);

            return Ok(output);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid Id)
        {
            var region = await _regionRepository.GetByIdAsync(Id);
            if (region == null)
            {
                return NotFound();
            }
            var regionsDTO = _mapper.Map<RegionDTO>(region);
            return Ok(regionsDTO);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO regionDTO)
        {

            var region = _mapper.Map<Region>(regionDTO);
            region = await _regionRepository.CreateAsync(region);

            var outputDTO =_mapper.Map<RegionDTO>(region);
            return CreatedAtAction(nameof(GetRegionById), new { id = outputDTO.Id }, outputDTO);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid Id, [FromBody] UpdateRegionRequestDTO updateRegionRequest)
        {
            var sendRegion = _mapper.Map<Region>(updateRegionRequest);
            var region = await _regionRepository.UpdateAsync(Id,sendRegion);
                if (region == null)
                {
                    return NotFound();
                }


            var response = _mapper.Map<RegionDTO>(region);

            return Ok(response);
        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var region = await _regionRepository.DeleteAsync(Id);
            if (region == null)
            {
                return NotFound();
            }

            var regionout = _mapper.Map<RegionDTO>(region);
            return Ok(regionout);

        }
    }
}

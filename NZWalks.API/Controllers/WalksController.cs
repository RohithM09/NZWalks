using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository) {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO walkDTO)
        {
            var walk = _mapper.Map<Walk>(walkDTO);
            var output = await _walkRepository.CreateAsync(walk);
            var res = _mapper.Map<WalkDTO>(output);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var output = await _walkRepository.GetAllAsync();
            var res = _mapper.Map<List<WalkDTO>>(output);

            return Ok(res);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute]Guid Id)
        {
            var result = await _walkRepository.GetWalkAsync(Id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var output = _mapper.Map<WalkDTO>(result);
                return Ok(output);
            }
        }
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid Id, UpdateWalkRequestDTO updateWalkRequest)
        {
            var result = _mapper.Map<Walk>(updateWalkRequest);
            var output = await _walkRepository.UpdateAsync(Id, result);
            if (output == null)
            {
                return NotFound();
            }
            var fin = _mapper.Map<WalkDTO>(output);
            return Ok(fin);
        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var result = await _walkRepository.DeleteAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            var output = _mapper.Map<WalkDTO>(result);
            return Ok(output);
        }

    }
}

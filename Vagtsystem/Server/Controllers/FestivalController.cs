using System;
using Microsoft.AspNetCore.Mvc;
using Vagtsystem.Server.Repositories;
using Vagtsystem.Shared.Models;

namespace Vagtsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FestivalController : Controller
    {
        private readonly IFestivalRepo _festivalService;

        public FestivalController(IFestivalRepo festivalService)
        {
            _festivalService = festivalService;
        }


        [HttpGet("Frivillig/List")]
        public async Task<IActionResult> Get()
        {
            var result = await _festivalService.GetFrivilligList();

            return result == null ? NotFound() : Ok(result);


        }

        [HttpGet("Frivillig/{id:int}")]
        public async Task<IActionResult> GetFrivillig(int id)
        {
            var result = await _festivalService.GetFrivillig(id);

            return Ok(result);
        }

        [HttpGet("Frivillig/Vagt/{id:int}")]
        public async Task<IActionResult> GetFrivilligVagtList(int id)
        {
            var result = await _festivalService.GetFrivilligVagtList(id);

            return Ok(result);
        }

        // + 
        [HttpGet("Frivillig/View")]
        public async Task<IActionResult> GetFrivilligView() 
        {
            var result = await _festivalService.GetFrivilligView();
            return Ok(result);
        }

        [HttpGet("Frivillig/View/{id:int}")]
        public async Task<IActionResult> GetFrivilligViewId(int id)
        {
            var result = await _festivalService.GetFrivilligViewId(id);

            return Ok(result);
        }

        [HttpPost("Frivillig")]
        public async Task<IActionResult> AddFrivillig([FromBody] Frivillig frivillig)
        {
            var result = await _festivalService.CreateFrivillig(frivillig);

            return Ok(result);
        }

        [HttpPut("Frivillig")]
        public async Task<IActionResult> UpdateFrivillig([FromBody] Frivillig frivillig)
        {
            var result = await _festivalService.UpdateFrivillig(frivillig);

            return Ok(result);
        }

        [HttpDelete("Frivillig/{id:int}")]
        public async Task<IActionResult> DeleteFrivillig(int id)
        {
            var result = await _festivalService.DeleteFrivillig(id);

            return Ok(result);
        }

        [HttpGet("Vagt/List")]
        public async Task<IActionResult> GetVagtList()
        {

            var result = await _festivalService.GetVagtList();

            return result == null ? NotFound() : Ok(result);


        }

        [HttpGet("Vagt/{id:int}")]
        public async Task<IActionResult> GetVagt(int id)
        {
            var result = await _festivalService.GetVagt(id);

            return Ok(result);
        }

        [HttpGet("Vagt/Koord/{id:int}/{sort:int}")]
        public async Task<IActionResult> GetKoordVagt(int id, int sort)
        {
            var result = await _festivalService.GetKoordVagt(id, sort);

            return Ok(result);
        }

        [HttpGet("Vagt/Vagter/{id:int}")]
        public async Task<IActionResult> GetBrugerVagt(int id)
        {
            var result = await _festivalService.GetBrugerVagt(id);

            return Ok(result);
        }


        [HttpGet("Vagt/List/{id:int}")]
        public async Task<IActionResult> GetHoldVagt(int id)
        {
            var result = await _festivalService.GetHoldVagt(id);

            return Ok(result);
        }

        [HttpGet("Vagt/Bruger/{id:int}")]
        public async Task<IActionResult> GetBrugerVagter(int id)
        {
            var result = await _festivalService.GetBrugerVagter(id);

            return Ok(result);
        }

        [HttpGet("Vagt/Bruger/Vagter/{id:int}")]
        public async Task<IActionResult> GetAlleBrugerVagter(int id)
        {
            var result = await _festivalService.GetAlleBrugerVagter(id);

            return Ok(result);
        }

        [HttpGet("Hold")]
        public async Task<IActionResult> GetHold()
        {
            var result = await _festivalService.GetHold();

            return Ok(result);
        }

        [HttpGet("Stilling")]
        public async Task<IActionResult> GetStilling()
        {
            var result = await _festivalService.GetStilling();

            return Ok(result);
        }

        [HttpPost("Vagt")]
        public async Task<IActionResult> AddVagt([FromBody] Vagt vagt)
        {
            var result = await _festivalService.CreateVagt(vagt);

            return Ok(result);
        }

        [HttpPost("Vagt/Holdvagt")]
        public async Task<IActionResult> AddHoldVagt([FromBody] Vagt vagt)
        {
            var result = await _festivalService.CreateHoldVagt(vagt);

            return Ok(result);
        }

        [HttpPut("Vagt")]
        public async Task<IActionResult> UpdateVagt([FromBody] Vagt vagt)
        {
            var result = await _festivalService.UpdateVagt(vagt);

            return Ok(result);
        }

        [HttpPut("Vagt/Holdvagt")]
        public async Task<IActionResult> UpdateHoldVagt([FromBody] Vagt vagt)
        {
            var result = await _festivalService.UpdateVagt(vagt);

            return Ok(result);
        }

        [HttpDelete("Vagt/{id:int}")]
        public async Task<IActionResult> DeleteVagt(int id)
        {
            var result = await _festivalService.DeleteVagt(id);

            return Ok(result);
        }

        [HttpDelete("Vagt/Hold/{id:int}")]
        public async Task<IActionResult> DeleteHoldVagt(int id)
        {
            var result = await _festivalService.DeleteHoldVagt(id);

            return Ok(result);
        }
    }
}


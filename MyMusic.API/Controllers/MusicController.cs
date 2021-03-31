using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Music>>> GetAllMusic()
        {
            try
            {
                var musics = await _musicService.GetAllMusicsWithArtistAsync();
                return Ok(musics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

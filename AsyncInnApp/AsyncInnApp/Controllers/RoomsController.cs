using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInnApp.Data;
using AsyncInnApp.Models;
using AsyncInnApp.Interfaces;

namespace AsyncInnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _room.GetRooms();
            return Ok(rooms);

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _room.GetRoom(id);
            return Ok(room);

        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
          if(id != room.id)
          {
                return BadRequest();
          }

            var modifiedRoom = await _room.UpdateRoom(id, room);

            return Ok(modifiedRoom);

        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            Room newRoom = await _room.Create(room);
            return Ok(newRoom);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.Delete(id);

            return NoContent();
        }

        // Add Amenity to room " api/room/3/1
        //[HttpPost("{roomId}/{AmenityId}")]
        //public async Task<ActionResult> AddAmenityToRoom(int roomId, int amenityId)
        //{
        //    await _room.AddAmenityToRoom(roomId, amenityId);
        //    return NoContent();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository _repo;
        public RecordsController(IRecordRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Record>>> GetRecords()
        {
            var Records = await _repo.GetRecordsAsync();
            return Ok(Records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            return await _repo.GetRecordByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(Record Record)
        {
            await _repo.PostRecord(Record);
            return CreatedAtAction("GetRecord", new { id = Record.Id }, Record);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Record>> Delete(int id)
        {
            var Record = await _repo.DeleteRecord(id);
            if (Record == null)
            {
                return NotFound();
            }
            return Record;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Record Record)
        {
            if (id != Record.Id)
            {
                return BadRequest();
            }
            await _repo.PutRecord(Record);
            return NoContent();
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            return Ok(await _repo.GetCategoriesAsync());
        }
    }
}

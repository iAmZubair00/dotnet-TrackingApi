using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        //private readonly IssueDbContext _context;
        private readonly PlutoContext _context = new PlutoContext();

        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new PlutoContext());

        public IssueController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
            => await _unitOfWork.Issues.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _unitOfWork.Issues.GetAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _unitOfWork.Issues.AddAsync(issue);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Update(int id, Issue issue)
        //{
        //    if (id != issue.Id) return BadRequest();

        //    _context.Entry(issue).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var issueToDelete = await _context.Issues.FindAsync(id);
        //    if (issueToDelete == null) return NotFound();

        //    _context.Issues.Remove(issueToDelete);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}

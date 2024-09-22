using Microsoft.AspNetCore.Mvc;
using Assignment01Solution_QE170124.DataAccess;
using Assignment01Solution_QE170124.Entities;
using Microsoft.EntityFrameworkCore;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMember), new { id = member.MemberID }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Member updatedMember)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            member.Email = updatedMember.Email;
            member.FullName = updatedMember.FullName;
            member.Password = updatedMember.Password;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

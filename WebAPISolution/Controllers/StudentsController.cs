using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISolution.Models;
using WebAPISolution.Contexts;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public StudentsController(ApplicationDBContext context)
    {
        _context = context;
    }

    // GET: api/Student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
    {
        return await _context.Student.ToListAsync();
    }

    // GET: api/Student/5
    [HttpGet("{studentid}")]
    public async Task<ActionResult<Student>> GetStudent(int studentid)
    {
        var student = await _context.Student.FindAsync(studentid);

        if (student == null)
        {
            return NotFound();
        }

        return student;
    }

    // PUT: api/Student/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{studentid}")]
    public async Task<IActionResult> PutStudent(int? studentid, Student student)
    {
        if (studentid != student.StudentId)
        {
            return BadRequest();
        }

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(studentid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Student
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        _context.Student.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStudent", new { studentid = student.StudentId }, student);
    }

    // DELETE: api/Student/5
    [HttpDelete("{studentid}")]
    public async Task<IActionResult> DeleteStudent(int? studentid)
    {
        var student = await _context.Student.FindAsync(studentid);
        if (student == null)
        {
            return NotFound();
        }

        _context.Student.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(int? studentid)
    {
        return _context.Student.Any(e => e.StudentId == studentid);
    }
}

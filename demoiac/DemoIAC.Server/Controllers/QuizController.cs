using Cities.Tools;
using DemoIAC.Server.Data;
using DemoIAC.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemoIAC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly Call _callService;
        private readonly ApplicationDbContext _context;

        public QuizController(Call callService, ApplicationDbContext context)
        {
            _callService = callService;
            _context = context;
        }

        [HttpGet("start")]
        public IActionResult StartQuiz()
        {
            try
            {
                // Récupérer 10 questions aléatoires
                var apiResponse = _callService.GetDataFromAPI<ApiResponse>();
                return Ok(apiResponse.Questions.Take(10));
            }
            catch (CallException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("submitScore")]
        public IActionResult SubmitScore([FromBody] Score score)
        {
            try
            {
                _context.Scores.Add(score);
                _context.SaveChanges();
                return Ok(new { message = "Score enregistré avec succès !" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("scores")]
        public IActionResult GetScores()
        {
            try
            {
                var scores = _context.Scores.OrderByDescending(s => s.Points).ToList();
                return Ok(scores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

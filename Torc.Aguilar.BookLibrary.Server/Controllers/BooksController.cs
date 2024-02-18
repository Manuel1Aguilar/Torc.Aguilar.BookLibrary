using Microsoft.AspNetCore.Mvc;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.Models.DTOs;
using Torc.Aguilar.BookLibrary.Models.Filters;

namespace Torc.Aguilar.BookLibrary.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        public readonly IBookService _bookService;
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetFiltered(BookFilter filter)
        {
            _logger.LogInformation("Getting filtered books");
            var res = await _bookService.GetFiltered(filter);
            if (res.IsSuccess)
            {
                return Ok(res.Value);
            }
            else
            {
                _logger.LogError("Error getting filtered books {}", res.ErrorMessage);
                return BadRequest(res.ErrorMessage);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;

namespace Torc.Aguilar.BookLibrary.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        public readonly IBookService _bookService;
        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all books");
            var res = await _bookService.GetAll();
            if (res.IsSuccess)
            {
                return Ok(res.Value);
            }
            else
            {
                _logger.LogError("Error getting all books {}", res.ErrorMessage);
                return BadRequest(res.ErrorMessage);
            }
        }
    }
}

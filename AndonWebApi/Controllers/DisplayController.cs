using AndonWebApi.Entities;
using AndonWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AndonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisplayController : ControllerBase
    {
        private readonly IDisplayRepository _repository;
        public DisplayController(IDisplayRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all displays from the database
        /// </summary>
        /// <returns>A collection of all displays</returns>
        /// endpoint: /Display/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Display> GetAll()
        {
            return _repository.GetAll().ToList().Where(d => d.Date.Date == DateTime.Now.Date).OrderBy(o => o.OrderId);
        }
    }
}

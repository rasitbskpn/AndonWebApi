using AndonWebApi.Entities;
using AndonWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using WMPLib;
using Xabe.FFmpeg;

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

        [HttpPost]
        [Route("Add")]
        public void Add(string type, float duration, int orderId, DateTime date, string content)
        {
            var display = new Display();
            display.Type= type;
            display.OrderId= orderId;
            display.Date= date;
            display.Content= content;
            display.Duration = duration;
            if(type == "video")
            {
                display.Duration = GetVideoDuration(content);
            }
            _repository.Add(display);
        }

        private float GetVideoDuration(string content)
        {
            var player = new WindowsMediaPlayer();
            var clip = player.newMedia(content);
            return (float)clip.duration;
        }
    }
}

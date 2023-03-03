using Microsoft.AspNetCore.Mvc;
using RentRoomOfEquipment.Data.Contracts;

namespace RentRoomOfEquipment.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentContractController : Controller
    {
        IRentRoomService _rentRoomService;
        private readonly ILogger<RentContractController> _logger;
        private const string API_KEY_HEADER = "XXX";
        private readonly IConfiguration _configuration;
        public RentContractController(IRentRoomService rentRoomService, ILogger<RentContractController> logger, IConfiguration configuration)
        {
            _rentRoomService = rentRoomService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet, Route("contracts")]
        public IActionResult GetAll([FromHeader(Name = "WriteKey")] string apiKey)
        {
            if (apiKey != API_KEY_HEADER)
                return Unauthorized();


            _logger.LogDebug("Getting all contracts for DB");

            return Ok(_rentRoomService.GetAllContracts());
        }

        [HttpPost, Route("create")]
        public IActionResult Create([FromHeader(Name = "WriteKey")] string apiKey, int areaId, int equipmentId, int countOfEquipment)
        {
            if (!ApiKeyIsValid(apiKey))
                return Unauthorized();

            try
            {
                return _rentRoomService.TryCreateConract(areaId, equipmentId, countOfEquipment) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        private bool ApiKeyIsValid(string apiKey)
        {
            var validApiKey = _configuration.GetValue<string>("ApiKey");
            return !string.IsNullOrEmpty(apiKey) && apiKey.Equals(validApiKey);
        }
    }
}

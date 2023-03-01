using Microsoft.AspNetCore.Mvc;
using RentRoomOfEquipment.Data.Contracts;
using RentRoomOfEquipment.Models.Contract;

namespace RentRoomOfEquipment.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentContractController : Controller
    {
        IRentRoomService _rentRoomService;
        private readonly ILogger<RentContractController> _logger;
        public RentContractController(IRentRoomService rentRoomService, ILogger<RentContractController> logger)
        {
            _rentRoomService = rentRoomService;
            _logger = logger;
        }

        [HttpGet, Route("contracts")]
        public List<Contract> GetAll()
        {
            _logger.LogDebug("Getting all contracts for DB");
            return _rentRoomService.GetAllContracts();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(int areaId, int equipmentId, int countOfEquipment)
        {
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
    }
}

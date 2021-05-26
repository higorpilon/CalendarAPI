using CalendarAPI.Data.Entities;
using CalendarAPI.Data.Repositories;
using CalendarAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IParticipantManager _manager;

        public ParticipantsController(IParticipantRepository participantRepository, IParticipantManager manager)
        {
            _participantRepository = participantRepository;
            _manager = manager;
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Participants/Insert")]
        public async Task<IActionResult> Insert(Participant participant)
        {

            if (_manager.IsSingleParticipantValid(participant))
            {
                await _participantRepository.CreateAsync(participant);
                _manager.CreateAvailability(participant);
                return Ok();
            }
            return BadRequest();
        }

    }
}

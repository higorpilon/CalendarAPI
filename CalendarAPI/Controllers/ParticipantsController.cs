using CalendarAPI.Data.Entities;
using CalendarAPI.Data.Repositories;
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

        public ParticipantsController(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;

        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Participants/Insert")]
        public async Task<IActionResult> Insert(Participant participant)
        {

            if (_participantRepository.IsSingleParticipantValid(participant))
            {
                await _participantRepository.CreateAsync(participant);
                _participantRepository.CreateAvailability(participant);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Participants/GetCalendar/{participantOne}/{participantTwo}")]
        public async Task<IEnumerable<string>> GetCalendar([FromQuery] int participantOne, [FromQuery] int participantTwo)
        {
            if (await _participantRepository.AreParticipantsValid(participantOne, participantTwo))
            {
                return await _participantRepository.PossibleSchedules(participantOne, participantTwo);
            }

            return null;
        }
    }
}

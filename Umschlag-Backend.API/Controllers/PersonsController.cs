using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umschlag_Backend.API.DTOs;
using Umschlag_Backend.Core.Models;
using Umschlag_Backend.Core.Services;

namespace Umschlag_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _personService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
            => Created(string.Empty, _mapper.Map<PersonDto>(await _personService.AddAsync(_mapper.Map<Person>(personDto)))); 

    }
}

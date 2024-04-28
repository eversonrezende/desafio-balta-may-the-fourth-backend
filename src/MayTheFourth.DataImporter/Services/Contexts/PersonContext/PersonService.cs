using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.DataImporter.DTOs;
using MayTheFourth.DataImporter.Extensions;
using MayTheFourth.DataImporter.Services.Contexts.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MayTheFourth.DataImporter.Services.Contexts.PersonContext
{
    public class PersonService : IEntityService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPlanetRepository _planetRepository;
        private List<PersonDTO> _people = new();
        public PersonService(IPersonRepository personRepository, IPlanetRepository planetRepository)
        {
            _personRepository = personRepository;
            _planetRepository = planetRepository;
        }

        public void LoadList(string jsonList)
            => _people = JsonSerializer.Deserialize<List<PersonDTO>>(jsonList)!;

        public async Task ImportAsync(CancellationToken cancellationToken)
        {
            // Cadastrar 
            foreach (var personDTO in _people)
            {
                // Encontrar homeworld (planet) pela url
                var planet = await _planetRepository.GetByUrlAsync(personDTO.Homeworld, cancellationToken);
                var person = personDTO.ToPerson();
                person.HomeworldId = planet!.Id;
                await _personRepository.SaveAsync(person, cancellationToken);
            }
        }

        public async Task<bool> IsEmpty() => !await _personRepository.AnyAsync();        
    }
}

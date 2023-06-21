using CircuitCruisers.Helpers.Repositories;
using CircuitCruisers.Models.Entities;

namespace CircuitCruisers.Helpers.Services
{
    public class TagService
    {
        private readonly TagEntityRepository _tagEntity;

        public TagService(TagEntityRepository tagEntity)
        {
            _tagEntity = tagEntity;
        }

        public async Task<IEnumerable<TagEntity>> GetAllTags() 
        {

            var allTags = await _tagEntity.GetAllAsync();

            return allTags;

        }
    }
}

using CircuitCruisers.Models.Entities;
using CircuitCruisers.Models.Identity;
using CircuitCruisers.Helpers.Repositories;

namespace CircuitCruisers.Helpers.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepository)
        {
            _addressRepository = addressRepo;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity) 
        {
            var entity = await _addressRepository.GetAsync(x => 
                x.StreetName == addressEntity.StreetName &&
                x.City == addressEntity.City &&
                x.PostalCode == addressEntity.PostalCode
                
                );

            
                entity ??= await _addressRepository.AddAsync(addressEntity);

            return entity!;
            
        }

        public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}

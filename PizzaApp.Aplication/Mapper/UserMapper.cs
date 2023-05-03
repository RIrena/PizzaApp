using PizzaApp.Application.ViewModel.User;
using DomainModel = PizzaApp.Domain.Models;
namespace PizzaApp.Application.Mapper
{
    public static class UserMapper
    {
        public static Model ToModel(this DomainModel.User user)
        {
            return new Model
            {
                LocationFromStore = user.LocationFromStore,
                Email = user.Email,
                FirstName = user.Name,
                LastName = user.LastName,
                Phone = user.Phone,
                Id = user.Id,
            };
        }

        public static DomainModel.User ToUser(this Create create)
        {
            return new DomainModel.User(create.FirstName, create.LastName, create.DestinationFromLocation, create.Phone, create.Email);
        }

        public static DomainModel.User Edit(this DomainModel.User user, Edit edit)
        {
            user.Email = edit.Email;
            user.Phone = edit.Phone;
            user.Name = edit.FirstName;
            user.LastName = edit.LastName;
            user.LocationFromStore = edit.LocationFromStore;

            return user;
        }
        public static ViewModel.User.Index ToIndexModel(this DomainModel.User user)
        {
            return new ViewModel.User.Index()
            {
                Id = user.Id,
                FullName = $"{user.Name} {user.LastName}",
            };
        }
    }
}

using PizzaApp.Application.Mapper;
using PizzaApp.Application.Repository;
using PizzaApp.Application.ViewModel.User;
using DomainEntity = PizzaApp.Domain.Models;
namespace PizzaApp.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<DomainEntity.User> userRepository;

        public UserService(IRepository<DomainEntity.User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public Model CreateUser(Create create)
        {
            var user = create.ToUser();
            var createdUser = userRepository.Create(user);

            userRepository.Commit();

            return createdUser.ToModel();
        }

        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
            userRepository.Commit();

        }

        public Model EditUser(int id, Edit edit)
        {
            var user = userRepository.GetById(id);
            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            var editedUser = user.Edit(edit);
            userRepository.Update(editedUser);
            userRepository.Commit();

            return editedUser.ToModel();
        }

        public Model GetUser(int id)
        {
            var user = userRepository.GetById(id);
            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            return user.ToModel();
        }

        public IList<ViewModel.User.Index> GetUsers()
        {
            return userRepository
                .GetAll()
                .Select(x => x.ToIndexModel())
                .ToList();
        }
    }
}

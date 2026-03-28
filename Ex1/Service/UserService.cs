namespace Ex1;

public class UserService
{
    private List<User> users = new();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return users;
    }

    public User? GetUserById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }
}
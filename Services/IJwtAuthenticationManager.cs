namespace EmployeeAPI.Services
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);     //returns a jwt token string
    }
}

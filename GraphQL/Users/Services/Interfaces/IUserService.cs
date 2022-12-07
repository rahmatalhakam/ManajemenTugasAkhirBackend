namespace ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Interfaces;

public interface IUserService
{
    Guid GetUserId();
    string GetUsername();
}
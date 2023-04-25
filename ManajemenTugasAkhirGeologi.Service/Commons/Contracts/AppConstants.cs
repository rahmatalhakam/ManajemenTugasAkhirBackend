namespace ManajemenTugasAkhirGeologi.Service.Commons.Contracts;

public static class AppConstants
{
    public const string Mutation = "Mutation";
    public const string Query = "Query";
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Student = "Student";
        public const string Lecturer = "Lecturer";
    }
    public const string UserIdClaim = "userid";
}
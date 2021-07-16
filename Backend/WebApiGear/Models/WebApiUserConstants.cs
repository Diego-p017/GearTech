namespace WebApiUser.Model
{
    public class WebApiUserConstants
    {
        public static readonly string IdRoleAdmin = "6121173f-a485-4276-8623-85a58ddc89b6";
        public static readonly string IdRoleUser = "4b56d9a7-c111-4590-8fca-a33caf2ad60a";

        public static readonly string RoleAdmin = "ADMIN";
        public static readonly string RoleUser = "USER";

        public static readonly string[] Roles = { "ADMIN", "USER" };

        public const string MAIL_FROM = "saprojecthanged@gmail.com";
        public const string PASSWORD_MAIL = "HangedDraw1";
        public const string MAIL_SMTP = "smtp.gmail.com";
        public const int MAIL_SMTP_PORT = 587;

#if DEBUG
        public const string WEB_VERIFY = "https://localhost:3001/verify";
        public const string WEB_CHANGE_PASSWORD = "https://localhost:3001/change_password";
#elif RELEASE
        public const string WEB_VERIFY = "https://awsuri:3001/verify";
        public const string WEB_CHANGE_PASSWORD = "https://awsuri:3001/change_password";
#endif
    }
}

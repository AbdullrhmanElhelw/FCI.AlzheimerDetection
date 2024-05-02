namespace FCI.AlzheimerDetection.Presentation.Routes;

public static class ApiRoutes
{
    
    public static class Admins
    {
        public const string Base = "api/admins";
        public const string Login = "login";
        public const string Create = "create";
        public const string Delete = "delete";
        public const string GetAdmin = "get-admin/{ssn:length(14)}";
        public const string GetAllAdmins = "get-all-admins";
        public const string GetAllByName = "get-all-by-name/{name:alpha}";
        public const string GetAllAdminsPaged = "get-all-admins-paged/{pageNumber:int}/{pageSize:int}";
        public const string ChangePassword = "change-password";
    }

    public static class Patients
    {
        public const string Base = "api/patients";
        public const string Create = "create";
        public const string GetAll = "get-all";
        public const string Get = "get/{id:int}";
        public const string Update = "update/{id:int}";
        public const string Delete = "delete/{id:int}";
        public const string GetAllPaged = "get-all/{pageNumber:int}/{pageSize:int}";
        public const string Find = "find/{key}";
        public const string FindPaged = "find/{key}/{pageNumber:int}/{pageSize:int}";
    }

    public static class Medicines
    {
        public const string Base = "api/medicines";
        public const string Create = "create";
        public const string Get = "get/{id:int}";
        public const string GetAll = "get-all";
        public const string Delete = "delete/{id:int}";
        public const string Update = "update{id:int}";

    }

    public static class AddRelatives
    {
        public const string Base = "api/addrelatives";
    }

    public static class Relatives
    {
        public const string Base = "api/relatives";
        public const string Login = "login";
    }
    
    public static class AdminMrIs
    {
        public const string Base = "api/admins-mri";
        public const string UploadMri = "upload-mri";
    }
    
    public static class NormalUserMri
    {
        public const string Base = "api/normal-users-mri";
        public const string UploadMri = "upload-mri";
        public const string UploadMultipleMri = "upload-multiple-mri";
    }
    
    public static class NormalUsers
    {
        public const string Base = "api/normal-users";
        public const string Register = "register";
        public const string Login = "login";
        public const string ConfirmEmail = "confirm-email";
        public const string ForgotPassword = "forgot-password/{email}";
        public const string ResetPassword = "reset-password/{email}/{token}";
        public const string ChangePassword = "change-password/{email}";
    }
}
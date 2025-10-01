namespace Catalog.Application;

public static class ApplicationErrors
{
    public const string ValidationError = "validation_error";
    public const string UnknownError = "unknown_error";
    
    public const string AlreadyExist = "already_exist";
    public const string NotFound = "not_found";
    
    public const string CreateFailed = "create_failed";
    public const string UpdateFailed = "update_failed";
    public const string DeleteFailed = "delete_failed";
}
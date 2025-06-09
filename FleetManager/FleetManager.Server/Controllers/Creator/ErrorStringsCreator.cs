namespace FleetManager.Server.Controllers.Creator;

public class ErrorStringsCreator<T>
{
    const string errorWhileCreating = "Error while creating object: ";

    const string errorWhileUpdating = "Error while updating object: ";

    const string errorWhileDeleting = "Error while deleting object: ";

    public string ConstructErrorMessage(string errorType, T obj, Exception ex)
    {
        string errorMessage = string.Empty;
        switch (errorType)
        {
            case "put":
                {
                    errorMessage = errorWhileCreating;
                    break;
                }
            case "post":
                {
                    errorMessage = errorWhileUpdating;
                    break;
                }
            case "delete":
                {
                    errorMessage = errorWhileDeleting;
                    break;
                }
            default:
                break;


        }

        errorMessage += obj!.GetType() +
                        "\nException message: " + ex.Message +
                        "\nInner expection: " + ex.InnerException;

        return errorMessage;
    }
}
namespace ManajemenTugasAkhirGeologi.ErrorFilters;
public class GraphQLErrorFilter : IErrorFilter
{

    public IError OnError(IError error)
    {

        if (error.Exception is BusinessLogicException)
        {
            return error.WithCode("BusinessLogic").WithMessage(error.Exception!.Message);
        }
        return error;
    }
}
public class BusinessLogicException : Exception
{
    public BusinessLogicException() { }

    public BusinessLogicException(string message) : base(String.Format(message)) { }
}
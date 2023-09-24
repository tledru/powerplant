namespace PowerPlant.Domain
{
    public class LoadTooLowException : BusinessException
    {
        public LoadTooLowException() 
            : base("The load is too low for the power plant") 
        { }
    }
}

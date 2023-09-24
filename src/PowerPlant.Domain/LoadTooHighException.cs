namespace PowerPlant.Domain
{
    public class LoadTooHighException : BusinessException
    {
        public LoadTooHighException():base("This set of power plants cannot handle the requested load")
        {
        }
    }
}

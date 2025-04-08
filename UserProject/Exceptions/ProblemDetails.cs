namespace UserProject.Exceptions
{
    public class ProblemDetails
    {
        public Guid? Id {  get; set; }
        public required int StatusCode { get; set; }
        public required string ErrorMessage { get; set; }
    }
}

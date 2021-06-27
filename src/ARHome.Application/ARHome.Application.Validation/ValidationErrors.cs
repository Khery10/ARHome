namespace ARHome.Application.Validation
{
    public static class ValidationErrors
    {
        public static string IsEmptyValueMessage(string fieldName) 
            => $"Value \"{fieldName}\" must not be empty.";
    }
}
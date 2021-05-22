namespace ARHome.GenericSubDomain.MediatR
{
    public interface IValidate
    {
        dynamic InnerRequest { get; }
    }
}
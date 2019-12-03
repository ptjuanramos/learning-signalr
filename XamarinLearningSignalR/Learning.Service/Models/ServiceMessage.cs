namespace Learning.Core.Models
{
    public class ServiceMessage<T>
    {
        public string FromUser { get; set; }
        public string ToUser{ get; set; }
        public T Content { get; set; }
    }
}
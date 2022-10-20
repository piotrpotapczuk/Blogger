namespace WebAPI.Wrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeed { get; set; }

        public Response()
        {

        }
        public Response(T data)
        {
            Data = data;
            Succeed = true;
        }

    }
}

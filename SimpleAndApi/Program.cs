using System.Net;

namespace SimpleAndApi
{

    class Program
    {
        public static void Main(string[] args)
        {
            int port = args.Length > 0 ? int.Parse(args[0]) : 5000;

            var listener = new HttpListener();
            listener.Prefixes.Add($"http://*:{port}/");
            listener.Start();
            Console.WriteLine($"Server started on http://*:{port}");

            while (true)
            {
                var context = listener.GetContext();
                var response = context.Response;
                var responseString = $"Hello, Android on {port}!";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }
    }


}

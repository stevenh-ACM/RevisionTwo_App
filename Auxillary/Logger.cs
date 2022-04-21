
using RestSharp;

namespace RevisionTwo_App.Auxillary;

public static class RequestLogger
{
    private const string _requestsLogPath = "RequestsLog.txt";
    public static void LogResponse(RestRequest request, RestResponse response, RestClient restClient)
    {
        StreamWriter writer = new StreamWriter(_requestsLogPath, true);
        writer.WriteLine(DateTime.Now.ToString());
        writer.WriteLine("Response");
        writer.WriteLine("\tStatus code: " + response.StatusCode);
        writer.WriteLine("\tContent: " + response.Content);
        writer.WriteLine("-----------------------------------------");
        writer.WriteLine();
        writer.Flush();
        writer.Close();

    }
    public static void LogRequest(RestRequest request, RestClient restClient)
    {
        StreamWriter writer = new StreamWriter(_requestsLogPath, true);
        writer.WriteLine(DateTime.Now.ToString());
        writer.WriteLine("Request");
        writer.WriteLine("\tMethod: " + request.Method);
        string parameters = "";
        string body = "";
        foreach (Parameter? parametr in request.Parameters)
        {
            if (parametr.Type == ParameterType.QueryString)
            {
                parameters += string.IsNullOrEmpty(parameters) ? "?" : "&";
                parameters += parametr.Name + "=" + parametr.Value;
            }

            if (parametr.Type == ParameterType.RequestBody)
            {
                body += parametr.Value;
            }
        }

        writer.WriteLine("\tURL: " + restClient.BuildUri(request) + parameters);
        if (!string.IsNullOrEmpty(body))
        {
            writer.WriteLine("\tBody: " + body);
        }

        writer.WriteLine("-----------------------------------------");
        writer.WriteLine();
        writer.Flush();

        writer.Close();
    }
}

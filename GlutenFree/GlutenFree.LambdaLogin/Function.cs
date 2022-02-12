using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GlutenFree.Login;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace GlutenFree.LambdaLogin
{
    public class Function
    {
        readonly string email = "em";
        readonly string password = "pwd";

        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            try
            {
                request.QueryStringParameters.TryGetValue("task", out string task);

                return task switch
                {
                    "login" => Login(request, context),
                    "register" => Register(request, context),
                    _ => Response(Codes.RequestNotFound),
                };

                /* if (task.Equals("login"))
                    return Login(request, context);

                if (task.Equals("register"))
                    return Register(request, context); */
            }
            catch (Exception)
            {
                return Response(Codes.GenericError);
            }
        }

        private APIGatewayProxyResponse Login(APIGatewayProxyRequest request, ILambdaContext context)
        {
            Console.WriteLine("Entered Login inside the Function.cs class!");

            IDictionary<string, string> requestParameters = request.QueryStringParameters;
            requestParameters.TryGetValue(this.email, out string email);
            Console.WriteLine("Got email: " +email);
            requestParameters.TryGetValue(this.password, out string password);
            Console.WriteLine("Got passwd:" +password);

            try
            {
                Codes statusCode = LoginService.LoginAsync(email, password).Result;
                return ResponseBodyOnly(statusCode);
            }
            catch
            {
                return Response(Codes.DatabaseConnectionError);
            }
        }

        private APIGatewayProxyResponse Register(APIGatewayProxyRequest request, ILambdaContext context)
        {
            Console.WriteLine("Entered Registration inside the Function.cs class!");

            IDictionary<string, string> dict = request.QueryStringParameters;
            dict.TryGetValue(this.email, out string email);
            dict.TryGetValue(this.password, out string password);
            
            Task<Codes> statusCode = LoginService.RegisterAsync(email, password);

            return Response(statusCode.Result);            
        }

        private APIGatewayProxyResponse Response<T>(List<T> list)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(list)
            };
        }

        private APIGatewayProxyResponse ResponseBodyOnly(Codes statusCode)
        {
            return (int)statusCode switch
            {
                200 => new APIGatewayProxyResponse
                {
                    StatusCode = 200
                },

                _ => Response(statusCode)
            };

            /* if ((int)statusCode == 200)
                return new APIGatewayProxyResponse
                {
                    StatusCode = 200
                };
            else
                return Response(statusCode); */
        }

        private APIGatewayProxyResponse Response(Codes statusCode)
        {
            //int integerStatusCode = (int)statusCode;

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)statusCode,
                Body = CodesService.ResponseCode((int)statusCode)
            };
        }

        private APIGatewayProxyResponse Response(int statusCode, string message)
        {

            return new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = message
            };
        }
    }
}

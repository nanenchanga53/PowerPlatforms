# Azure Functions 팁 - 닷넷 격리됨에서 OpenAPI 사용
> Azure Functions에는 닷넷을 사용시 '격리됨' 으로 프로세스를 만들 수 있다. 이후 .NET 7 등의 기능이나 Azure Functions에서 지원되지 않는 기능을 빠르게 도임하려면 격리됨 에서 개발하는 것도 하나의 방법일 것이다. 여기서는 '격리됨' 프로세스를 만들시 Swagger를 사용하도록 설정하는 것을 설명한다.

## '격리됨' 프로세스에서 Swagger 사용
1. '.NET 격리됨'으로 Azure Functions 애플리케이션을 만든다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167528825-10dde78c-70b5-497d-b514-297af6d20a8c.png)<br>

2. '솔루션 탐색기' 창에서 프로젝트 혹은 프로젝트의 종속성을 마우스 오른쪽 클릭해 <span style="color:red">Nuget 패키지 관리</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167530053-eea74e56-4b91-40d2-9ffd-92af72448f8e.png)<br>

3. Nuget 패키지 관리자에서 `Microsoft.Azure.Functions.Worker.Extensions.OpenApi`를 검색하여 설치<br><br>![image](https://user-images.githubusercontent.com/39551265/167530528-8c51547b-afc8-4c0a-b0e3-b40506e9a700.png)<br>

4. 그 후 `Program.cs` 파일을 열고 `.ConfigureFunctionsWorkerDefaults`를 제거하고 `.ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())`와 `.ConfigureOpenApi()` 추가
 
    ```
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                // 다음 줄 제거
                .ConfigureFunctionsWorkerDefaults()

                // 다음 두줄 추가
                .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
                .ConfigureOpenApi()

                .Build();

            host.Run();
        }
    }
    ```

5. 함수 파일을 열고 `[Function("{함수이름}")]` 바래아래 즉 `Run` 함수의 위에 Swagger의 함수 설명을 추가한다.


    ```
    public class Function1
    {
        ...

        [Function("Function1")]

        [OpenApiOperation(operationId: "Run", tags: new[] { "greetings" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]

        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            ...
        }
    }
    ```

6. 이후 실행해보면 Swager가 생성 되는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167531641-526e0abe-56de-4b97-9346-9d1e36da45e8.png)
<br>
# PowerApps-Samples DataverseSDK 예제설명 3 - TelemetryUsingILogger
> Dataverse SDK의 Core 3.1 이상을 지원하기 위한 SDK의 공식 사용예제에 대해 설명한다. 해당 소스는 [Github 사이트](https://github.com/microsoft/PowerApps-Samples/tree/master/cds/orgsvc/C%23-NETCore/ServiceClient)에서 직접 받아볼 수 있다. 여기서는 어플리케이션의 동작의 로그를 만드는 ILogger를 사용한 경우를 알 수 있는 TelemetryUsingILogger 프로젝트에 대해 알아본다.

## 프로젝트 세팅 확인
>여기서는 Visual Studio 2022가 설치되어 있다는 가정하에 설명한다. VSCode등을 사용하는 사용자와는 조금 차이가 있을 수 있다.

1. 우선 한가지 이상의 인증을 갖추어야 해당 SDK를 사용가능하다. Azure AD를 이용한 것은 [Azure AD App등록](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%EB%A7%88%EC%9D%B4%ED%81%AC%EB%A1%9C%EC%86%8C%ED%94%84%ED%8A%B8365%EA%B4%80%EB%A6%AC%EC%84%BC%ED%84%B0/OAuth%EB%93%B1%EB%A1%9D%EC%9D%84%EC%9C%84%ED%95%9C%EC%95%B1%EB%93%B1%EB%A1%9D.md)에서 확인하자

2. Visual Studio 사용자라면 `TelemetryUsingILogger.sln` 파일을 열어 Visual Studio를 실행한다.

3. 프로젝트 세팅 파일로 사용할 `appsettings.json` 파일을 확인하면 프로젝트를 빌드시 생성이 가능하도록 '출력 디렉토리로 복사'가 새 버전이면 복사로 되어 있는 것을 확인 가능하다. 만약 Visual Studio를 사용하지 않는다면 .csProj 파일을 열어 `<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>`가 되어있는것을 확인하면 된다. <br><br>![image](https://user-images.githubusercontent.com/39551265/174945190-241c5247-c800-44ec-97fd-5bd1de7ef7f3.png)<br>

4. 해당 프로젝트의 'Nuget 패키지 관리자'를 열어 Dataverse의 연결을 위한 `Microsoft.PowerPlatform.Dataverse.Client` 와 설정을 위한 `Microsoft.Extensions.Configuration`, `Microsoft.Extensions.Configuration.Json` 이 설치되어있는 것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174945886-7b4c34ed-e2c1-44b6-9357-3fa0b35bf925.png)<br>

5. `appsettings.json` 파일을 열어보자. 다음과 같이 되어있다.

```json
{
  "ConnectionStrings": {
    "default": "AuthType=OAuth;Url=https://myorg.crm.dynamics.com;Username=someone@myorg.onmicrosoft.com;RedirectUri=http://localhost;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;LoginPrompt=Auto"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Trace"
    }
  }
}
```

6. 위의 Json에서 `ConnectionStrings`의 `default`를 살펴보자 여기서 설정한 보안 정책에 맞는 Dataverse 연결문자열을 입력한다. Oauth와 ClinetSecret 중에 사용하자 [참조](https://docs.microsoft.com/ko-kr/power-apps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect)

7. `Logging` 의 설정은 Ilogger의 설정에 사용된다.

## 소스코드

1. using 문
    * Dataverse SDK에서 반환하는 메시지를 호출하는 `Microsoft.Crm.Sdk.Message`
    * 설정을 관리할 수 있는 `Microsoft.Extensions.Configuration`
    * Dataverse의 인증을 위한 `Microsoft.PowerPlatform.Dataverse.Client`
    * Log 설정을 관리하는 `Microsoft.Extensions.Logging`

```c#
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
```

2. 생성자 `Program()`
    * 생성자에서는 appsetting.json에서 설정을 Configuration에 등록하는 과정을 갖는다. 환경설정 `DATAVERSE_APPSETTINGS`을 설정하지 않았다면 `appsettings.json`파일을 사용하게 될 것이다.

    * 설정을 지정하기 위한 `IConfiguration Configuration { get; }` 을 생성자 위에 설정함으로써 해당 클래스에서 생성자에서 입력하도록 지정해 두었다.

```c#
Program()
{
    // 만약 환경변수에 설정 경로를 설정했다면 path에 가져온다 아니면
    // 아니면 경로를 직접 설정한 파일을 사용합니다.
    string? path = Environment.GetEnvironmentVariable("DATAVERSE_APPSETTINGS");
    if (path == null) path = "appsettings.json";

    // JSON파일을 통해 Configuration을 설정합니다.
    Configuration = new ConfigurationBuilder()
        .AddJsonFile(path, optional: false, reloadOnChange: true)
        .Build();
}
```

2. 메시지요청 `Main()`
    * ServiceClinet를 선언하고 선언시 설정값에 있는 연결문자열을 사용한다.
    * 메모리에 Entity 를 만든다. 해당 형식은 Dataverse 테이블의 행에 해당되는 정보가 담기게 된다. 생성시 `account`를 입력해 해당 테이블에서 사용될 것을 명시한다. 
    * `name`에 해당되는 열에 값을 입력하고 `Create`를 요청해서 `account`에 새로운 행을 추가한다. 이때 반환되는 ID값을 저장해둔다.
    * 기존 값을 변경, 추가후 `Update` 를 요청해 업데이트를 한다. 
    * 행을 검색하기 위해 `Retrive`를 요청한다. 이때 파라매터는 테이블명, 행의 GUID, 반환받을 열의 이름을 담은 `ColumnSet` 이 입력된다.
    * `Delete`를 요청해 데이터를 지운다.
    * 접속을 종료시에는 `Dispose`를 이용해 종료한다.

```c#
static void Main(string[] args)
{
    Program app = new();

    // appsettings.json 파일에서 'Logging' 설정을 가져온다.
    // 로그는 Console에서 작성 된다.
    ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            builder.AddConsole()
                    .AddConfiguration(app.Configuration.GetSection("Logging")));

    // default에 설정된 연결문자열을 가져와 serviceClient를 생성.
    ServiceClient serviceClient = new ServiceClient(
        dataverseConnectionString: app.Configuration.GetConnectionString("default"),
        logger: loggerFactory.CreateLogger<Program>());

    // 서비스에 WhoAmI 메시지 요청을 전송하여 반환
    // 로그인 한 사용자 정보를 출력.
    WhoAmIResponse resp = (WhoAmIResponse)serviceClient.Execute(new WhoAmIRequest());
    Console.WriteLine("\nUser ID is {0}.", resp.UserId);

    // 잠시 확인시간을 갖기 위해 멈춤.
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    serviceClient.Dispose();
}
```

3. 결과는 다음 이미지와 비슷할 것이다.<br><br>![image](https://user-images.githubusercontent.com/39551265/175448550-4c139d3a-a097-490e-9f33-e8e46800928f.png)<br>

## 결론

1. 인증에대한 정책이 바뀌면서 `.Net core 3.1` 이상의 버전에서 SDK를 사용하도록 제공하려는 것으로 보인다.

2. Client package를 받은 것 만으로 기존 Xrm, Crm SDK가 같이 설치된다. 기존의 .NET Framework때 사용되는 SDK를 통합하여 새로운 .NET 버전에서도 돌아가게 하도록 만드는 것으로 보인다. 하지만 .NET Framework 기반으로 만들어졌던 SDK라 리눅스 등의 OS에서 사용시에는 주의해야할 것이다. <br><br>![image](https://user-images.githubusercontent.com/39551265/175187959-d4b7497a-0ae6-4529-8125-9fc3ff3fa0b5.png)<br>

3. .NetFrameWork에서는 사용이 어려웠던 ILoggerFactory를 사용 가능하게 되었다. .NET의 로깅 작업은 해당 인터페이스를 이용한 것이 기본적인 로깅 작업으로 자리잡아 기존 .NetFrameWork에서 제대로 작동되지 않은 로깅 SDK를 문제없이 사용 가능할 것이다.

4. WhoAmI를 실행하면서도 여러 로그 작업을 남기는 것을 알 수 있다. 어떤 방식으로 인증을 했는지, 어느주소에 했는지, 
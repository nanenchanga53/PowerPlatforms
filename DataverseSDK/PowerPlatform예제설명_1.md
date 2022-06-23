# PowerApps-Samples DataverseSDK 예제설명 1 - WhoAmI
> Dataverse SDK의 Core 3.1 이상을 지원하기 위한 SDK의 공식 사용예제에 대해 설명한다. 해당 소스는 [Github 사이트](https://github.com/microsoft/PowerApps-Samples/tree/master/cds/orgsvc/C%23-NETCore/ServiceClient)에서 직접 받아볼 수 있다. 여기서는  접속되어 할당된 ID를 확인 할 수 있는 WhoAmI 프로젝트에 대해 알아본다.

## 프로젝트 세팅 확인
>여기서는 Visual Studio 2022가 설치되어 있다는 가정하에 설명한다. VSCode등을 사용하는 사용자와는 조금 차이가 있을 수 있다.

1. 우선 한가지 이상의 인증을 갖추어야 해당 SDK를 사용가능하다. Azure AD를 이용한 것은 [Azure AD App등록](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%EB%A7%88%EC%9D%B4%ED%81%AC%EB%A1%9C%EC%86%8C%ED%94%84%ED%8A%B8365%EA%B4%80%EB%A6%AC%EC%84%BC%ED%84%B0/OAuth%EB%93%B1%EB%A1%9D%EC%9D%84%EC%9C%84%ED%95%9C%EC%95%B1%EB%93%B1%EB%A1%9D.md)에서 확인하자

2. Visual Studio 사용자라면 `ServiceClient.sln` 파일을 열어 Visual Studio를 실행한다.

3. 프로젝트 세팅 파일로 사용할 `appsettings.json` 파일을 확인하면 프로젝트를 빌드시 생성이 가능하도록 '출력 디렉토리로 복사'가 새 버전이면 복사로 되어 있는 것을 확인 가능하다. 만약 Visual Studio를 사용하지 않는다면 .Proj 파일을 열어 `<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>`가 되어있는것을 확인하면 된다. <br><br>![image](https://user-images.githubusercontent.com/39551265/174945190-241c5247-c800-44ec-97fd-5bd1de7ef7f3.png)<br>

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
    * Dataverse의 인증을 위한 `Microsoft.PowerPlatform.Dataverse.Client`로 이루어져 있다.

```c#
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;
```

2. 생성자 `Program()`
    * 생성자에서는 appsetting.json에서 설정을 Configuration에 등록하는 과정을 갖는다. 환경설정 `DATAVERSE_APPSETTINGS`을 설정하지 않았다면 `appsettings.json`파일을 사용하게 될 것이다.

    * 설정을 지정하기 위한 `IConfiguration Configuration { get; }` 을 생성자 위에 설정함으로써 해당 클래스에서 생성자를 만들시 입력하도록 지정해 두었다.

```c#
Program()
{
    // 만약 환경설정에 설정 경로를 설정했다면 path에 가져온다 아니면
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
    * 유저의 접속 ID인 WhoAmiI를 반환한다. (접속을 새로할때마다 반환값이 다를 것이다.)
    * 접속을 종료시에는 `Dispose`를 이요해 종료한다.

```c#
static void Main(string[] args)
{
    Program app = new();

    // default에 설정된 연결문자열을 가져오 serviceClient를 생성.
    ServiceClient serviceClient = 
        new( app.Configuration.GetConnectionString("default") );

    // 조직 서비스에 WhoAmI 메시지 요청을 전송하고 반환  
    // 유저의 접속 ID를 가져온다.
    WhoAmIResponse resp = (WhoAmIResponse)serviceClient.Execute(new WhoAmIRequest());
    Console.WriteLine("User ID is {0}.", resp.UserId);

    // 입력이 있을때까지 멈추고 서비스를 닫는다.
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    serviceClient.Dispose();
}
```


## 결론

1. 인증에대한 정책이 바뀌면서 `.Net core 3.1` 이상의 버전에서 SDK를 사용하도록 제공하려는 것으로 보인다.

2. Client package를 받은 것 만으로 기존 Xrm, Crm SDK가 같이 설치된다. 기존의 .NET Framework때 사용되는 SDK를 통합하여 새로운 .NET 버전에서도 돌아가게 하도록 만드는 것으로 보인다. 하지만 .NET Framework 기반으로 만들어졌던 SDK라 리눅스 등의 OS에서 사용시에는 주의해야할 것이다. 
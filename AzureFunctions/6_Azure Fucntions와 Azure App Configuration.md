# Azure Functions - Azure Functions 설정 Azure App Configuration 연결
> 클라우드에서 속성의 관리가 가능한 Azure App Configuration을 연결하는 방법에 대해 알아보자.

## Azure App Configuration 리소스 만들기

1. [Azure Potal](https://portal.azure.com/) 에서 'App Configuration'를 선택해 '만들기'<br><br>![image](https://user-images.githubusercontent.com/39551265/176565010-e9d044f9-04ad-4977-b7bd-fc8d69613e79.png)<br>

2. '리소스 그룹', 위치, 리소스 이름, 가격 등급을 선택 후 생성<br><br>![image](https://user-images.githubusercontent.com/39551265/176566768-840c69f4-69d2-4eb6-b4f6-997178f69dda.png)<br>

3. 'Access Keys' 메뉴에서 'Connection String'을 복사한다. 이후 해당 리소스에 접속을 하기위해 필요하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176568063-592e21ec-8a46-4c32-bf41-5fe246e3530f.png)<br>

4. 설정값을 한번 지정해보자. 'Configuration exploer' 메뉴로 들어와 <span style style="color:red">+ Create</span> 클릭 후 'key-value'를 선택한다.

5. 'key' 항목에는 속성의 Key 값, 'Value' 항목에는 'Value' 항목에는 속성의 값 을 입력하고 설명을 추가하려면 'Label'항목에 설명을 추가하고 type까지 지정해두려면 'Content type'항목에 type을 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176570122-33cb3d24-5d51-4a5b-b00d-8c7f8f6d02a1.png)<br>


## Azure Functions에서 App Configuration 사용

1. Azure Fucntions 프로젝트에서 '새 항목' 추가를 선택해 `Startup.cs' 파일을 생성한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176573188-e9eba773-c1dc-4104-9adf-8b177fb9bc0a.png)<br>

2. Nuget Package로 `Microsoft.Extensions.Configuration.AzureAppConfiguration` 와 `Microsoft.Azure.Functions.Extensions` 를 추가하거나 업데이트한다.

3. 이후 아래 소스에서 'namespace명'을 변경해 복사해 넣어보자


```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof('namespace명'.Startup))]

namespace `namespace명`
{
    internal class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            //환경변수로 App Configuration 연결 문자열 가져오기
            string cs = Environment.GetEnvironmentVariable("ACCS");
            
            builder.ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            // 연결문자열로 AppConfiguration 설정 가져오기
            builder.ConfigurationBuilder.AddAzureAppConfiguration(cs);
            
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
        }
    }
}
```

4. 우선 assembly를 사용하여 Startup에서 Functions가 시작할때 사용하는 형식을 가져온다.

5. 이후 클래스에 `FucntionStartup`을 상속받는다.

6. `ConfiguraeAppConfiguration` 을 overide 하여 `IFucntionsConfigurationbuilder`의 builder를 사용 가능하게 된다.

7. `builder.ConfigurationBuilder.AddAzureAppConfiguration(연결문자열값)`을 입력해 속성을 등록한다. 만약 내부에서 확인하려면 파일의 속성을 가져오는 것도 방법이다.

8. Azure Fucntions 실행 함수가 존재하는 파일로 돌아와 (기본값 Function1.cs) 최상단에 `using Microsoft.Extensions.Configuration;` 를 추가한다.

9. 그다음 `IConfiguration`의 인스턴스를 가져오는 생성자를 추가한다.


```
private readonly IConfiguration _configuration;

public Function1(IConfiguration configuration)
{
    _configuration = configuration;
}
```

10. 이후 함수에서 `string key = _configuration["Test"];` 를 추가해 app Configuration에 등록한 속성값이 받아와지는지 확인한다.
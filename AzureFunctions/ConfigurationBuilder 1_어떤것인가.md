# C# - ConfigurationBier 1 - ConfigurationBuilder란?
> ConfigurationBuilder는 .NET 에서 키-값 형태로 외부에서 설정을 참조할 수 있는 라이브러리입니다. 작업하려는 각 데이터 원본에 대해 공급자가 제공됩니다.

## 기본적인 데이터 원본
> 설정을 구성시 여러가지 원본에서 가져올 수 있다. 기본적으로 제공하는건 다음과 같다. 다음에 나열된 데이터 원본 이외의 데이터 원본에서 로드하려는 경우 사용자 지정 공급자를 사용하여 직접 구성할 수 있다. 우선 순위를 설정하고 여러 데이터 원본을 조합하여 로드할 수도 있다.
 
- Azure Key Vault
- 실행 인수
- 디렉토리 경로 파일
- 환경변수
- 메모리 .NET 오브젝트
- 구성파일
- User Secrets(Secret Manager)
- Azure App Configuration

## 왜 필요한가?
> 응용 프로그램 설정은 환경마다 다르며 코드와 분리되어야 한다. 구성에는 보안상의 이유로 코드(및 해당 Git 리포지토리)에 포함시키지 않아야 하는 외부 서비스 자격 증명과 같은 중요한 정보도 포함되어 있다. 이걸 구성하는데 도움을 주는 것이 ConfigurationBuilder이다.

## 키 계층 구성 파일
> ConfigurationBuilder에는 Key-Value 형태로 값을 등록한다. Json원본에는 다음과 같은 계층적 형태로 저장하게 된다.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  },
  "localSet": "localSetValue"
}
```

- 사용시에 한 개의 값만을 갖고 있다면 다음과 같이 Key값을 사용하면 Value값을 가져온다. `"localSet" => "localSetValue"`
- 사용시에 여러 개의 값을 포함하고 있다면 다음과 같이 Key값에 ':'을 추가해서 하위 항목의 key 값을 사용한다. `"Values:FUNCTIONS_WORKER_RUNTIME" => "dotnet"`


## Azure Functions에서 App Configuration 사용
> 보통 앱 서비스나 Azure Functions 등을 사용하면 Configuration을 구성할 수 있는 것을 생성자에서 인터페이스로 제공한 다. 그리고 사용시에는 'builder'라는 변수명으로 사용하도록 권장하고 있다. 여기서는 Azure Fucntions에서 ConfigurationBuilder를 구성할 수 있는 함수 생성자의 인터페이스에서 ConfigurationBuilder를 사용해본다. 

1. Azure Fucntions 프로젝트를 만들고 '새 항목' 추가를 선택해 `Startup.cs' 파일을 생성한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176573188-e9eba773-c1dc-4104-9adf-8b177fb9bc0a.png)<br>

2. Nuget Package로 `Microsoft.Extensions.Configuration.AzureAppConfiguration` 와 `Microsoft.Azure.Functions.Extensions` 를 추가하거나 업데이트한다.

3. 'Startup.cs'파일에 소스는 다음과 같이 추가해 본다.

```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof({프로젝트명으로 교체}.Startup))]

namespace {프로젝트명으로 교체}
{
    internal class Startup : FunctionsStartup
    {
        //Azure Functions에서는 IFunctionsConfigurationBuilder에서 IConfigurationBuilder를 생성하는 Interface를 사용
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            // builder 변수의 ConfigurationBuilder의 속성을 변경한다.
            builder.ConfigurationBuilder
                // SetBasePath는 설정파일들을 검색할 기본 위치를 설정한다.
                //설정을 안하면 프로젝트가 존재하는 위치에서 설정된다.
                //웹 서비스를 실행하는 서비스(클라우드 앱 서비스나 Azure Functions 등)에서는 실행되는 위치를
                //Directory.GetCurrentDirectory()를 이용해 가져와야 한다.
                .SetBasePath(Directory.GetCurrentDirectory())

                //Json 파일을 이용한 사용시에는 AddJson을 사용한다.
                //사용시에는 (경로, 반드시 필요여부(false이면 파일이 존재해야한다, reload 이벤트 핸들러 실행시 파일변경사항을 다시 불러올지 여부) 를 포함
                //나중에 선언한 것으로 속성이 덮어쓰기가 되니 테스트 혹은 확인용 설정을 먼저 선언 후
                //서비스에서 환경변수나 Secret을 설정해서 검색할 수 있는 경로에 파일을 위치시킨다.
                .AddJsonFile("local.settings.json", optional: false, reloadOnChange: false)
                                
                //현재 설정된 키와 값을 토대로 Build를 실행한다.
                .Build();

        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            // 실행시 콘솔에 false 출력
            Console.WriteLine(builder.GetContext().Configuration["IsEncrypted"]); 

            // 실행시 콘솔에 dotnet 출력
            Console.WriteLine(builder.GetContext().Configuration["Values:FUNCTIONS_WORKER_RUNTIME"]); 
        }
    }
}
```

4. 해당 소스를 실행해 보면 'local.setting.json'파일에 있던 설정 값을 함수 실행시 출력하는 것을 확인 가능할 것이다. 여기서 ConfigureAppConfiguration을 override 할 때 'IFunctionConfigurationBuilder'를 사용하는 것을 확인 가능할 것이다. 이곳에는 IConfigurationBuilder 를 포함하고 있는데 이후 해당 인터페이스를 다른 함수에서 생성자로 사용 가능하다.

5. ConfiguationBuilder를 사용시 가장 기본적인 많이 사용할 것은 `.SetBasePath()`,`.AddJsonFile()`,`.Build()`를 사용하게 될 것이다. 각각 디렉토리 설정, Json파일에서 설정값 가져오기, 설정된 값으로 Build 작업을 나타낸다. 이후 더 자세한 건 다음에 소개할 것이다.

6. 이후 Functions에서 사용시에는 각 함수 Class 안에 다음과 같은 소스코드를 추가한다. 그리고 `static`을 제거한다.

```c#
private readonly IConfiguration _configuration;

public Function1(IConfiguration configuration)
{
    _configuration = configuration;
}
```


7. 그 후  Run() 메서드 안에서 `_configuration["TestSet"]` 이런식으로 사용이 가능하게 된다.

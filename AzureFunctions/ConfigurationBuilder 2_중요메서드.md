# C# - ConfigurationBuilder 2 - 중요메서드
> ConfigurationBuilder는 .NET 에서 키-값 형태로 외부에서 설정을 참조할 수 있는 라이브러리입니다. 이번에는 ConfigurationBilder의 중요 메서드를 알아보자. 이후 사용할 소스코드의 생성 과정등을 모른다면 [기본설명](https://nanenchanga.tistory.com/entry/C-ConfigurationBier-1-ConfigurationBuilder%EB%9E%80)을 참조하자


## 참고할 소스코드

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
            //환경변수로 경로 가져오기
            string envSetting = Environment.GetEnvironmentVariable("EnvSetting");

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
                .AddJsonFile("TestSettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"local.{envSetting}.json", optional: true, reloadOnChange: false)
                                
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

## SetBasePath()

1. 설정파일 등을 검색할 기본 위치를 설정한다.
2. 설정을 안하면 실행파일이 존재하는 위치에 설정한다.
3. 웹 서비스를 실행하는 서비스(클라우드 앱 서비스나 Azure Fucntions 등)에서는 실행되는 위치를 Directory.GetCurrentDirectory()를 설정해 두어야 서비스가 실행되는 위치를 기점으로 파일을 검색한다.
4. 모든 설정파일을 한 폴더에 위치할 필요는 없고 용도에 때라 기본 경로만 설정하고 나머지는 '폴더명\파일명' 식으로 찾도록 할 수 있다.

## AddJsonFile
1. Json 파일을 읽어서 속성값을 등록한다.
2. 사용시에는 SetBasePath 에서 설정하거나 설정하지 않았다면 실행파일 위치를 기준으로 경로를 입력한 파일을 찾는다.
3. optional 을 false로 설정시 반드시 파일이 존재해야만 한다.
4. optional 을 true로 설정시 파일이 존재하지 않으면 속성을 추가하지 않는다.
5. 나중에 호출한 메서드로 속성값이 덮어씌어지게 된다. 만약 'local.settings.json' 과 'local.{envSetting}.json' 파일에서 같은 Key 값 'Test'가 존재한다고 하면 나중에 호출한 'local.{envSetting}.json'에서 설정한 값으로 속성값이 정해진다.
6. Git이나 앱 서비스 상에 업로드 시에는 Optional 값을 true로 한 파일을 환경변수나 Secret으로 해당 경로에 생성한 파일을 사용한다.


## Build

1. 현재까지 설정한 값들을 기준으로 Build를 하여 속성을 사용 가능하도록 만든다.
2. ConfigurationBuild를 사용시 마지막에 사용하자

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof(AppConfigurationSample.Startup))]

namespace AppConfigurationSample
{
    internal class Startup : FunctionsStartup
    {
        //Azure Functions에서는 IFunctionsConfigurationBuilder에서 IConfigurationBuilder를 생성하는 Interface를 사용
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            //환경변수로 경로 가져오기
            string envSetting = Environment.GetEnvironmentVariable("EnvSetting");

            // IConfiguration을 builder 변수의 ConfigurationBuilder의 속성을 변경한다.
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
                
                //환경변수로 선언한 값에서 속성을 가져온다.
                .AddEnvironmentVariables()

                .AddUserSecrets<FunctionsStartup>(optional:true)

                //현재 설정된 키와 값을 토대로 Build를 실행한다.
                .Build();

        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            Console.WriteLine(builder.GetContext().Configuration["US"]);
            Console.WriteLine(builder.GetContext().Configuration["localSet"]);
            Console.WriteLine(builder.GetContext().Configuration["TestSetting:Test1"]);
        }
    }
}
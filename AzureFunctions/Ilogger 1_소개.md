# ILogger 1 - 소개
> ILogger는 로깅 작업을 효율적으로 하기위한 작업을 지원한다. 다른 로깅(nlog,serilog,log4net) 작업을 도와주는 것과 다른점은 마이크로소프트에서 기본적으로 제공해준다는 것과 무엇보다 Azure Application Insights와 연결이 쉽게 되어있다는 것이다. Azure Functions를 사용한다면 기본적으로 사용할 수 있으며 host.json의 설정값만 변경해서 사용하면 된다.

## 콘솔 프로젝트에서 기본적 사용법

1. `Microsoft.Extensions.Logging.Console` Nuget 패키지를 설치해보자 해당 패키지는 콘솔에서 Ilogger를 사용하는 SDK를 보유하고 있다.

2. 우선 `Microsoft.Extensions.Logging` namespace를 사용 선언한다.

3. 로깅 작업을 위한 설정을 만들기 위해 IloggerFactory 변수를 만들어 로깅형식을 설정한다.

4. 그 후 CreateLogger를 선언해 Ilogger를 생성한다.

5. 생성한 Ilogger를 이용해 로깅을 실행해 나가면 된다.

```c#
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder =>
                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "hh:mm:ss ";
                }));

ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
using (logger.BeginScope("[scope is enabled]"))
{
    logger.LogInformation("Hello World!");
    logger.LogInformation("Logs contain timestamp and log level.");
    logger.LogInformation("Each log message is fit in a single line.");
}

```
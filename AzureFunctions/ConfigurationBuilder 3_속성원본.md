# C# - ConfigurationBuilder 3 - 중요 속성 원본별 설명
> ConfigurationBuilder는 .NET 에서 키-값 형태로 외부에서 설정을 참조할 수 있는 라이브러리입니다. 이번에는 ConfigurationBilder로 속성을 설정할 시 사용하는 종료들에 대해 알아보자. 이후 사용할 소스코드의 생성 과정등을 모른다면 [기본설명](https://nanenchanga.tistory.com/entry/C-ConfigurationBier-1-ConfigurationBuilder%EB%9E%80)을 참조하자


## JSON, XML 등의 파일
> 현재 가장 많이 사용하는 방법은 JSON 파일이다. 기존 .NET FrameWork 시절에서 사용하던 XML 등의 파일도 가져오는 것이 가능하지만 가능하면 JSON 형식으로 사용하자.


1. JSON 파일의 기본 형식은 다음과 같다.

```json
{
  "TestSetting": {
    "Test1": "Test1",
    "Test2": "설정2",
    "Test3": "속성3"
  },
  "TestSet": "setting"
}
```

2. 사용시에는 다음과 같이 'Add파일형식File' 매서드를 제공하며 파일 경로를 입력하여 사용한다. 원하는 파일을 사용시 namespace가 지정되어 있지 않아 불러올 수 없다면 NugetPackge에서 `Microsoft.Extensions.Configuration.{파일형식}`을 설치


```c#
public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("JSON_File.json")//Json파일을 불러올때 사용
        .AddXmlFile("Xml_File.xml")//Xml 파일을 불러올때 사용
        .biuld();
}
```

## 환경변수
> 환경변수에 등록한 값을 가져온다.

1. 프로젝트 혹은 실행환경에 등록된 환경변수를 사용한다. Visual studio 프로젝트에서 환경변수 등록은 다음 이미지를 참고하자.<br><br>
![image](https://user-images.githubusercontent.com/39551265/177147965-6c5f6e46-c806-4fe5-a700-855f77b781aa.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/177148128-0917003b-039a-4148-92fb-38065e5009cb.png)

2. 사용시에는 다음과 같이 사용한다. 사용시 namespace가 지정되어 있지 않아 불러올 수 없다면 NugetPackge에서 `Microsoft.Configuration.ConfigurationBuilders.Azure` 설치


```c#
public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        //환경변수로 선언한 값에서 속성을 가져온다.
        .AddEnvironmentVariables()
        .build();
}
```

## UserSecret
> SecretManager를 이용해 설정된 UserSecret을 이용하여 등록한다.

1. SecretManger로 등록한 값을 사용한다. JSON형식과 같은 형식으로 지정하면 되며 Visual Studio 프로젝트에서 다음 이미지를 참고해서 등록하자. 첫 등록시에는 NugetPackage를 설치하라는 문구가 뜨면 설치하여 사용하면된다.<br><br>![image](https://user-images.githubusercontent.com/39551265/177149346-ec60cb94-a104-4881-bad0-988264e9b57a.png)<br><br>

2.  사용시에는 다음과 같이 사용한다. 사용시 namespace가 지정되어 있지 않아 불러올 수 없다면 NugetPackge에서 `Microsoft.Configuration.ConfigurationBuilders.UserSecrets` 설치

```c#
public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        //UserSecrtManager에서 등록된 값을 가져온다.
        .AddUserSecrets<FunctionsStartup>()
        .build();
}
```


## 그 외

1. 메모리 : 메모리에 등록된 값을 직접 ConfigurationBuilder로 등록할 수 있지만 메모리의 값을 굳이 사용할 이유는 없을 것이다.

2. KeyVault : Azure Key Vault로 암호화되어 있던 값을 사용시에 복호화 하여 사용할 수 있다. 기초적인 사용법은 다음을 참고하자

3. Azure App Configuration : 클라우드에 속성값들을 등록해서 앱을 실행시 불러와 사용이 가능하다. 사용자는 리소스에 접속하기 위한 연결 문자열만 보안으로 지키면 되고 여러 프로젝트에서 하나의 리소스를 바라보고 사용이 가능해 더 편한 관리가 가능하다. 기초적인 사용법은 [다음](https://nanenchanga.tistory.com/entry/Azure-Functions-Azure-Functions-%EC%84%A4%EC%A0%95-Azure-App-Configuration-%EC%97%B0%EA%B2%B0)을 참고하자
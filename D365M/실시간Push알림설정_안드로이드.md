# D365 마케팅 실시간 Push 알림 설정 Maui - 안드로이드 Cloud Messaging API 사용

## 실시간 마케팅 Push 알림 알아보기
실시간 마케팅은 아웃바운드 마케팅과 다르게 고객 각각의 상태변화에 따라 대응하기 위한 마케팅이다. 아웃바운드 같은 경우는 생일이 포함된 모든 고객들을 모아 한번에 대응하는 메시지 등을 보냈다면 실시간 마케팅은 고객등급 변화 등의 고객 상태 정보가 변동될시 바로 마케팅 메시지를 보내도록 설정한다. 이 중 여기서는 Push 알림 설정에 대해 알아본다.

1. 일단 D365 마케팅에 접속해서 '설정' 영역으로 변경 후 '푸시 알림'으로 들어간다. 여기서는 푸시알림을 설정할 기기를 등록하기 위한 구성을 생성할 수 있다. '+ 새 모바일 앱'을 통해 모바일 앱 등록을 위한 구성을 추가한다.

![스크린샷 2023-08-03 150404](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b4b01e43-4d44-446d-b95f-a56bbe6b51a1)

2. 모바일 앱 구성의 이름을 입력하고 '다음'으로 넘어간다. 그러면 '모바일 앱 추가'에서 Android(FCM) 영역에서 API키를 입력해야한다. 이것에 대해 알아본다.

![스크린샷 2023-08-03 155817](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/960986d6-494e-4f49-929d-2c2d45c97072)

## FireBase 프로젝트 생성

1. [FireBase Console](https://console.firebase.google.com/u/0/?hl=ko)에 접속한다.

2. 프로젝트 만들기를 선택 프로젝트명을 입력후 기존 애널리틱스가 없다면 생성을한다.

![스크린샷 2023-08-04 131359](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/8f07f372-f8a7-42c9-b9b6-ff7a5e494366)
![스크린샷 2023-08-03 162115](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/583de514-8d68-439a-ab9b-76f4558f59f3)


## maui 앱 준비
> Kotline, C++ 등의 앱에서 앱 사용 방법은 [공식문서](https://firebase.google.com/docs/android/setup?hl=ko&authuser=0&_gl=1*1bl0vde*_ga*NTE1MDA5MDkyLjE2ODg5NTIxOTI.*_ga_CW55HF8NVT*MTY5MTEzMjIzMC41NS4xLjE2OTExMzI2NzguMC4wLjA.)를 확인한다.

1. 일단 Visual Studio에서 새 maui 프로젝트를 준비한다. 여기서는 Blazor가 아닌 Maui 앱을 사용한다.

![스크린샷 2023-08-07 092853](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/026b0648-3ddb-412d-a52e-4b3e9b82b7b6)

2. Nuget Package로 'Plugin.Firebase'과 'Plugin.Firebase.Crashlytics' 두개를 설치한다.

![스크린샷 2023-08-07 095505](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/bf3fb71b-be87-4c28-8113-2c5eb2f37e21)

3. 프로젝트가 생성되면 csproj 파일을 열어 기존 타켓프레임워크를 IOS와 Android app을 제외한 프로젝트가 빌드되지 않도록 주석처리 한다.

```xml
    <TargetFrameworks>net6.0-android;net6.0-ios;</TargetFrameworks>
		<!--<TargetFrameworks>net6.0-android;net6.0-ios;net6.0-maccatalyst</TargetFrameworks>-->
		<!--<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net6.0-windows10.0.19041.0</TargetFrameworks>-->

```

4. nuget 패키지가 안드로이드와 IOS로만 타겟되도록 설정을 변경한다.

```xml
    <!--<ItemGroup>
	  <PackageReference Include="Plugin.Firebase" Version="2.0.5" />
	  <PackageReference Include="Plugin.Firebase.Analytics" Version="2.0.1" />
	</ItemGroup>-->

	<ItemGroup Condition="'$(TargetFramework)' == 'net6.0-ios' OR '$(TargetFramework)' == 'net6.0-android'">
		<PackageReference Include="Plugin.Firebase" Version="2.0.5" />
		<PackageReference Include="Plugin.Firebase.Analytics" Version="2.0.1" />
	</ItemGroup>
```

5. FCM이 제공하는 최소 플랫폼 버전도 ios와 android를 설정해둔다.

```xml
    <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'ios'">14.2</SupportedOSPlatformVersion>
		<!--<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'maccatalyst'">14.0</SupportedOSPlatformVersion>-->
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">21.0</SupportedOSPlatformVersion>
		<!--<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</SupportedOSPlatformVersion>-->
		<!--<TargetPlatformMinVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</TargetPlatformMinVersion>-->
		<SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'tizen'">6.5</SupportedOSPlatformVersion>
```

## Firebase 앱 등록

1. Firebase로 돌아가 프로젝트 화면에서 '참여 -> Messaging'

![스크린샷 2023-08-04 132705](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/72d06524-7c26-4f9d-8f4a-ead85cd2be11)

2. 안드로이드 아이콘을 클릭해 안드로이드 프로젝트를 만든다.

![스크린샷 2023-08-03 161356](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/259a32a6-f836-4e4f-bf6e-0e77d68d8cdd)

3. 앱등록시 안드로이드 패키지 이름을 입력한다.(패키지 이름은 프로젝트 파일에서 확인 <ApplicationId> 에 있다)

![스크린샷 2023-08-04 141014](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b5c0c681-321d-4feb-8d24-03884c49404d)

4. google-services.json파일을 다운로드 받는다. 해당 파일을 Maui 프로젝트 위치에 이동시키고 포함시킨다. 해당 파일이 안드로이드 프로젝트에 포함되도록 설정한다. 빌드 액션은 `GoogleServicesJson` 로 설정한다.(프로젝트에 파일을 포함했을시 자동으로 생성되는 건 지운다)  이후의 단계는 전부 건너띄고 콘솔로 돌아간다.

```xml
<ItemGroup Condition="'$(TargetFramework)' == 'net6.0-android'">
    <GoogleServicesJson Include="google-services.json" />
</ItemGroup>
```

![스크린샷 2023-08-04 155724](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a563dc68-d97f-4158-8826-37d5f7cdd15f)


## maui firebase 소스코드 변경

1. MauiProgram.cs 파일에 FireBase 서비스를 등록하기 위한 메서드를 추가한다. 아래와 소스코드는 아래와 같다.


```cs
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using Plugin.Firebase.Crashlytics;
#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
#else
using Plugin.Firebase.Bundled.Platforms.Android;
#endif

namespace MauiFirebaseDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterFirebaseServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }

    /// <summary>
    /// FireBase 서비스 등록
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(CreateCrossFirebaseSettings());                
                CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true); 
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));//Firebase 사용
                CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);//Crashlytic 사용
#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    /// <summary>
    /// FireBase 세팅
    /// </summary>
    /// <returns></returns>
    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(
            isAuthEnabled: true, 
            isCloudMessagingEnabled: true, //알림 받는 것만을 사용하면 위에까지만 설정하면 된다.
            isAnalyticsEnabled: true);  //Crashlytics를 사용시 적용
    }
}
```

2. 프로젝트 폴더/platforms/Android/Resources/values/strings.xml 파일을 만들어 다음과 같은 값을 입력한다. (crashlytics 사용하려면 id를 입력한다)

```xml
<?xml version="1.0" encoding="utf-8" ?>
<resources>
    <string name="com.google.firebase.crashlytics.mapping_file_id">none</string>
</resources>
```

3. `MainPage.xaml.cs` 파일에서 `OnCounterClicked` 이벤트 핸들러에 다음 코드를 추가한다.

```cs
private async void OnCounterClicked(object sender, EventArgs e)
{
    await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
    var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
    Console.WriteLine($"FCM token: {token}");
}
```

4. FCM으로 데이터를 받을 수 있는 최소한의 설정이 완성되었다. 서버에 등록 등의 추가작업은 추가작업이 필요하다. 일단 프로젝트를 실행해본다.  
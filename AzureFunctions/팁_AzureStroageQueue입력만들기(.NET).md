# Azure Storage Queue - .NET에서 입력 만들기
> Azure Storage Queue는 Azure Functions 나 Web Job, Power Automate 등의 여러가지 트리거를 이용할 수 있는 유용한 서비스이다. 여기서는 .NET 콘솔환경에서 Azure Stroage Queue에 새로운 문자열을 입력하는 방법을 설명한다.

## Azure Stroage Queue 연결 문자열 복사

1. Azure Potal 에 접속한다.
2. 사용하려는 Azure Storage 리소스에 접속한다.
3. '엑세스 키' 메뉴로 들어간다. 그 후 <span style="color:red">키 표시</span>를 클릭 후 'key1' 혹은 'key2'의 연결문자열을 복사한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169935077-db13819f-8445-43a0-9eb1-b4e52c11559b.png)<br>


## Nuget Package 설치

1. Visual Studio '새 프로젝트 만들기'를 사용해 '콘솔 앱'을 생성한다.(여기서는 .NET 6 FrameWork를 기준으로 설명)

2. '솔루션 탐색기'에서 프로젝트파일을 마우스 오른쪽 클릭 -> <span style="color:red">nuget 패키지 관리</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/169936519-8109c6cf-3ad7-4999-a340-d7372962e687.png)<br>

3. 'Nuget 패키지 관리자' 창에서 `Azure.Storage.Queues` 를 검색하여 설치한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169936755-fafecfa4-5373-4e7f-aae7-7f0569f6f623.png)<br>

## Queue에 문자열 값 입력 코드 작성

1. Program.cs 파일 등의 코드가 실행되는 위치에서 `using Azure.Stroage.Queues;`를 추가한다.

2. 설정파일에서 방금 복사한 '연결 문자열'을 붙여넣는다.(필자는 `StorageConnectionString` 로 설정하였다.)

3. 다음 함수를 추가한다. 적용 위치에 알맞게 변경하자. 아래코드에서 config는 Json에서 설정값을 가져오는 [방법](https://docs.microsoft.com/ko-kr/dotnet/core/extensions/configuration-providers#file-configuration-provider)이다.


```c#
void InsertMessage(string queueName, string? message)
{
    // 설정에서 연결문자열 가져옴
    string connectionString = config["StorageConnectionString"];

    // queueClinet 인스턴스화
    QueueClient queueClient = new QueueClient(connectionString, queueName);

    // 큐가 존재하지 않으면 새로 생성
    queueClient.CreateIfNotExists();

    if (queueClient.Exists())
    {
        // 큐에 값 입력
        queueClient.SendMessage(message);
    }

    Console.WriteLine($"입력된값: {message}");
}
```

4. 위의 코드는 queue의 이름과 메시지 내용을 입력받고 queue에 입력하는 과정을 갖는다. 이제 queue에 들어갈 값을 입력받기 위하여 `var insertString = Console.ReadLine();`을 추가한다.

5. 그 후 queue 입력 함수를 실행하기 위하여 `InsertMessage("{큐의 이름}", insertString)`을 추가한다.

6. 아래는 Program.cs에서만 코드를 작성하였다면 작성되는 전체 소스코드이다.

```c#
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();


var insertString = Console.ReadLine();

InsertMessage(config["QueueName"], insertString);


void InsertMessage(string queueName, string? message)
{
    // 설정에서 연결문자열 가져옴
    string connectionString = config["StorageConnectionString"];

    // queueClinet 인스턴스화
    QueueClient queueClient = new QueueClient(connectionString, queueName);

    // 큐가 존재하지 않으면 새로 생성
    queueClient.CreateIfNotExists();

    if (queueClient.Exists())
    {
        // 큐에 값 입력
        queueClient.SendMessage(message);
    }

    Console.WriteLine($"입력된값: {message}");
}
```

## 실행결과 확인
1. 프로젝트를 실행하고 Queue에 입력할 값을 터미널에서 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169949709-772d3c3a-4e53-4ce7-b556-b32dd2b4548c.png)<br>

2. Stroage 리소스에 들어가서 '큐' 메뉴로 들어와서 데이터를 입력한 queue 항목에 들어간다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169950584-4cbcd7c4-be8f-4c5e-a093-31f751a3ffa9.png)<br>

3. 리스트에서 자신이 추가한 항목이 생성된 것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/169950479-b1301dac-74c7-49e0-ae1a-81a5ef9f1954.png)<br>

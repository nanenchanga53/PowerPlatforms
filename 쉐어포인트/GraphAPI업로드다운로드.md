# Graph API 를 이용한 SharePoint 업로드 다운로드
>sharepoint에 파일을 업로드 다운로드 하는 graph api 사용법에 대해 알아본다. 일단 여기서 하려는 것은 Dataverse와 연결된 shaepoint이다. Dataverse와 sharepoint 연동에 대해서는 여기를 참고하자

## Microsoft Graph Explorer 사용법
> Graph Explorer는 HTTP 요청을 통해 Microsoft Graph API를 대화식으로 테스트하고 확인하는데 사용할 수 있는 웹 기반 도구이다. 여기 사이트에서 기본적인 예제를 통해 어떤 URL로 명령을 날렸을시 반환 다른 언어에서는 어떻게 사용할지 스크립트를 생성해준다.

1. 사용방법 [사이트](https://developer.microsoft.com/en-us/graph/graph-explorer)에 접속한다.

2. 해당 사이트에서는 로그인 한 아이디를 기준으로 토큰을 생성 할 수 있다. 우측상단의 사람아이콘을 클릭해 로그인한다.

![스크린샷 2023-07-26 164605](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a897fdd2-8738-4b52-bc22-6e6130b5fd6a)

3. Modify permissions에서 현재 선택된 예제를 실행하기 위한 필요 scope 리스트를 볼 수 있다. Status에서 파란색 버튼(Conset)을 눌러서 인증을 변경할 수 있다. 다음 이미지에서는 자신의 프로필 정보 불러오는 API를 실행하는데 사용하는 예제이다. Run Query 버튼을 통해 결과를 받아올 수 있다.

![스크린샷 2023-07-27 094552](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9e77d3c7-a8d0-4d7c-91cc-e19984b67c97)

4. 우리의 목적은 sharepoint 접속과 파일 검색, 업로드이다. 좌측 Sample Qeries에서 sharepoint site의 정보를 가져올 수 있는 예제와 파일의 정보를 가져올 수 있는 OneDrive 목록들의 예제들을 선택하고 'Modify permissions'를 확인해보자 여기서 공통적으로 확인할 수 있는 Scope가 'Sites.ReadWrite.All'이라는 것을 확인 가능하다. 이후 API 사용예제에서는 해당 Scope를 사용하게 된다.

![스크린샷 2023-07-27 094552](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/884a122d-abad-495d-8beb-f0b8b95f53a0)

5. 다른 언어의 SDK에서 해당 api 예제에 해당되는 동작을 불러올시 작성해야할 스크립트도 확인 가능하다.

![스크린샷 2023-07-27 135810](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b4db94cb-c354-4f95-8941-51199ad70313)

6. 예제에 없는 것은 [여기](https://learn.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0)에서 참고하고 URL을 생성하자

## API를 활용하여 Sharepoint에 파일업로드

1.  Azure AD에 접속하여 앱을 추가하거나 기존 앱에 접속한다.

![스크린샷 2023-08-03 100650](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b7584011-117c-4b00-a2f8-7f50d99c18c0)

2. 
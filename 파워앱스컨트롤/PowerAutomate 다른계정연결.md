# Power Automate 다른 계정 연결
> Power Automate에서 OneDrive For Business 의 경우 로그인한 각 사용자의 디렉토리에 파일이 생성되며 공유폴더에는 파일을 생성할 수 없다. Power Autmate에서 그렇다면 다른 계정을 연결할 경우 어떻게 되는지 알아보자.

## OneDrive For Business 공유폴더로 생성할 수 없는것을 확인
1. Power Automate 흐름에서 'OneDrive For Business' 단계를 만들고 파일을 생성해 본다. 만약 파일생성에 대해 잘 모른다면 [카메라 컨트롤](https://nanenchanga.tistory.com/entry/Power-Apps-%EC%BB%A8%ED%8A%B8%EB%A1%A4-%EC%B9%B4%EB%A9%94%EB%9D%BC-%EC%BB%A8%ED%8A%B8%EB%A1%A4-3)를 참고하자. <br><br>![화면 캡처 2023-01-05 103650](https://user-images.githubusercontent.com/39551265/211717127-9a34b676-05bd-4255-b41e-a59187064424.png)<br>

2. 파일이 제대로 생성되었다면 자신이 PowerAutomate로 로그인한 아이디의 원드라이브의 경로에 파일이 생성된 것을 확인 가능하다.<br><br>![화면 캡처 2023-01-17 091025](https://user-images.githubusercontent.com/39551265/212783330-bd014d2c-ffe1-4cac-8b96-d167dfc314db.png)<br>

3. 그렇다면 Power Automate에서 연결을 변경해서 실행해 보자.<br><br>![화면 캡처 2023-01-25 102402](https://user-images.githubusercontent.com/39551265/214459749-6136e26a-2ce5-41d9-b0bc-dfc30af00b75.png)<br>

4. 연결을 바꿔 로그인한 아이디의 OneDrive 경로에 새로 파일이 생성되는 것을 확인 가능하다.(원래 자신의 OneDrive 경로에 생기지 않는다.)<br><br>![화면 캡처 2023-01-25 105144](https://user-images.githubusercontent.com/39551265/214463975-26345b19-109c-4c37-8194-16ce8ac51c6a.png)<br>

5. 공유된 폴더를 바로가기로 만들어 같은 폴더경로를 생성하면 Power Automate에서 저장시 오류를 반환한다.<br><br>![화면 캡처 2023-01-25 135418](https://user-images.githubusercontent.com/39551265/214487744-bce94fdb-3f4b-4a94-b795-fb49cb846a92.png)<br>

6. 파워 앱스 등으로 공유하였다면 OneDrive 등의 연결시 로그인한 아이디로만 연결이 가능하기에 사용하는 사용자의 아이디가 아닌 연결을 선택한 아이디로 로그인해야 하는 상황이 생긴다.<br><br>![화면 캡처 2023-01-05 103749](https://user-images.githubusercontent.com/39551265/214464136-dd81551d-dfcb-4b40-ba90-e25703cb0197.png)<br>

7. 만약 여러 아이디로 로그인해서도 같은 위치에 파일을 생성하는 흐름을 만들려면 사이트 주소부터(최상위 경로) 입력하는 SharePoint등을 이용하는 것이 좋다.(각 사용자가 입출력 권한을 부여한 상태여야 한다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/214467148-7d2ec319-0514-4daf-9ccc-1a35c8a2e1b0.png)<br>

## 결론
1. Power Automate 등의 연결을 이용시 자신의 아이디가 아닌 특정 아이디로 로그인한 계정을 사용시 공유하려면 다른 사용자도 해당 흐름에서 로그인할 수 있어야 원하는 결과가 나온다.

2. OneDrive 같은 각자 자신의 계정을 기준으로 사용하는 흐름이 포함될 경우 공유시 원하는 결과를 만들지 못하는 경우가 생길 수 있다.

3. 다른 계정의 아이디와 비밀번호로 로그인 할 수 있다면 해당 계정을 기준으로 불러올 수 있는 흐름을 사용할 수 있다.
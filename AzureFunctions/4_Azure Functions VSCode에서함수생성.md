# Azure Functions - VSCode에서 함수 생성
> Azure Fucntions 리소스에서 직접 함수를 생성 가능하지만 웹에서 직접 코드를 관리하는 것보단 Visual Studio Code 등에서 코드를 작성하고 Git등으로 관리하는 것이 더 효율적이다. .Net(C#)의 경우는 Visual Studio가 더 자잘한 설정이 필요없지만 Visual Studio Code에서 Azure Functions의 함수를 만들어보자. 해당 문서는 .NET 환경을 개발 가능한것으로 가정한다.

## Visual Studio Code에 Azure Functions 개발 환경 설정

1. Power Shell 등의 터미널에서 `npm install -g azure-functions-core-tools@4 --unsafe-perm true` 명령어 실행(npm을 실행해야 하므로 미리 [node.js를 설치](https://nodejs.org/en/download/)

2. 그다음 Visual Studio Code를 실행하여 확장(Ctrl + Shift + X)를 열어 Azure Functions를 설치한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/168037838-237aa56d-dc85-4afb-9131-6e924ce594bb.png)<br>

3. Azure(Shift+Alt+A) 메뉴를 열어 새 프로젝트를 만든다.(Azure Functions 프로젝트가 이미 있다면 번개모양의 아이콘을 클릭)

4. 생성할 폴더의 위치를 선택한다. 가능하면 Browse를 클릭하고 탐색기 창에서 폴더를 선택하는것이 좋다.

5. 그다음 Azure Functions를 사용할 언어를 선택한다.

6. 언어를 선택후 버전과 개방/격리 중 하나를 선택한다.

7. 그다음 트리거를 선택한다.(Http통신을 사용하며 Swagger를 사용하려면 HTTP trigger with OpenAPI를 선택)

8. 함수의 이름을 입력

9. namepace를 입력한다.

10. 그후 함수의 인증방식을 선택한다.

11. 이후 Azure Functions 함수가 만들어지는 것을 확인 할 수 있다.

## 함수를 리소스에 업로드

1. Azure 메뉴에서 구름모양 아이콘 Deploy to Function 을 클릭

2. 그 후 Azure에 로그인한다.

3. 로그인하면 구독을 선택하도록 선택창이 보일것이다. 이곳에서 업로드할 위치의 리소스를 선택한다. 그 후 마우스 오른쪽 클릭을 한 후 <span style="color:red">Deploy to Function App</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/168055831-2f817863-d7de-402c-8e84-9c8f95bd5e67.png)<br>

4. 업로드가 완료되면 Fucntions에서 자신이 업로드한 함수를 확인 가능하다. 마우스 오른쪽을 클릭해 <span style="color:red">Execute Function Now</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/168062801-0a7b193c-7739-4900-9a7b-fe4b2b1ef293.png)<br>

5. 상단에 'Enter request body' 라는 문구와 함께 Body 값을 입력 가능할 것이다. 이곳에서 Body값을 입력하고 'Enter' 키

6. 이후 실행 결과를 우측 하단에서 결과를 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/168062659-7f2ac7a0-5ada-4907-bde7-7ed06405918f.png)<br>
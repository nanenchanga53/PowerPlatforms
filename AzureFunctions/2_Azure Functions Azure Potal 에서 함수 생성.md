# Azure Functions 2 - Azure Potal 에서 함수 생성
> Azure Fucntions 리소스에서 직접 함수를 생성 가능하다. 복잡하지 않은 코드라면 직접 리소스에서 생성해서 만들고 수정이 가능하다. 코드가 복잡해지고 관리할 코드의 양이 많아지면 Visual Studio 등의 다른 환경에서 개발하는 것이 좋다. 

## Azure Potal에서 함수 생성
1. Azure Potal에 접속하여 Azure Functions(함수 앱) 리소스 접속

2. '함수' 메뉴를 열고 <span color:red>만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167299085-7f119f1f-8a4d-4a06-a05d-fcb35ddc2e6f.png)<br>

3. 함수 만들기 페이지가 열릴 것이다.<br>'개발 환경'에는 '포털에서 개발' 선택<br>'템플릿'은 트리거로 사용할 것을 선택한다.(보통 Http trigger를 사용할 것이다.)<br>'새 함수' 항목에서는 함수의 이름을 입력한다.<br>그 후 '만들기'를 클릭해 함수를 만든다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167299169-3a4b50c9-f358-42ea-8b97-0c1d2a237d1e.png)<br>

4. 함수가 만들어지면 해당 함수의 상세 페이지가 열릴 것이다. '코드+테스트' 메뉴로 들어가 보자. run.csx라는 파일에 소스코드가 보일 것이다. 처음 생성시 해당 코드에는 HTTP 통신으로 POST나 GET이 들어오고 파라메터 'NAME'이 들어왔을시 Hello와 함께 반환하는 함수가 만들어진다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167299403-a45c0101-47da-427f-8cf5-62ef5af9f8d8.png)<br>

5. <span style="color:red">테스트/실행</span>을 클릭해보자<br><br>![image](https://user-images.githubusercontent.com/39551265/167299580-924333be-b303-4743-9f5d-a13bf3ede7c6.png)<br>

6. 테스트 페이지가 열릴 것이다. 여기서 해당 함수를 바로 테스트해 볼 수 있다. 'HTTP 메서드'에서 형식을 선택 후 '본문'에서 파라메터를 입력하면된다. 그 후 '실행'을 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167299679-7561cf55-d3ef-42b9-9bbb-076b601abbdf.png)<br>

7. '출력' 탭에서 함수의 출력 결과를 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167300089-87789e04-c55a-4e1a-8482-d8d183ac100c.png)<br>

## 함수를 HTTP로 접속 
1. '코드+테스트'페이지로 돌아와 <span style="color:red">함수 URL 가져오기</span>를 클릭한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167300158-2a26c456-2945-4cda-a705-e5f400bd6db2.png)<br>

2. 'URL'항목을 복사한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167300244-e30fc8bd-c993-4d4f-b7b3-1d5f8d0115af.png)<br>

3. 복사한 URL을 살펴보면 해당 함수를 접속하기 위한 코드를 헤더로 포함하고 있는 것을 확인 가능할 것이다. 여기에 함수를 실행하기 위한 파라메터를 추가하여 호출하면 된다.(기본 생성 코드를 호출하려면 `&name=woochang` 추가)
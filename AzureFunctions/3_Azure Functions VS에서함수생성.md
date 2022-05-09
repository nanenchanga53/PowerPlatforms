# Azure Functions 3 - Visual Studio에서 함수 생성
> Azure Fucntions 리소스에서 직접 함수를 생성 가능하지만 웹에서 직접 코드를 관리하는 것보단 Visual Studio 등에서 코드를 작성하고 Git등으로 관리하는 것이 더 효율적이다. 이번에는 Visual Studio에서 Azure Functions의 함수를 만들어보자

## Visual Studio에서 Azure Functions 함수 생성

1. Visual Studio를 켜고 <span style="color:red">새 프로젝트 만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167252680-37002ac6-d3f6-4fda-a5df-dc3a6229e60b.png)<br>

2. '새 프로젝트 만들기' 에서 <span style="color:red">Azure Functions</span>를 선택후 <span style="color:red">다음</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167252765-ac236fbd-25df-4ab8-bc8b-d555bf1eba3a.png)<br>

3. '새 프로젝트 만들기' 화면에서 프로젝트의 이름,위치,이름을 입력하고 <span style="color:red">만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167328378-41815db6-5e7d-4e91-9a5b-17b19dd9fbe3.png)<br>

4. '새 Azure Functions 애플리케이션 만들기' 창이 열릴 것이다. 새로이 함수를 만들함수의 트리거를 선택(HTTP 통신의 경우는 'Http Trigger'를 선택하자 Swagger를 더하고 싶으면 'with Open API'를 선택))하고 <span style="color:red">만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167340781-c0b9a9bf-265e-499f-ac86-4b67a939c20b.png)<br>

5. 생성하면 다음과 같은 기본 코드가 생성되었을 것이다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167342323-44a20fad-2cc9-4ae8-8629-74dd1a9fbdbd.png)<br>

6. 한번 실행해보자(F5 버튼). Functions 이후의 URL이 표시되는데 이 함수의 이름 옆에 표시되는 URL을 통해 내부에서 HTTP 통신 테스트가 가능하다.(해당 이미지는 OpenAPI를 사용하는 프로젝트로 생성하였다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/167342699-57bfae8e-0fab-4826-8670-c93aca3fa6d6.png)<br>

## Azure Functions 리소스에 개시

1. Visual Studio의 '솔루션 탐색기'에서 Azure Functions 프로젝트를 마우스 오른쪽 클릭 후 <span style="color:red">게시</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167345204-04167431-265b-4f24-827c-0ea88c6dda3e.png)<br>

2. 'Azure'를 선택하고 <span style="color:Red">다음</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167345475-5aeac4cf-6d6c-4ca0-9cf8-ea27b3979b7d.png)<br>

3. Azure Functions리소스에 생성하였던 혹은 생성하려는 환경을 선택한 후 <span style="color:Red">다음</span> 클릭 <br><br>![image](https://user-images.githubusercontent.com/39551265/167345921-12bee5db-432f-4cd3-a788-18d354cacc2b.png)<br>

4. 게시하려는 Azure 계정에 로그인 후 '구독 이름'을 선택 그 후 리소스 그룹 안에 있는 Azure Functions 리소스를 선택한다. 그 후 <span style="color:Red">다음</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167346175-98dc720b-9755-46a9-9815-b809074a7184.png)<br>

5. 그 후 API Management를 선택하는 창이 열리는데 없다면 '이 단계 건너띄기'를 체크한다. '마침' 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167346480-2f8d4b0f-22b8-4144-9419-9e55a5a234f6.png)<br>

6. 그럼 게시 프로필이 생성되는데 이후 업데이트 사항이 있다면 <span style="color:red">게시</span>를 클릭하면 리소스에 업데이트가 된다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167346900-55d2aaaf-6ad6-4bef-9c03-f7796298aade.png)<br>

7. Azure Functions 리소스에서 '게시'가 완료된 함수가 사용 가능한지 확인하자.<br><br>![image](https://user-images.githubusercontent.com/39551265/167347282-95c1125e-4f2a-45a8-97b7-38f719b167d4.png)<br>
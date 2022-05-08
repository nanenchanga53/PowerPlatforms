# Azure Functions 1 - Azure 리소스 생성
> Azure Fucntions는 Azure 적은 코드를 쓰고, 인프라를 적게 유지하고, 비용을 절감할 수 있도록 하는 서버리스 솔루션이다. 애플리케이션을 계속 실행하는 데 필요한 모든 최신 리소스를 클라우드 인프라에서 제공하므로 서버 배포 및 유지 관리에 대해 걱정할 필요가 없다. 여기서는 Azure에서 리소스를 만들어본다.

## Visual Studio에서 코드 생성
1. Azure Potal에 접속하여 <span style="color:red">리소스 만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167253119-86deef61-8d49-44f4-ba0c-131b1c1e8d3b.png)<br>

2. '리소스 만들기' 화면에서 '함수 앱' 리소스의 <spna style="color:red">만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/167253274-728bc7f2-48be-49eb-bced-85bea8ed0070.png)<br>


3. '함수 앱 만들기' 화면이 열릴 것이다.

4.  '프로젝트 세부 정보 항목'에서 '구독'과 '리소스 그룹'을 선택한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167253808-24e3cd99-0dd8-4090-902a-a715a5d58bc0.png)<br>

5. '인스턴트 정보' 항목에서 '함수 앱 이름'을 입력하고 '런타임 스택'에서 사용할 언어를 선택한다. 그리고 언어의 버전과 '지역'을 선택한다.(지역은 가까운곳을 선택하는 것이 좋다)<br><br>![image](https://user-images.githubusercontent.com/39551265/167253844-b6a679df-c594-46b1-be32-f612d05bbef2.png)<br>

6. '운영 체제' 항목에서 사용할 운영체제를 선택(Mac은 만들 수 없다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/167253945-41a2edd6-bdbf-49b0-8803-61e308a517ab.png)<br>

7. '계획' 항목에서는 Azure Function의 용량을 선택 가능한데 'sku 크기'의 <span style="color:red">크기 변경</span>을 클릭해 자신이 제작하려는 API 함수의 성능에 맞게 선택하자(우선 가장 작은 것으로 시작해 부족하면 늘리는 것을 추천)<br><br>![image](https://user-images.githubusercontent.com/39551265/167253985-1d339f16-3e02-4cc9-8df6-e9c9bf484b63.png)<br>

8. 그다음 <span style="color:Red">검토 + 만들기</span> 클릭하고 한번더 <span style="color:Red">만들기</span> 클릭 <br><br>![image](https://user-images.githubusercontent.com/39551265/167254139-b006891f-2e6b-41b2-a570-33ff0aa6242e.png)<br>

10. 이후 잠시 기다리면 리소스가 생성되는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/167254238-c76027f2-4b87-428f-b96e-2aa9484c6e71.png)
<br>
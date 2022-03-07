# SharePoint목록의 행 추가자만 볼 수 있도록 설정
> SharePoint의 목록에서 승인과정을 만들었지만 해당 목록에 들어갔을시 모든 사용자가 모든 데이터를 보게된다. 관리자는 모든 데이터를 볼 필요가 있지만 보통의 사용자들은 자신이 만든것만 보여지게 만들어야 할 것이다. 이제 Sharepoint 목록의 설정을 변경해보자.<br>![image](https://user-images.githubusercontent.com/39551265/156882076-c78db3b6-6ec0-4b97-bf9e-f2c218c23867.png)<br>
현재 어느 계정으로 목록에 들어가면 모든 목록의 데이터가 보일 것이다.


## SharePoint 계정 역할 확인

1. 목록을 생성했던 SharePoint 사이트로 이동한다.

2. 우측 상단의 <span style="color:red">톱니바퀴 -> 사이트 사용 권한</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156882375-44cd1a12-e83c-4313-984e-0323e513344f.png)<br>

3. '사이트 소유자 - 모든 권한'을 클릭하여 확장 후 <span style="color:red">'Sharepoint 사이트 이름' 소유자</span>를 클릭 <br>![image](https://user-images.githubusercontent.com/39551265/156882462-ece20073-a428-45fb-8dde-7a5924111a2b.png)<br>

4. '구성원' 탭으로 가면 계정의 역할을 확인 가능하다.(계정이 소유자라면 역할을 변경도 가능하다)<br>![image](https://user-images.githubusercontent.com/39551265/156882560-7633d66d-f603-4cfb-8ab3-f787ed4a2f6e.png)<br>

## SharePoint 목록 설정 변경

1. Sharepoint에 사이트 소유자 계정으로 로그인한다.(소유자는 SharePoint의 모든 권한을 갖고 있는 관리자 권한이다. 보통 Sharepoint 사이트 제작자는 기본적으로 갖고 있다.)

2. Sharepoint 에서 출장요청 목록 페이지로 들어간다.

3. 우측 상단의 <span style="color:red">톱니바퀴 -> 목록 설정</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156882637-21d1ac94-2c27-40f1-ba0a-49fdfe25e13e.png)<br>

4. 가운데화면에서 '일반 설정' 아래에 <span style="color:red">고급 설정</span>을 클릭<br>![image](https://user-images.githubusercontent.com/39551265/156882959-7ea29d78-85e2-418f-b058-63f68891043f.png)<br>

5. '응답 항목별 사용 권한' 옆의 '읽기 권한' 아래에서 <span style="color:red">사용자가 만든 항목 읽기</span>를 체크한다.<br>![image](https://user-images.githubusercontent.com/39551265/156883138-7a63d7f0-209f-4ebc-b57c-6daf188a5c71.png)<br>

6. 이제 SharePoint에 '사용자 역할'로 접속하면 사용자가 추가한 행만 확인이 가능하게 될 것이다.


## 결론
* 이것으로 목록에서 만든 행 중 사용자가 직접 만든 것만을 보여지게 만들었다. 이제 이 목록을 가지고 다음에는 간단한 PowerApps 캔버스 앱을 만들어보자
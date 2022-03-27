# Power Automate 설정 : 웹 PA를 데스크탑 PA와 연결 1 - 온-프레미스 데이터 게이트웨이 설정
> 온-프레미스 데이터 게이트웨이는 서버나 개인 PC에서 Microsoft 클라우드 서비스 사이에 안전한 데이터 전송을 하는 역할을 한다. Power Platform 서비스를 사용할시에 이 설정을 해야만 사용이 가능한 서비스들이 있다(DB 등). PA 웹(클라우드)에서 PA 데스크탑에 연결시에도 게이트웨이 설정이 되어 있어야 연결이 된다. 참고로 연결을 사용하기 위해선 [유료 계정](https://powerautomate.microsoft.com/ko-kr/pricing/)이 필요하다. 여기서는 연결을 해보자

## 설치

1. [게이트웨이(표준모드) 다운로드](https://go.microsoft.com/fwlink/?LinkId=2116849&clcid=0x409)

2. 경로는 그냥 유지하고 설치를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/159611215-509c04f7-c859-4027-a798-8c214baf2fa4.png)<br>

3. Power Platform 의 환경에 해당되는 조직 계정으로 로그인한다.(조직계정만 가능하다)<br>![image](https://user-images.githubusercontent.com/39551265/159611367-71472c6d-3dd7-4c8b-a171-4cd0734e6627.png)<br>

4. 첫번째 항목에 이름, 두번째 세번째 항목에 복구 키를 입력한다. 그리고 그 아래에서 <span style="color:red">'Change Region'</span>을 반드시 클릭하자(기본 Korea일테지만 Power Platform의 환경지역과 맞춰야한다.)<br>![image](https://user-images.githubusercontent.com/39551265/159612606-fb4d45d6-db93-4f00-95fc-56922bc66af9.png)<br>

5. Power Platform 환경을 확인 후 지역을 반드시 맞추자(현재 Power Platform 환경은 한국이 아직 지원되지 않는다. 아시아 같은걸로 되어 있다면 East Asia 로 설정한다. )<br>![image](https://user-images.githubusercontent.com/39551265/159613473-2430baf9-884d-43e9-bf84-e23a969abba9.png)<br>![image](https://user-images.githubusercontent.com/39551265/159613667-c610d9f4-c21d-4388-ada3-0d713b4eae55.png)

6. 모든 설정이 완료되면 다음과 같은 화면이 될 것이다. 이곳에서 반드시 지역이 제대로 선택되었는지 확인하자<br>![image](https://user-images.githubusercontent.com/39551265/159619320-ec8d05a0-c6e6-46fe-ad27-bd8b65100a4a.png)<br>

7. 성공적으로 게이트웨이가 설정되었다면 Power Autoamte 웹에서 다음과 같이 확인 가능하다. <span style="color:red">데이터 -> 게이트웨이</span><br>![image](https://user-images.githubusercontent.com/39551265/159623038-a8780a18-d1f2-4e61-bd37-e49dd8cdbb05.png)<br>
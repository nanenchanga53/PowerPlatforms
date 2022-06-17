# Dataverse OAuth 통신을 위한 Azure Active Directory 앱 등록
> Dataverse, 모델기반 앱 등의 API를 사용하기 위해서는 인증 설정이 필요하다. 여기서는 Azure Active Directory 의 앱 등록을 이용한 인증 설정을 설명한다.

## 앱 등록 만들기

1. Power Platform [관리센터](https://admin.powerplatform.microsoft.com/) 에서 <span style="color:red">Azure Active Directory</span> 를 클릭해 접속한다. <br><br>![image](https://user-images.githubusercontent.com/39551265/174248733-66214cd1-c73c-4fbc-a24f-0c90ef0c93b2.png)<br>

2. <span style="color:red">앱 등록</span> 메뉴로 들어와 <span style="color:red">+ 새 등록</span>을 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174249798-1ce0c042-0080-4a7a-89e7-b461c46a5ad8.png)<br>

3. '애플리케이션 이름' 항목에서 해당 앱을 등록할 이름을 입력한다.<br>'지원되는 계정 유형' 항목에서 엑세스 가능한 영역을 선택한다.(MS Docs에서는 '모든 조직 디렉토리의 계정'을 권장하고 있다)<br>리디렉션 URI는 Web을 선택 후 적당한 URL을 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174253040-d5e4cc33-b809-472f-98eb-1306301b1388.png)<br>
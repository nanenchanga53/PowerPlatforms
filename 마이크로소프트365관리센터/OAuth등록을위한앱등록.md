# Dataverse OAuth 통신을 위한 Azure Active Directory 앱 등록
> Dataverse, 모델기반 앱 등의 API를 사용하기 위해서는 인증 설정이 필요하다. 여기서는 Azure Active Directory 의 앱 등록을 이용한 인증 설정을 설명한다.

## Azure AD에서 앱 등록 만들기

1. Power Platform [관리센터](https://admin.powerplatform.microsoft.com/) 에서 <span style="color:red">Azure Active Directory</span> 를 클릭해 접속한다. <br><br>![image](https://user-images.githubusercontent.com/39551265/174248733-66214cd1-c73c-4fbc-a24f-0c90ef0c93b2.png)<br>

2. <span style="color:red">앱 등록</span> 메뉴로 들어와 <span style="color:red">+ 새 등록</span>을 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174249798-1ce0c042-0080-4a7a-89e7-b461c46a5ad8.png)<br>

3. '애플리케이션 이름' 항목에서 해당 앱을 등록할 이름을 입력한다.<br>'지원되는 계정 유형' 항목에서 엑세스 가능한 영역을 선택한다.(MS Docs에서는 '모든 조직 디렉토리의 계정'을 권장하고 있다)<br>리디렉션 URI는 Web을 선택 후 적당한 URL을 입력한다. <span style="color:red">등록</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174253040-d5e4cc33-b809-472f-98eb-1306301b1388.png)<br>

4. '매니페스트' 메뉴로 들어와 `allowPublicClient`를 <span style="color:red">ture</span> 로 바꾸고 <span style="color:red">저장</span> 한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174484306-610ef97d-2e03-4020-9696-0c273a82f939.png)<br>

5. 'API 사용 권한' 메뉴로 들어와 <span style="color:Red">+ 권한 추가</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174484418-20178365-3f68-4701-a433-5f320fbce958.png)<br>

6. 'API 사용 권한 요청'에서 <span style="color:red">Dynamics CRM</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174484521-8fe2a809-1028-4458-a2a7-551c91e6f7b2.png)<br>

7. 'API 사용 권한 요청'에서 <span style="color:Red">권한을 체크</span>하고 <span style="color:red">권한 추가</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174484565-f5a295f0-84b0-49e9-a1ee-3cec8577406a.png)<br>

8. '인증서 및 암호' 메뉴로 들어와 <span style="color:red">+ 새 클라이언트 암호</span> 클릭. 그 후 '클라이언트 암호 추가'에서 '설명' 을 입력하고 '만료 시간'을 설정후 <span style="color:red">추가</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174485367-f364c430-9494-454c-9fcc-10c3243d28a3.png)<br>![image](https://user-images.githubusercontent.com/39551265/174485432-a5081a96-0b6d-4e5a-8e3f-ea47b6f56abb.png)<br>

9. 이후 생성한 <span style="color:red">암호의 값</span>을 별도의 위치에 저장해두자 생성 직후에만 복사가 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174485517-452f8b40-e684-420d-9a74-f3fd2581e744.png)<br>

10. '개요' 메뉴료 들어와 <span style="color:red">애플리케이션(클라이언트 ID)</span>를 복사해 둔다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174485598-71b057d0-7d9b-44e8-8296-63e0998caf90.png)<br>


## 환경에 앱 등록

1. [Power Platform 관리센터](https://admin.powerplatform.microsoft.com/environments?geo=Kor)로 돌아와 '환경' 메뉴로 들어온다. 그 후 앱을 등록할 환경을 선택한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174485743-202e7c11-e450-44bd-bad7-cd0ddfaf8b59.png)<br>

2. '엑세스' 항목의 'S25 Apps'의 <span style="color:red">모두 보기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174485966-2ca21f04-c3e6-4654-9a55-7b2bb980f3a6.png)<br>

3. <span style="color:red">+ 새 앱 사용자</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174486073-565d31e7-b32f-4145-98f8-389c35718c03.png)<Br>

4. '새 앱 사용자 만들기' 에서 <span style="color:red">+ 앱 추가</span>를 클릭해 Azure AD에서 추가한 앱 등록을 선택한다.<br>'사업부'에서 관리할 사업부를 선택한다.<br>'보안 역할'의 <span style="color:red">연필 아이콘</span>을 클릭후 보안역할을 선택(만약 모든 권한을 주고 싶다면 '시스템 관리자' 선택)<br><span style="color:red">만들기</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/174486135-a559e842-f823-4a9e-ae6d-39fc75f4d66a.png)<br>

5. 그 후 추가된 것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/174486377-828a9423-3aed-4944-b67c-7dab4b8f3bae.png)<br>


6. [XrmTool Box](https://www.bing.com/search?q=xrmtoolbox&cvid=88d8e67465684fa483c2dd51269fa0d4&aqs=edge..69i57j69i59l4j69i60l3.2704j0j1&pglt=43&FORM=ANNAB1&PC=SMTS) 를 열어 새로운 Connection을 만들어 확인한다. 이때 <span style="color:red">ClinetId/Secret</span>을 사용<br><br>![image](https://user-images.githubusercontent.com/39551265/174486451-911f7dbe-b536-4eda-9f22-25307e0014bc.png)<br>

7. 'Client ID'에서는 이전 복사한 '애플리케이션(클라이언트) ID를 입력<br>'Client Secret'에는 이전 저장한 '암호의 값' 입력<br><br>![image](https://user-images.githubusercontent.com/39551265/174486588-3a769aed-a0d5-4453-99e1-564901e8d72b.png)<br>

8. 이후 연결이 성공한것을 확인하면 제대로 앱이 등록된 것이다.
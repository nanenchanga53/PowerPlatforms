# Azure Devops에서 Power Platform Solution 파이프라인 기초구성
> Power Platform Solution을 Azure DevOps에서 Pipeline을 구성하는 것을 다룬다. 현재 Pipeline구성은 Power Platform에서도 제공하고 있지만 Dataverse 사용량이 낭비되는 문제등이 있다. Power Platform Pipelines를 Azure Devops로 구성해보자.

## Azure DevOps 에 Power Platform Build Tools 설치
> Azure DevOps 마켓플레이스에서 [PowerPlatform Build Tools](https://marketplace.visualstudio.com/items?itemName=microsoft-IsvExpTools.PowerPlatform-BuildTools)를 설치한다.

## Pipeline 1 - Job 구성
> 우선 준비해야할 것은 관리자 계정을 갖춘 Azure Dev Ops 계정, 솔루션의 개발 환경, 배포를 위한 서비스환경이 필수이다. 이곳에서 목표는 레포지토리에 솔루션을 가져오고 배포를 의한 매니지먼트 솔루션으로 만들어 아티팩트에 넣는 작업을 하는 것이다.

1. 솔루션을 관리하고 파이프라인을 구성하기위하여 깃 레포지토리를 생성한다. 필자는 TestPPCICD 라는 레포지토리를 생성하였다. 별도의 설정을 건드리지 않고 생성하면 README 파일만 생성되어있는 레포지토리일 것이다.

![스크린샷 2023-05-30 102449](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/29347d10-1074-4156-b329-9613af325279)

2. 우선 설정에 들어가서 사용할 레포지토리를 선택 후 'Security' 탭에서 파이프라인을 사용할 사용자들의 설정 중 'Contribute'를 'Allow'로 변경한다.

![스크린샷 2023-05-30 112147](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/79085d4c-4630-48f8-b626-abd427a90bb3)

3. Pipelines 항목을 열어 새로운 파이프 라인을 생성한다.

![스크린샷 2023-05-30 104210](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/86de5081-b279-441a-ab99-164cdbed43ba)

4. 클래식 에디터로 전환한다.

![스크린샷 2023-05-30 111656](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2df92547-0f92-45dc-b1b8-4a5f24435a7d)

5. 저장소를 선택

![스크린샷 2023-05-30 111758](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a51ffe08-b77b-4890-9b2c-17550e4e0e6a)

6. 템플릿은 'Empty Job'을 선택하여 Pipeline 구성을 시작한다.

![스크린샷 2023-05-30 111854](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/543c90d3-d1aa-4f81-80ed-25b9ae7569a1)


7. 파이프라인의 이름을 정한 후, 작업(jobs)에서 작업의 이름을 변경하고 'Additional Options'에서 'allow scripts to acess the OAuth token'을 체크한다.(해당 체크를 해야지 깃 등을 사용시 OAuth 인증 등을 가져와서 사용이 가능하다.) 참고로 파이프라인에서 사양(Agent Specification)
은 기본적으로 window 2019일 텐데 아무것으로나 변경해도 상관없다.

![스크린샷 2023-05-30 112001](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9d9a5e8c-23b0-43ba-af8c-210463660d9f)

![스크린샷 2023-05-30 134756](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/c489474e-c6db-45f7-b217-2347c396f0b8)


8. 작업(Jobs)의 오른쪽에 '+' 아이콘을 눌러 task를 추가한다. 추가할 task들은 이미지를 참조한다.

![스크린샷 2023-05-30 145522](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/3f1dfa9b-825b-429f-bf45-f6859c0f50dd)

## Service Connections 설정
> Power Platform Tool 에서 사용하는 인증 방식은 기본적으로 2가지를 사용가능하다. 아이디/패스워드를 사용하는 Generic, Azure AD를 사용하는 Power Platform 2가지이다. 이전 Pipeline 1 과정은 저장해 두고 먼저 설정하자

1. 설정 -> Service Connections -> Create Service Connection 에서 새로운 서비스 연결을 추가할 수 있다.

![스크린샷 2023-05-30 161623](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/476298f3-1137-40b4-abc3-27e6589989b7)

### Generic

1. 'Server URL' 항목에는 `https://{환경 URL}`을 입력한다.

![스크린샷 2023-05-30 163916](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/f9fd1cc7-a19c-43c0-a0ed-509707291c21)

2. 'Username' 항목, Password/Token Key 에는 해당 환경에서 솔루션을 관리할 권한이 있는 아이디/패스워드를 입력한다.

3. 'Service connection name'에는 서비스 연결로 사용할 이름을 입력한다.

4. 'Security'의 체크항목은 체크한다.

![스크린샷 2023-05-30 164115](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/68bea95c-ed6b-4e07-ae8a-0d8f992165c4)


### Power Platform

1. [Dataverse 통신을 위한 Azure AD 앱 등록](https://nanenchanga.tistory.com/entry/Dataverse-%ED%86%B5%EC%8B%A0%EC%9D%84-%EC%9C%84%ED%95%9C-Azure-Active-Directory-%EC%95%B1-%EB%93%B1%EB%A1%9D)을 참고하여 Azure AD에 앱을 등록을 생성한다.

2. 'Server URL' 항목에는 `https://{환경 URL}`을 입력한다.

3. 'Service connection name'에는 서비스 연결로 사용할 이름을 입력한다.

![스크린샷 2023-06-01 091737](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/741bb1e1-9ec9-4c97-919a-0a5db2ddcf80)

4. 'Tenant ID'에는 앱 등록시 사용한 테넌트 ID를 입력한다. 'Application ID'에는 앱 등록시 생성된 앱 ID를 입력한다.

![스크린샷 2023-06-01 091629](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9de80d87-959e-499a-b373-65455ce54292)

5. 'Client secret of Application ID'에는 클라이언트 암호 값을 입력한다.

6. 'Security'의 체크항목은 체크한다.

![스크린샷 2023-06-01 085347](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/3827baf9-8c58-4e41-bdbc-c767c51a1896)



## Pipeline 2 - task 설정

1. Power Platform Tool Installer
    * Power Platform CLI가 설치되어 다른 작업들이 실행 가능하게 된다.

2. Power Platform WhoAmI
    * 설정한 연결을 통해 로그인한 정보를 보여준다. 제대로 로그인이 되는지 확인하기 위하여 사용한다. 필요없다고 판단되면 제거해도 상관없다.
    * 설정한 Service connection 을 선택한다. 설정한 것이 안나타나면 인증방식 라디오 버튼을 바꾸거나(Power Platform Service Connection) 새로고침 아이콘을 눌러본다. 이후 작업에는 인증이 필수로 선택해야한다. 해당 내용은 생략한다.

![스크린샷 2023-06-01 094627](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/57201e1d-f51d-484b-a2ff-630c3050962b)

3. Power Platform Publish Customizations 
    * 연결된 환경(인증 연결)의 항목들의 게시를 실행한다. 만약 게시를 미리 할 필요성이 없다고 생각되면 제거해도 상관없다.

![스크린샷 2023-06-01 111518](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/c07af1fd-018e-4106-9b60-33063ad260fc)

4. Power Platform Set Solution Version
    * 파이프라인에서 사용할 솔루션의 버전을 설정한다.
    * 'TestSolution' 항목에는 솔루션 이름을 입력한다. 이때 입력은 표시이름이 아닌 '이름'이여야 한다. 가능하면은 변수로 등록해서 사용하는게 관리하기 편할 것이다.
    * 'Solution Vsersion Number'항목에는 `1.0.0.$(Build.BuildNumber)`로 입력했는데 '1.0.0.{빌드번호}'가 입력되도록 하였다. 만약 입의로 버전을 입력하는 것으로 바꾸려면 Settable 변수를 활용하는것이 좋다.

![스크린샷 2023-06-01 133353](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/d9602b02-3382-4ce7-91f8-0433f7114e66)
![스크린샷 2023-06-01 132631](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/be697303-1ca2-4d9b-9592-410721d54b30)
![스크린샷 2023-06-01 132746](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/35cc1a25-7870-4c3c-a46d-3f932bfcb794)


5. Power Platform Export Solution (U)
    * Power Platform 환경에서 솔루션을 가져오기 위한 작업이다. 이때 비관리형 솔루션으로 가져오게한다.
    * 비관리형 솔루션인 것을 구분하기 위해 'Display name'에 이름에 '(U)'를 추가한다.
    * 'Solution Name'에 가져올 솔루션의 이름을 입력한다.
    * 'Solution Output File'에는 zip 파일 형식으로 경로와 이름을 입력한다. 아티팩트에 저장하자. 다음과 같은 예제로 입력하는것을 추천한다.<br> `$(Build.ArtifactStagingDirectory)\{솔루션이름}.zip`

![스크린샷 2023-06-01 140026](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/00157413-9c29-4d57-8064-e194140140af)

6. Power Platform Unpack Solution (U)
    * 가져온 솔루션의 압축을 해제한다. 이때 비관리형 솔루션을 사용한다.
    * 비관리형 솔루션인 것을 구분하기 위해 'Display name'에 이름에 '(U)'를 추가한다.
    * 'Solution Input File'에 이전 단계에 사용한 경로와 이름을 입력한다. 복사해서 붙여넣는게 쉬울것이다.
    * 'Target Folder to Unpack Solution'에 압축을 풀 경로를 입력한다. 다음과 같은 예제로 입력하는것을 추천한다. <br>`$(Build.SourcesDirectory)\{솔루션을 담을 폴더명}\{솔루션이름}\Unmanaged`
    * 'Type of Solution'은 'Unmanaged'를 사용한다.
    
![스크린샷 2023-06-01 141916](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/25adb2fb-2cc5-45c8-97ff-e39f7cd4020d)

7. Power Platform Export Solution (M)
    * Power Platform 환경에서 솔루션을 가져오기 위한 작업이다. 이때 관리형 솔루션으로 가져오게한다.
    * 비관리형 솔루션인 것을 구분하기 위해 'Display name'에 이름에 '(M)'를 추가한다.
    * 'Solution Name'에 가져올 솔루션의 이름을 입력한다.
    * 'Solution Output File'에는 zip 파일 형식으로 경로와 이름을 입력한다. 아티팩트에 저장하자. 이때 관리형인것을 구분하기 위해 `_managed`를 추가하는것을 추천한다. 다음과 같은 예제로 입력하는것을 추천한다.<br> `$(Build.ArtifactStagingDirectory)\{솔루션이름}_managed.zip`
    * 'Export as Managed Solution'을 체크한다.

![스크린샷 2023-06-01 143549](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9a2c5164-da76-471d-9b85-999c643b7acd)

8. Power Platform Unpack Solution (U)
    * 가져온 솔루션의 압축을 해제한다. 이때 비관리형 솔루션을 사용한다.
    * 비관리형 솔루션인 것을 구분하기 위해 'Display name'에 이름에 '(U)'를 추가한다.
    * 'Solution Input File'에 이전 단계에 사용한 경로와 이름을 입력한다. 복사해서 붙여넣는게 쉬울것이다.
    * 'Target Folder to Unpack Solution'에 압축을 풀 경로를 입력한다. 다음과 같은 예제로 입력하는것을 추천한다. <br>`$(Build.SourcesDirectory)\{솔루션을 담을 폴더명}\{솔루션이름}\Managed`
    * 'Type of Solution'은 'Managed'를 사용한다.
    
![스크린샷 2023-06-01 143822](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/acae3608-7e36-431e-8421-3858733794b0)

9. Command Line Script
    * 가져온 솔루션을 기준으로 파이프라인에 연결된 저장소에 저장하는 작업을 실행한다. 깃 명령어에 대한것은 [공식문서](https://git-scm.com/book/ko/v2)를 참고

    * 메세지, 이메일 등은 변수로 등록해 사용하는 것을 추천한다.

    * 인증의 경우 `git -c http.extraheader="AUTHORIZATION: bearer $(System.AccessToken)" push origin main` 명령어를 통해 연결된 저장소에 인증후 올릴 수 있다. 파이프 라인에 OAuth 허용체크를 다시한번 확인해보자.

    * 다음과 같은 'Script'를 작성한다.

    ```
    echo commit all changes
    git config user.email "{유저 이메일}"
    git config user.name "{원하는 유저명}"
    git checkout -b main
    git add --all
    git commit -m "(메시지명)"
    echo push code to new repo
    git -c http.extraheader="AUTHORIZATION: bearer $(System.AccessToken)" push origin main
    ```

![스크린샷 2023-06-01 145035](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/768548c3-73be-4ef4-845b-b27390a35294)

![스크린샷 2023-06-01 144049](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ec14bc5c-a4da-4ff6-a9c0-d876a5501d64)

10. Publish Artifact: drop
    * 배포하기위한 아티팩트에 파일을 게시한다. 이전 Export Solution 작업에서 경로를 아티팩트 환경변수 경로를 사용했다면 별도로 지정할 필요가 없다.

![스크린샷 2023-06-01 145532](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9938a04f-6f82-42d0-8ec8-53288ed9ccf1)

### 파이프라인 실행

1. 작성한 파이프라인을 저장&실행을 위하여 'save & queue'를 클릭한다.

![스크린샷 2023-06-01 150039](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/ce87779c-a76b-4fd3-b726-46ce92b4b96f)

2. 'Save comment'에서 파이프라인의 코멘트를 입력하고 Settable 변수를 사용하였다면 같이 변경한다. 이후 'Save and run' 클릭

![스크린샷 2023-06-01 150225](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/e2f6a080-2f3e-422b-875c-4428168036cb)

3. 파이프라인이 실행된다면 파이프라인의 실행 개요화면으로 넘어온다. 현재 실행되고 있는 작업을 보려면 'jobs'의 작업을 클릭한다.

![스크린샷 2023-06-01 150555](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/82a2ae30-a807-4c2c-b6ac-0d9a009464de)
![스크린샷 2023-06-01 152759](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/c84ab21b-0bab-4532-ae04-9abff3b59faa)


4. 파이프라인이 완료되었다면 레포지토리를 확인해서 솔루션의 파일들이 Push 되었는지 확인한다.

![스크린샷 2023-06-01 154910](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/7c892e70-58ce-487c-ac68-96e561b22765)


## 배포(Release) 생성
> Release를 생성하기전 배포할 환경의 Service Connection을 미리 추가한다.

1. Pipelines 의 Release 탭을 열어 'new Pipeline'을 클릭

![스크린샷 2023-06-01 155326](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/53aba2da-7d6c-49c0-853a-18d7ef8d04d2)

2. 들어가서 Stage에서 템플릿을 선택하라고 뜰 것이다. 하지만 Power Platform용 템플릿은 아직 없으니 'Empty job'을 클릭

![스크린샷 2023-06-01 160229](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/0a9ce9db-bfeb-4184-8e01-675dd0662444)

3. Stage의 이름을 변경한다.

![스크린샷 2023-06-01 160422](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/6aaae5ba-bfb5-473e-b27a-3637d510c6f0)

4. Artifacts 에서 빈칸을 클릭해 새로 생성한다. Source의 이전 생성한 Pipeline을 선택하고 추가한다.

![스크린샷 2023-06-01 160600](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/30dc779c-5437-4066-bd18-6861560a335e)

5. Tasks 탭을 열어 Stage의 동작을 변경한다. 작업(Jobs)의 오른쪽에 '+' 아이콘을 눌러 task를 추가한다. 추가할 task들은 이미지를 참조한다.

![스크린샷 2023-06-01 163313](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2fadfb10-21bc-4143-812d-b281c886137e)

## 배포(Release) Stage 설정

1. Power Platform Tool Installer
    * Power Platform CLI가 설치되어 다른 작업들이 실행 가능하게 된다.

![스크린샷 2023-06-01 165249](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b340f52c-13e4-4f53-a960-1b19c192380a)

2. Power Platform import Solution
    * 환경에 솔루션 파일을 이용해 솔루션을 생성,갱신한다.
    * 'Service connection'에서 배포환경의 연결을 선택
    * 'Solution Input File' 의 오른쪽 '...' 아이콘을 클릭해 배포 아티팩트에서 배포할 파일을 선택한다.

![스크린샷 2023-06-01 170238](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a161db70-d92a-4607-922d-2afa18261cf2)


## 베포(Release) 생성

1. 지금까지 설정한 Relase를 저장한다.

2. 이후 Create Relase를 클릭하여 새로운 Relase를 생성한다. 배포 파이프라인 아티팩트 버전을 확인하고 'Create'를 클릭

![스크린샷 2023-06-01 171236](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/1f24d84f-5f83-4c8f-8901-23c3cca198a7)
![스크린샷 2023-06-01 171301](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/6afdd11a-83da-4cfa-b8eb-641e57c2ad88)

3. 이후 Relase 가 생성되면서 확인상세 페이지로 가면 실행되고 있는 혹은 실행이력을 확인 가능하다. 배포가 완료되었으면 배포 대상 환경에서 같은 솔루션이 생성되었는지 확인한다.

![스크린샷 2023-06-01 171728](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/231e37e8-fb48-4529-b361-45c647b20504)

![스크린샷 2023-06-01 171926](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/33224b96-f94e-485b-8bbe-0646edaa4b12)

## 맺음말
> 이로써 Power Platform의 솔루션의 기초적인 파이파라인 구성을 만들었다. 이후 설정값을 별도로 필요한 항목들이나 테스트를 구성하는 방법등은 다음 문서에서 자세히 다루겠다.
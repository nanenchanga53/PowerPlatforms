# PowerPlatform-Pipelines 소개
> 해당 내용은 [공식문서](https://learn.microsoft.com/ko-kr/power-platform/alm/pipelines)에서 있는 내용을 실제로 사용해보며 정리한 내용이다.

## Porwer Platform Pipelines란?

Power Platform Pipelines는 기존 깃허브나 Devops 등에서 설정하려면 번거로운 점이 많았던 것을 간소화해서 사용할 수 있도록 만든 CI/CD 작업이나 현재는 아쉽게도 CI/CD 작업을 전부 충족하고 있지는 못하고 파이프라인으로서 같은 테넌트의 특정 환경에 포함된 솔루션을 다른 환경에 배포기능만 가지고 있다.

|기존 CI/CD 단계    | Power Platform Pipelines |
|------------------|------------------------|
| 파이프라인(Pipelines)   | 지원                   |
| 단계(Stages)        | 지원 - 특정 환경에 배포될 순서를 지정하는 것은 가능하다. 조건등으로 스테이지를 나누거나 관리자의 동의시 실행되는 등의 조건은 불가                   |
| 작업(Jobs)         | 미지원 - 배포밖에 할 수 없다.                 |
| 트리거(Triggers)   | 미지원 - 현재로서는 배포할 특정 솔루션을 직접 실행해야한다.                  |
| 환경(Environments) | 파이프라인을 관리하기 위한 환경을 별도로 만들면 된다.                  |
| 버전 관리(Versioning) | 솔루션을 배포할시 버전의 번호는 변경할 수 있지만 되돌릴 수 없어 크게 의미가 없다.                  |


## 예제 따라 만들어보기
> 다음은 [공식문서](https://learn.microsoft.com/ko-kr/power-platform/alm/set-up-pipelines)에서 있는 내용을 간략화 한 것이다. 상세한 설명은 공식문서를 참조한다.

### 파이프라인 구성

1. 환경을 생성한다. 이때 환경은 파이프라인을 생성할 환경(Host), 개발환경(Development), QA 환경, 서비스 환경(Production)을 포함하는 것을 추천한다. (Host, Development, Production 환경은 반드시 필요하다). - 모든 환경에는 Dataverse가 포함되어야 한다(for Teams는 사용불가) 그리고 Pipeline을 사용하는 환경들은 관리되는 환경으로 설정해야한다. 아쉬운 점으로는 모든 환경이 같은 지역에 포함되어야 한다(미국 -> 한국 다른 지역 파이프라인 생성 불가).

![스크린샷 2023-05-18 151404](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/b5686ac2-d14e-4662-8c2f-2e514b9c067e)
![스크린샷 2023-05-18 152240](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/65648b16-527d-4cdd-9cda-1923fcf0b6c6)

2. 호스트 환경에 파이프라인 애플리케이션을 설치한다.(호스트 환경 한곳에만 설치하면 된다)

![스크린샷 2023-05-18 165156](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/2ed3bfb7-5a70-4f4a-9389-f65061e7c145)


3. 파워 앱스로 이동한다. 호스트 환경에 '배포 파이프라인 구성' 앱을 들어가면 파이프라인 구성 화면으로 이동된다.

![스크린샷 2023-05-18 165630](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/955d65c3-235a-40c8-9783-45725971eb4f)

4.  '환경'에서 '+새로만들기'를 클릭해 사용할 환경들을 등록한다. 이때 각 환경의 ID를 입력해야한다.(이름 등은 마음대로 변경 가능하다), 그리고 '환경 유형' 에서 Development환경만 '개발 환경'으로 선택하고 나머지는 '대상 환경'으로 선택한다.

![스크린샷 2023-05-18 165948](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/862d5873-5fa8-4153-8374-a5ab0960dbb4)
![스크린샷 2023-05-18 170038](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/81bff1c7-8614-4f4f-9cac-fb18c53d7c1f)


5.  '파이프라인'에서 '+새로 만들기'를 클릭해 파이프라인을 구성한다.<br> 
'연결된 개발 환경'에는 기존 배포 환경 추가를 하여 개발 환경을 선택한다.<br>
'배포 스테이지'에서는 '+새 배포 스테이지'를 통해 각 스테이지와 배포되는 환경, 이전 단계가 있다면 선택한다.

![스크린샷 2023-05-19 093541](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/ca295f09-27fc-4a43-84ea-a4313e1b24e1)
![스크린샷 2023-05-19 084747](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/a9075a4d-1216-4ef6-b4b5-dcf46b463815)
![스크린샷 2023-05-19 084855](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/887bd71c-2a17-4213-89ef-68b2dfb82c9d)
![스크린샷 2023-05-19 091701](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/f179c600-a306-4523-899c-4fa2be15cb87)

### 사용자 권한

1. Host 환경에의 설정 -> 사용자 -> 역할관리에서 모든 권한을 갖는 관리자라면 'Deployment Pipeline Administrator' 역할을 할당받는 사용자라면 'Deployment Pipeline User'를 설정한다.

![스크린샷 2023-05-17 144245](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/fd35af03-2f97-4298-8654-980ae991be7f)

2. '파이프 라인'에서 생성한 파이프라인을 선택 후 '공유' 리본 버튼을 통해 사용자를 추가후 권한을 줄 수 있다. (사용하는 사람이 관리자 권한이 있다면 공유가 필요없다)

![스크린샷 2023-05-19 103306](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/701a3bd3-c093-48f2-9ab0-a786338b7bc0)

### 파이프라인 실행

1. 개발 환경(Host 환경이 아니다)에서 솔루션을 만들어 배포할 항목을 포함시킨다.(솔루션은 관리형이 '아니요' 상태야한다)

![스크린샷 2023-05-19 105600](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/49dc6541-7893-4d43-921c-78de6d509e43)

2. 솔루션의 상세 페이지로 들어가 좌측의 파이프라인(로켓아이콘) 항목을 연다.

3. '파이프라인' 이전 생성한 파이프라인을 선택한다.

4. 화면에 단계(Stage) 순서로 좌측부터 개발(현재환경) -> 다음단계(QA 등) -> 서비스(Production) 단계로 각 환경이 표시될 것이다. 각 단계별로 배포를 진행한다.

## 장단점

### 장점

1. 쉽게 만들 수 있다. 전문적인 Devops 지식이 없어도 간편하게 만들 수 있다.

2. Pipelines 생성시 Azure AD가 필요없음 - DevOps라면 비교적 편하지만 GitHub Actions에서 앱등록 등의 인증작업은 꽤나 번거로운 작업이다. 해당 작업이 없는 것 만으로도 간편하게 만들 수 있다.

3. 여러 솔루션을 관리하지 않고 하나의 솔루션에 모든 항목들을 포함한다면 사용하기 편하다.

### 단점

1. CI/CD 의 모든 기능을 사용하지 못한다. 특히 관리자가 이전 버전으로 다시 배포하는 기능이 없는건 큰 단점이다.

2. 솔루션을 각각 배포를 실행시켜야 한다.

3. Dataverse 등의 데이터는 옮기는 기능을 제공하지 않는다. - Dataflow 와 연결을 포함하면 되지만 자동으로 실행시켜주지는 않는다.

4. '연결 참조'를 솔루션에 포함시 배포시에 다시 연결을 설정해야하며(새로운 환경에 연결 참조 정보 그대로 만드는 것이 아니라 새로 생성한다. 만약 연결을 새로 만들시 아이디 등을 잘못 사용하면 사용하지 못할 수 있다.) 배포가 오래걸린다.
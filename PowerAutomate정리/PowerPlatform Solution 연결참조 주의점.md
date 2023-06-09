# PowerPlatform 솔루션, 연결참조 주의점
> Power Automate 등을 솔루션에 포함시키려면 현재로서는 임의의 솔루션에서 생성해야한다.([참고](https://learn.microsoft.com/ko-kr/power-apps/maker/data-platform/solutions-overview#known-limitations)) 이때 솔루션은 연결참조를 생성하고 환경에 존재하는 연결을 가져온다. 이때 Dataverse에 각각의 정보가 저장되므로 Dataverse를 사용하는 환경에서만 사용하자.

## 연결 참조를 사용하지 않는 흐름(Flow)을 연결참조를 사용하여 다시 연결
> 솔루션에 포함시킨 Flow는 기본적으로 연결 참조를 자동으로 생성하여 포함시킨다 하지만 연결참조를 사용하지 않고 만들어버리는 오류가 종종 발생한다. 이때 default로 연결이 되어있는 경우가 있다 이때 연결참조가 사용되었는지 확인하고 변경하는 방법을 알아본다.

1. 사용하고 있는 흐름을 선택하여(해당 흐름은 임의의 솔루션에 포함되어 있어야함다) 우측 상단의 Flow 검사기에 경고표시(붉은점)가 있을것이다. 해당 아이콘을 클릭하여 검사기 상세탭을 확인한다.

![스크린샷 2023-06-05 144346](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/bca2877f-5cd8-40b3-bd27-9184c8dd9a0a)

2. 경고 하위 영역의 연결 참조 사용의 '연결 참조를 추가할 수 있도록 연결 제거' 클릭

![스크린샷 2023-06-05 144450](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/e74efd75-5399-432e-a2fa-e5527172cd2b)

3. 그후 연결되는 대상을 선택할 수 있는데 흐름에 맞는 연결 참조를 선택하면 된다.

![스크린샷 2023-06-05 145343](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/a864b5b8-3e91-4627-97ad-6da0e428b015)


## 같은 연결을 사용한다면 연결참조도 하나로 만드는것을 추천
> 연결참조를 자동으로 만들어주는게 창점만이 있는게 아니다. 같은 연결을 사용해도 참조는 여러개 생성되어 있는 경우가 있는데 이경우 하나만 사용하는게 관리하는데 좋다.

1. 흐름을 선택하여 요약 페이지로 들어가면 우측상단의 연결을 확인 가능하다. 별명이 없고 연결참조로 생성한 연결이 아니라면 편집이 필요하다.

![스크린샷 2023-06-07 171353](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/02c045fa-39b6-4b1b-842a-8ea2bfd81ea3)

2. 흐름 편집에 들어가 선택된 연결을 사용하려는 연결참조로 변경한다.

![스크린샷 2023-06-07 171653](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/d53c44c7-d6d5-4d37-b8d2-c8053859a01e)

3. 솔루션에서 사용하지 않게된 연결참조 특히 관리되는 연결참조들은 제거하자 이때 '관리형'은 '이 솔루션에서 제거'를 하고 사용안하게 된 연결참조는 '이 환경에서 삭제'를 실행한다.

![스크린샷 2023-06-08 090201](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2ea246f9-84d6-48f8-a183-deec549faa1d)

## 새로운 환경에서는 연결참조 세팅
> 새로운 환경에 Power Automate나 Power Apps 등을 처음 집어넣으면 연결이 없는 상태이니 연결 후 활성화를 해야한다.

1. 솔루션의 연결참조를 확인한다.

2. 연결참조를 선택후 기존 연결을 선택하거나, '+ 새 연결'을 클릭하여 커넥터에 따른 새 연결을 생성한다.

![스크린샷 2023-06-08 092147](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/9deb6e76-a779-4ef0-aa39-10f35c47603f)

3. 커넥터를 선택하여 새 연결을 생성한다. 검색시에는 우측상단의 텍스트창에 검색할 문자를 집어넣는다.

![스크린샷 2023-06-08 094937](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/765f9187-54ff-455f-aacd-7d7d89f3ed21)

4. 생성하였다면 다시 솔루션에 돌아와서 '연결'을 새로고침하면 새로 생성한 연결이 존재할 것이다. 해당 연결을 선택한다.

5. 만약 처음 흐름을 옮긴것이라면 활성(전원아이콘)화 한다.

## Canvas App의 데이터 원본을 다른 환경에도 사용하고 싶다면 데이터 원본 환경설정을 만들어 연결
> Power Apps의 데이터 원본을 다른 환경에서도 사용하려면 데이터 원본의 이름의 연결에 대한 바뀌어서 Power Apps에서 데이터 원본을 사용하는 식을 전부 수정해야하는 경우가 있다. 이 상황을 해결하기 위해서는 데이터 원본 환경설정을 사용해야한다. 현재까지는 Dataverse, Sharepoint, SAP ERP 를 지원한다.

1. 솔루션에서 '+신규 -> 자세히 -> 환경변수'를 선택하여 환경변수를 새로 생성한다.

![스크린샷 2023-06-08 102557](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/2c1e671d-ddf8-4eb2-9106-342f6c3e17e5)

2. 만약 Dataverse의 경우 현재 환경에서 사용할 Dataverse의 환경을 선택 가능하고 선택하지 않았을시(배포 등의 작업시) 사용할 환경도 선택할 수 있다.

![스크린샷 2023-06-08 102949](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/c5087d8a-639f-49fe-b926-40e977551147)

3. Power Apps에서 환경변수를 사용시에는 '데이터 원본 -> + 데이터 추가 -> 고급'에서 환경변수를 선택하여 연결을 사용한다.

![스크린샷 2023-06-08 104926](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/973d688b-528c-46ed-b6ed-dbc39e1babad)

## 만약 Power Automate, Power Appss 등을 생성에 솔루션에 기본적으로 포함시키고 싶다면
> 해당 설정은 Dataverse 솔루션에 기본적으로 Power Automate, Power Apps가 포함되게 한다. 현재는 프리뷰이지만 Dataverse를 사용할 환경에서는 기본적으로 설정을 사용하면 솔루션에 들어가 각각을 생성해야만하는 번거로움을 없앨 수 있다.

1. Power Platform 관리센터에 들어간다.

2. 환경의 상세페이지로 들어간다.

3. 설정 -> 기능 페이지로 이동

4. 'Dataverse 솔루션으로 새 캔버스 앱 및 클라우드 흐름 만들기'의 기능을 활성화한다.

![스크린샷 2023-06-07 090931](https://github.com/nanenchanga53/PowerPlatforms/assets/39551265/b3607a54-04a9-4a93-be60-d0666684b631)
# Data Set PCF의 기능 1 - 원활한 통합
> 해당 문서는 해외 PCF 전문 블로그인 [PCF Lady](https://dianabirkelbach.wordpress.com/2020/06/14/features-of-a-dataset-pcf-1/)의 글을 번역한 것이다. 이후로도 명심해둬야할 것이 필요한 내용이 있다면 번역해서 포스팅할 예정이다.

## 데이터 소스의 다양성

우선, DataSet를 사용한 PCF를 사용하려는 이유는 무엇일까? 필드 PCF로도 리퀘스트와 데이터를 표시를 할 수 있는데, 어쨌든 Data Set PCF를 사용하면 어떤 이점이 있을까?

한 가지 이유는 PCF Framework Runtime에서 제공하는 데이터를 얻을 수 있기 때문이다. 이를 통해 (대역외 발사)OOB 구성 요소와 유사한 사용자 지정 환경에 통합할 수 있다. 원하는 엔티티 또는 서브 그리드를 선택할 수 있으며 이전 HTML WebResources에서와 같이 일부 구성 리소스 내에서 일부 fetchXml나 OData를 정의하지 않아도된다.

또 다른 중요한 고려 사항은 PCF 구성 요소를 ModelDriven 앱뿐만 아니라 CanvasApps, Power Pasges(미리보기) 내에서도 사용할 수 있다는 것이다. 따라서 Dataverse에만 국한되지 않는다. 이는 SQL 테이블, Excel 통합 문서, SharePoint List 등과 같은 모든 종류의 데이터 소스에 대한 다양성을 의미한다.

내가 아는 큰 한계는 Data Set를 PCF에서 날짜를 직접 조작 할 수 없다는 것이다. 기본적으로 Data Set는 읽기 전용이기 때문이다. Data Set PCF 내부의 데이터 소스에서 직접 생성하거나 업데이트하는 방법은 없다. 이러한 제약사항에 대한 몇 가지 해결 방법이 있다. 예를 들어 ModelDriven 앱에서 (빠른) 생성 / 편집 양식을 열어 데이터를 입력하거나 변경하거나 제공된 "webAPI"기능을 사용하여 자체 webApi 요청을 구현할 수 있다. 이 기능을 사용하여 매니페스트에서 선언하여 해결 할 수 있다.


## Data Set PCF의 기능

### 커스터마이징
홈 그리드 에 대한 데이터 세트 PCF 를 정의할 수 있으며, 보기(View)와 양식의 subgrid에 대해 정의할 수 있다.

그렇다면 상호작용을 하려면 어떻게 해야할까?

### 로딩
다음은 PCF의 데이터 세트 proprety는 로딩 상태를 불러온다

```
context.parameters.dataset1.loading
```

### 페이징 & 정렬

PCF 컴포넌트의 데이터 세트 특성은 OOB 페이징을 통합하고 페이징 작업을 위한 메소드(loadNextPage, loadPreviousPage, setPageSize) 또는 위치를 알려주는 특성(hasNextPage, hasPreviousPage)을 제공

주의 : 페이징을 위한 UI를 제공하지 않는다. : 페이징을 구현하려면 자체 UI를 구현해야 한다.

페이징 동작의 모델기반앱과 캔버스앱 간의 차이점은 [Scott Durow's Blog](https://develop1.net/public/post/2020/05/07/pcf-dataset-paging-in-mode-vs-canvas-apps) 참조

정렬은 페이징 SDK에 속해있다. context.parameters.<데이터셋>.sorting 을 사용하여 정렬을 정의할 수 있다.

### OOB 옵션 - 퍼스트 파티 리스트와 같은 통합

PCF에 대한 데이터 세트 매개변수를 정의하려면 다음과 같이 매니페스트에서 데이터 세트를 정의해야 한다.

```xml
<data-set name="dataSetGrid" display-name-key="DataSetGridProperty"
   cds-data-set-options="displayCommandBar:true;displayViewSelector:true;displayQuickFindSearch:true">
</data-set>
```

흥미로운 부분은 "cds-data-set-options"속성으로, 플랫폼에서 제공하는 UI 요소 (commandBar , viewSelector 및 searchBox(검색상자))를 지정할 수 있다.<br><br>
![cdsdataoptionsSample](https://dianabirkelbach.files.wordpress.com/2020/06/image-7.png?w=580&h=103)

SubGrid(하위 영역)의 CommandBar, View Selector, SearchBox<br><br>
![subgridsSample](https://dianabirkelbach.files.wordpress.com/2020/06/image-13.png?w=1024)

HomeGrid(상위 영역)의 CommandBar, View Selector, SearchBox

>참고: SubGrid의 경우 매니페스트에서 옵션을 설정만으로는 충분하지 않다. searchBox를 얻으려면 SubGrid 사용자 정의에서도 허용해야한다.

![subgridandselectViews](https://github.com/nanenchanga53/BlazorForPowerPlatformSamples/assets/39551265/7aca81c0-c300-4175-83d3-277977a4015a)
SearchBox가 있는 Sub Grid 사용자 지정 및 보기 선택기를 볼 수 있도록 번경<br><br>

"옵션"의 정의에서 문제가있다. displayQuickFindSearch 옵션은 HomeGrid 및 "관련 보기"에 대해 작동했지만 SubGrid에서는 작동하지 않는다. 이것을 해결하기 위해서는 displayquickfind:true 을 정의해야한다.

```xml
cds-data-set-options ="displayCommandBar:true;displayViewSelector:true;displayquickfind:true"

```

>이 방법으로 구성된 searchBox를 사용한 검색은 서버 측에서 이루어진다는 점을 명심하는 것이 중요하다. -> searchBox의 각 변경은 불러오기를 시작하고 구성 요소에 대한 updateView 메서드를 트리거한다.

### 리본 버튼과 상호작용

PCF SDK를 사용하면 selectedRecordIds 를 설정할 수 있는 가능성을 제공하여 리본버튼과 상호 작용할 수 있다.

```typescript
context.parameters.dataset1.getSelectedRecordIds()
context.parameters.dataset1.setSelectedRecordIds([id])
```
이는 필드 유형 PCF 또는 "이전" HTMLWebResources와 비교하여 dataset pcf의 중요한 측면이다. selectedRecordIds가 설정되면 편집, 삭제, 완료 표시와 같은 리본 단추가 자동으로 표시된다.

![ribongcommand](https://dianabirkelbach.files.wordpress.com/2020/06/image-15.png?w=1024)

>리본으로 원활하게 작업한다는 것은 편집/삭제/setState 기능에 대한 OOB 액세스를 의미할 뿐만 아니라 사용자가 흐름(선택한 레코드와 관련됨)을 호출하거나, 이메일을 보내거나, 내보낼 수 있도록 한다. ❤️ 이것은 HTMLWebResource는 불가능한 기능이다.
# Data Set PCF의 기능 2 - 확장성
> 해당 문서는 해외 PCF 전문 블로그인 [PCF Lady](https://dianabirkelbach.wordpress.com/2020/06/14/features-of-a-dataset-pcf-2/)의 글을 번역한 것이다. 이후로도 명심해둬야할 것이 필요한 내용이 있다면 번역해서 포스팅할 예정이다.

## Dataset <property-set>

데이터 세트 PCF에는 데이터 세트 내에서 속성을 정의할 수 있는 또 다른 기능이 있다. 이 속성은 뷰에 포함할필요가 없으며 프레임워크는 런타임에 이 속성을 추가한다.

아래 예에서 PCF는 옵션 세트 사용자 정의에 정의된 색상에 따라 각 행을 다른 색상으로 렌더링하기 위해 optionset 속성이 필요하다고 가정했을 경우 커스터마이저는 원하는 대로 속성을 선택할 수 있으며 PCF는 이를 구현할 수 있다. javascript 혹은 Nodejs만으로 개발할 경우처럼 하드 코딩된 특성이 필요없게 된다.

이러한 종류의 속성을 정의하려면 매니페스트(ControlManifest.Input.xml 파일)의 <data-set> 노드 내에 <property-set> 노드를 정의한다.

```xml
<data-set name="dataset1" display-name-key="Dataset_Display_Key1" cds-data-set-options="displayCommandBar:true;displayViewSelector:true;displayquickfind:true">
      <property-set name="colorOptionset" display-name-key="Property_Display_Key" description-key="Property_Desc_Key" of-type="OptionSet" usage="bound" required="true" />      
</data-set>
```
PCF 설정에서 속성을 설정할시 아래 이미지와 같은 화면에서 지정한 속성타입의 레코드가 보여질 것이다.

![PCF속성선택이미지](https://dianabirkelbach.files.wordpress.com/2020/06/image-12.png)

>참고: DataSet 내에서 'OptionSet' 매개변수를 정의한다고 해서 View에서 속성을 제공할 필요가 없다. 즉, Framework Runtime에서 DataSet 레코드에 자동으로 추가된다. ❤️

## sdk를 사용한 별도 DataSet와 상호 작용

매니페스트 정의 외에도 코드를 사용하여 데이터와 상호 작용가능하다. 다음 방법들을 활용하여 엑세스할 수 있다.

* filtering – 정의된 View와 검색 결과 필터 위에 코드를 사용하여 더 많은 필터를 추가한다.

* addColumn - DataSet에 컬럼을 추가 한다.

* addColumn

* refresh

아래는 Filtering의 예제다. 아래의 "새로 고침"메서드를 호출해야 적용이 된다.

```typescript
context.parameters.dataset1?.filtering.setFilter({
    filterOperator: 0,  //and
    conditions:[
    {
        attributeName: "subject",
    conditionOperator: 0, //eq
    value: "M1"
    }
    ]
});
context.parameters.dataset1?.refresh();
```

이 Filtering을 하면 네트워크 프로토콜에 다음과 같은 Fetch 조건식을 사용하는 것과 같다.

```xml
<filter type="and">
    <condition attribute="statecode" operator="eq" value="0"/>
    <condition attribute="ownerid" operator="eq-userid"/>
</filter>
 
<filter type="or" isquickfindfields="1">
    <condition attribute="subject" operator="like" value="abc%"/>
</filter>
 
<link-entity name="orb_pcftester" from="orb_pcftesterid" to="regardingobjectid" alias="bb">
    <filter type="and">
        <condition attribute="orb_pcftesterid" operator="eq" uitype="orb_pcftester" value="a1541409-7f68-ea11-a811-000d3a23cb53"/>
    </filter>
</link-entity>
 
<filter type="and">
    <condition attribute="subject" operator="eq" value="M1"/>
</filter>
```

위의 filter 노드들에 대한걸 분석하면 다음과 같다.

* 1-4행은 View 자체에 정의되었다.
* 6-8행은 Search Box에 자동으로 추가되한다("abc"로 시작하는 글자들을 검색).
* 10-14행은 상위 엔티티에 대한 종속성이다(subgrid 이기 때문에).
* 16-18행은 코드를 사용하여 추가한 부분이다.

* View 표시 안함

필드 형식의 PCF와 유사하게, 데이터 세트 PCF에는 구성요소를 사용 안함으로 설정해야 하는지 여부를 알려주는 매개변수도 있다.

```typescript
context.mode.isControlDisabled === true
```

이는 상위 레코드(subgrid가 호스팅되는 위치)가 비활성화되었을 때 발생할 수 있다. PCF 구성요소를 사용하여 구성요소 내에서 직접 변경할 수 있는 경우, 이 표시기를 고려하고 읽기 전용 View로 전환한다. 물론 데이터 세트 내 레코드의 상태 코드도 관련이 있다.

## Dataset과 속성의 조합이 가능한가?

매니페스트에서 'DataSet'와 '속성'을 혼합하여 몇 가지 테스트를 수행한 결과는 다음과 같다.

1. 지원 안함 : <data-set> & <property usage="bound">

흥미로운 점은 harness를 사용하는건 문제가 없다는 것이다. 솔루션을 가져 와서 모델 기반 앱에서 정의 할 수도 있다. PCF 구성 요소에 대한 매개 변수 (DataSet와 Filed 모두)를 사용자 정의 할 수도 있지만 그 후에는 양식 사용자 정의를 저장할 수 없다. 사용하려하면 다음과 같은 오류메시지가 나온다.

> Message: The form XML is invalid. The control ‘Tasks’ is declared as a dataset control, but its manifest XML declares it as a field-level control.

이후 바인딩 된 속성과 혼합 된 데이터 세트를 가질 수 바란다. 그런면 다음과 같은 요구 사항을 구현할 수 있다 : Record가있는 list를 만들고 filed의 합계를 계산. 개인적인 생각으로 처음에는 커뮤니티에서 매우 흥미로운 스레드를 발견했기 때문에 원래는 다루도록 설계되었다는 것이다. https://powerusers.microsoft.com/t5/Power-Apps-Pro-Dev-ISV/Dataset-control-Property-bound-to-form-attribute-is-not/m-p/319152#M567 그러나 현실은 작동하지 않는다.

이러한 종류의 요구 사항 (예 : 합계산)을 충족 시키려면 webAPI 요청을하거나 플러그인을 사용하거나 postMessage 를 사용하여 다른 필드 유형 PCF에 메시지를 보내야한다. [PCF와 통신](https://dianabirkelbach.wordpress.com/2020/05/15/can-pcfs-communicate/)

2. 그레이존 : <data-set> & <property usage="output">

실제로 매개 변수 usage="output" 은 문서화되어 있지 않기 때문에 지원되지 않는다. 설명서에서 사용법은 "bound" 또는 "input"으로 지정된다. 그러나 CanvasApps에서는 매개 변수 usage="output" 과 함께 작동하며 CanvasApp에서 이 조합으로 pcf를 가져올 수 있다.


3. 허용: <data-set> & <property usage=”input”>

이 조합은 모델기반 앱과 캔버스앱에서 작동했다. 입력 매개변수는 필드 유형 PCF와 동일한 사용자 정의 환경(열거형, 정적 값)으로 정확하게 정의하거나 상위 엔티티의 속성에 연결할 수 있다.

입력 매개 변수를 사용하여 시민 개발자가 더 많은 옵션 중에서 선택할 수 있다. 그러나 부모 엔터티의 다른 필드에 연결하는 데에도 사용 가능하다. PCF가 Home Grid(subgrid가 아님)에 대해 정의된 경우 정적 값 또는 Enum만 정의할 수 있습니다.

이것은 정말 좋은 기능이다. 예를 들어, 계정 양식의 subgrid를 고려해보자. sub gird는 계정의 산업 코드에 따라 다른 레코드를 표시해야 한다. 이건 필요한 filter의 종류에 따라 달라진다. 때로는 fetchXml 내에서 조건을 표현할 수 있다. 그러나 때로는 복잡하다. 이때 "입력" 매개변수를 사용하면 산업 코드 값에 따라 다른 필터를 삽입할 수 있다.

그러나 이 필드 매개변수가 변경된 후에는 데이터 세트 PCF가 새로 고쳐지지 않는다. subgird를 새로 고치거나 자동 저장을 기다려야 한다. 데이터가 fetchXml을 사용하여 제공되기 때문에 매개 변수에 대한 변경 사항을 먼저 저장해야한다.


# Power Platform의 Odata 통신 파라메터 정리
> Odata란 Power Platform 등에서 데이터를 통신할시 사용하는 규약이다. 공식 사이트는 https://www.odata.org/ 이며 표준을 정의하고 있다. Dataverse, SharePoint의 자료 등을 검색할시 사용하니 PowerPlatform 개발자로 깊게 파고드려면 기초정도는 기억하고 가자<br>![image](https://user-images.githubusercontent.com/39551265/156702233-c13ee239-9948-48c4-a8ce-b3b5e518450a.png)<br>Power Automate의 Dataverse, SharePoint 등의 검색시 필수로 알아야한다. 여기서는 Json방식으로 통신시 사용하는 파라메터를 간단히 살펴보자

## entityName
> 데이터를 검색하려는 Dataverse 테이블을 가져온다. sharepoint의 경우 목록을 URL에 적기 때문에 사용하지 않는다. SQL의 From이라 생각하자
``` 
    Order 테이블을 검색

    "entityName" : "Order"
```
## $select
> 반환되는 Dataverse 테이블, 혹은 SharePoint 목록등의 열을 선택해 가져온다. ','로 열을 구분하며 왼쪽부터 오른쪽 순서대로 가져오게 된다. SQL의 Select라 생각하자

```
    모든 열을 가져온다.
    "$select" : "*"


    Price 열, Name열을 가져온다
    "$select" : "Price,Name"
``` 

## $filter
> 테이블에서 반환되는 값의 조건을 준다. 연산 식이나 함수를 조합하여 사용한다. SQL의 where라고 생각하자


|식|설명|예제|
|---|---|---|
|eq|같음|"$filter"="Address1_City eq 'Redmond'"|
|ne|다름|"$filter"="Address1_City ne null"|
|gt|초과|"$filter"="Value gt 1000"|
|ge|이상|"$filter"="Value ge 1000"|
|Lt|미만|"$filter"="Value lt 1000"|
|le|이하|""$filter"="Value lt 1000"|
|and|논리연산 AND|"$filter"="Value lt 1000"|
|or|논리연산 OR|"$filter"="Value eq 2 or Value eq 1"|
|not|논리연산 부정|"$filter"="(Value ne null) and not (Value eq 1)"|

|함수|설명|예제|
|---|---|---|
|startswith|시작문자열 포함여부|"$filter"="startswith(Name, 'a')"|
|substringof|문자열이 포함되어있는여부|"$filter"="substringof('store',Name)"|
|endswith|종료문자열 포함여부|"$filter"="endswith(Name, '(sample)'")|
## $orderBy
> 테이블에서 반환되는 행의 순서를 정한다. SQL의 OrderBy 라고 생각하자

```
    Price값을 역순으로 정렬
    "$orderby" : "Price desc"
```

## $top
> 테이블에서 반환되는 행의 개수를 정한다. SQL의 top 혹은 Limit라고 생각하자

```
    결과 값 중 3개의 행을 가져옴
    "$top"="3"
```

## $skip
> 반환되는 행의 N개를 무시한 후 반환한다. SQL의 OFFSET이라고 생각하자
```
    3개의 행을 무시한 후 결과값을 가져옴
    "$skip"="3"
```

## $expand
> 검색 확장조건을 준다. 중첩해서 사용가능하다. SQL의 JOIN이라고 생각하자
```
    Customer테이블의 name 을 포함해 가져옴
    "$expend"="Customer($select=name;)"
```

## Fectch XML
> Fetch XML을 이용해서 조건 검색을 자세히 할 수 있다. XMLTool Box의 FetchXML Builder를 이용하여 만들자

## 참고
[MSDN](https://docs.microsoft.com/en-us/previous-versions/dynamicscrm-2015/developers-guide/gg309461(v=crm.7)?redirectedfrom=MSDN#Anchor_1/?azure-portal=true)
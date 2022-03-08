# FetchXML Builder 사용법
> FetchXML Builder는 Fetch XML을 쉽게 생성하고 Dynamics365의 Dataverse 검색을 할 시 FetchXML 등을 만들고 검색결과를 확인 할 수 있는 Tool이다. XrmToolBox에서 설치가 가능하며 PowerAutomate의 검색 역시 도움 받을 수 있다. 여기서는 사용법을 알아보자

## FetchXML Builder 구성
1.  XrmToolBox를 실행하고 'Tools' 탭으로 이동하고 'FetchXL Builder'를 열자<br>![image](https://user-images.githubusercontent.com/39551265/156991276-ae73a007-99c3-4d91-9b90-bc56be98af66.png)<br>

2. 처음 실행한다면 접속 계정을 선택해야 한다. 만약 모르겠다면 [XrmToolBox 계정연결](https://nanenchanga.tistory.com/23?category=1046660)에서 확인하자

3. 처음 실행한다면 화면에 아무것도 표시되지 않을 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/156999025-532b4aef-d420-4b31-acf9-13ffed7f8eba.png)<br>

4. 상단의 버튼들의 역할은 다음과 같다

    |이름|역할|
    |---|---|
    |New|FetchXML을 실행할 빈 문서를 생성(처음부터 FetchXML을 실행 가능하다면 이 툴을 사용할 이유가 없다)|
    |Open|FetchXML Builder에서 저장파일을 불러오거나, 현재 접속한 계정에서 접속 가능한 테이블,Dynamic 365 List를 Query Bulider로 가져온다.|
    |Save|FetchXML이나 검색 결과 View등을 저장한다.|
    |Undo|방금 실행한 작업을 되돌린다.|
    |Redo|Undo 실행을 취소|
    |Excute(F5)|FetchXML로 만든 검색문 혹은 좌측에 Query Builder에 설정한 것을 토대로 뷰를 불러온다.|
    |View|PowerAutomate, C#, Web API 등 현재 Query Builder에 정의한 것을 다른 방식으로 제작시 사용가능한 현태로 보여준다.|
    |Option|옵션 설정|

5. 좌측의 Query Builder 에서 현재 설정한 쿼리를 보여준다.

6. 좌측의 Quick Actions 에서 쿼리를 설정한다.

## 간단한 사용법

1. 상단의 <span style="color:red">Open -> Open View</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/157149472-4a9f9090-50fe-4390-9793-75baf1091f88.png)<br>

2. Entity 에서 테이블 이름을 선택하고(표시 이름이 아닌 테이블의 진짜 이름)

3. View 에서 테이블의 생성한 보기를 선택한다.

4. 위 두 과정을 거치면 FetchXML구문이 자동으로 생성될 것이다. OK를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/157150035-88f32515-4f01-41f1-a3a6-30bb684eb717.png)<br>

5. 이제 Query Builder에 FetchXML과 동일한 쿼리형태로 생성될 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/157151416-914faa1a-82eb-443e-925f-373772e9a658.png)<br>

6. 상단의 <span style="color:red">Excute(F5)</span> 클릭 하면 현재 선택된 쿼리에 해당되는 데이터를 리스트를 가져온다.<br>![image](https://user-images.githubusercontent.com/39551265/157152183-a8b2a2bf-5b43-4bd2-a152-bd46d619f17a.png)<br>

## 수정이 필요할 시
1. Query Builder 에서 fetch 아래에 있는 <span style="color:red">테이블 이름을 마우스 오른쪽 클릭 -> Add -> 원하는 동작(필자는 filder를 선택)</span>을 추가한다.<br>![image](https://user-images.githubusercontent.com/39551265/157154189-408c64e3-2480-4023-ad80-a66b640cf97a.png)<br>

2. filter가 생성되고 이제 조건을 설정해야한다.<br>![image](https://user-images.githubusercontent.com/39551265/157154875-385975a8-cb66-4426-bff8-41fb950e47bf.png)<br>

3. Attribute에는 열의 이름을 선택(표시이름이 아닌 진짜 이름)

4. Operator는 함수나 식을 선택

5. Value에는 값을 적는다.<br>![image](https://user-images.githubusercontent.com/39551265/157155058-6c8c8eaf-1efd-4df6-b945-3fbab3e3a714.png)<br>

6. 상단의 <span style="color:red">Excute(F5)</span> 클릭하여 조건이 반영되었는지 확인한다.<br>![image](https://user-images.githubusercontent.com/39551265/157155396-78912d12-f06f-465f-b943-3a133bf130eb.png)<br>

## 팁
1. 현재 화면에서 접속계정만 변경하고 싶으면 하단의 'Connected to ~ [접속 위치]' 를 클릭 후 미리 등록해 놓은 계정의 별명의 추가 항목에서 'Connect'를 클릭한다.<br>![image](https://user-images.githubusercontent.com/39551265/156997896-a58a6072-fada-4224-b3bf-15e8070f1e61.png)<br>
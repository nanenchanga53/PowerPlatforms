# Power Apps 작업 : MS SQL Server - SQL 쿼리 실행
> MS SQL 서버와 연결하여 쿼리 명령어를 보내 실행하는 작업에 대해 설명한다. 이때 사용하는 동작은 MS SQL 서버에 있는 동작을 사용한다.

## SQL 쿼리 실행 작업 만들기

1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">SQL Server</span> 아이콘 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/176062378-1b068288-24d0-4716-aef1-6750daeaf30b.png)<br>

3. <span style="color:red">SQL 쿼리 실행</span> 클릭<br><br>![image](https://user-images.githubusercontent.com/39551265/176063299-25d8c1b3-a688-4052-9ea4-c6d78445034c.png)<br>

4. 처음 작업을 만들었다면 우선 커넥터를 설정해야한다. MS SQL 서버에 맞는 인증 방식을 선택한다.<br>Azure AD Integrated : 애저 Active Directory를 이용한 인증 방식을 설정했다면 사용이 가능하다. 해당 인증방식 외에는 서버의 이름과 데이터베이스 이름을 제공해야한다.<br>SQL Server Authentication : 클라우드 MS SQL 서버에 접속시 사용 가능하다.<br>Windows Authentication : 윈도우 인증을 사용하는 온 프라미스 서버에 게이트웨이를 설치시 사용 가능하다<br><br>![image](https://user-images.githubusercontent.com/39551265/176065252-bf533073-1a42-49f2-b027-796825342bc5.png)<br>

5. 여기서는 SQL Server Authentication 을 사용하겠다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176068061-065949d9-6dc4-4cf2-8efa-db7c6302f1b3.png)<br>

6. 새로운 항목이 5개 추가되었을 것이다. 순서대로 SQL Server의 이름(ID), SQL Database 이름, ID, Password를 입력한다. 그 후 GateWay를 사용한다면 Power Platform에 등록한 Gateway를 선택<br><br>![image](https://user-images.githubusercontent.com/39551265/176069124-fdc0d52a-33a1-4584-a2fa-3ea87447f711.png)<br>

7. '서버 이름' 항목에서 커넥터에서 설정한 서버를 선택한다.<br>'데이터 베이스 이름' 항목에서 설정한 데이터베이스를 선택한다.<br>'query' 항목에서 쿼리를 입력한다.<br>'formalParameter'에서 명시적 파라메터를 설정이 가능하다. 키,값 순으로 입력하자<br><br>![image](https://user-images.githubusercontent.com/39551265/176071872-6b8ab97f-52c6-48f2-b953-c964991f5332.png)<br>

## 단계 실행

1. 해당 단계를 포함하는 흐름을 실행해 본다. 결과를 확인했을 시, 결과는 "ResultSets"에 모두 포함되며 배열 형식은 "Tabel1" 등의 형태로 돌아오는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176076644-ea692904-693d-4937-9a92-1d085050c4bf.png)<br>

2. 한번 테스트를 하면 해당 단계의 출력값을 '동적 컨텐츠'로 사용이 가능하다. 만약 배열 형태를 사용하려면 `@{outputs('SQL_쿼리_실행(V2)_2')?['body/resultsets/Table1']}` 를 사용하고 나머지 결과 열값들을 선택해 사용한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/176077552-20dcc01e-00b7-4a97-860a-5d0a803f64bd.png)<br>
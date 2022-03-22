# PowerAutomate 작업 - Dataverse 행 나열 요소 설명
> Dataverse 행 나열은 Dataverse를 다룰시 가장 중요하게 봐야할 요소일 것이다. Dataverse의 테이블에서 조건에 맞는 값을 검색해 가져온다. 원래 엄청나게 복잡했던 API방식을 간단하게 사용하도록 지원해 주는 도구라 생각하면 된다. 사용하기위해선 Power Automate 프리미엄 계정이 필요하다. 이곳에서는 각 항목의 역할과 예시를 알아보자 만약 XrmTool Box의 FetchXML Builder의 사용법을 안다면 각 요소에 어떤값을 넣을지 알기 쉬울것이다. 각 값들은 Dataverse API사용시 Odata형식의 값을 사용하는데 그 안에 집어넣는 값이라 생각하면 된다.

## 테이블 이름
> 현제 환경에서 연결된 Dataverse의 테이블을 선택한다. 선택이 모든 테이블 중에 고르는 형태로 되어 있어서 테이블의 이름은 다른 테이블과 구별할 수 있는 고유의 이름을 사용하는게 좋다. Odata 형식의 entityName 문에 해당된다.

1. 테이블 이름 항목에서 테이블 이름을 적는다.(선택창을 열어서 찾기엔 기본테이블도 많을 것이다)

2. 아래 선택창에서 사용하려는 테이블을 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/155435968-25b8bbb6-7256-43f2-9cbd-05052c956c51.png)<br>

3. 테이블을 선택했으면 일단 저장하고 테스트를 실행해보자 실행 결과를 보면 아래와 같을 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155436273-1ec3f1b2-a56b-459e-9ed6-9a92305f6632.png)<br>

4. 여기서 <span style="color:yellow">입력</span> 항목 옆의 <span style="color:yellow">원시 입력 표시</span>를 클릭해보자

5. 테이블의 데이터를 불러오기위한 통신시 사용한 파라메터를 확인 가능하다.(Body 값), 여기서 보아야 할 것은 테이블의 표시이름을 선택했지만 제대로 엔티티 이름을 파라메터로 보낸것을 확인 가능하다는 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155436790-bd66ba97-dec4-4a32-81b6-5441e0cde4da.png)<br>

6. <span style="color:yellow">출력</span> 항목 아래의 <span style="color:yellow">다운로드하려면 클릭</span>을 클릭해보자

7. 새 웹페이지가 뜨면서 반환 값을 확인 가능하다. 이 반환값을 PowerAutomate 에서 사용 가능하다.

* 테이블은 같은 PowerPlatform 환경에 속해있다면 별도의 준비과정이 필요없이 바로 선택이 가능하다.

## 열 선택
> 테이블 데이터 검색시 가져올 열을 선택한다. 가져올 열은 표시 이름이 아닌 진짜 열의 이름을 가져와야하며 ','로 구분하고 왼쪽부터 오른쪽 순서대로 가져오게된다.(그런데 결과는 Json형식으로 가져오기 때문에 순서가 영향을 주지 않는다.) Odata 형식의 $select 문에 해당된다.

1. 가져올 테이블의 열의 진짜 이름을 적는다. 확인은 Power Apps의 각 테이블에서 확인하자.<br>![image](https://user-images.githubusercontent.com/39551265/158018623-b7c04440-75c3-4a44-81fb-04f417957983.png)<br>

2. ',' 로 구분하여 가져올 행들을 선택<br>![image](https://user-images.githubusercontent.com/39551265/158018816-16466993-8ecb-4a34-ad8f-cbf0247fe211.png)<br>

* XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158018775-d4f0326c-79cd-478a-bbb2-a03439d66c5d.png)<br>

## 행 필터
> Dataverse의 API 통신시 $filter에 해당되는 값이다. 검색의 조건을 정한다.
1. OData 통신의 API 통신 중 $filter에 해당되는 부분의 식과 함수를 통해 검색 기준을 설정한다. 이때 열의 이름은 진짜 이름이여야 한다.<br>![image](https://user-images.githubusercontent.com/39551265/158018933-17a404b4-e77e-4207-ba6b-077daa7e8d3d.png)<br>

* XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158019002-79cd2bc8-e2d0-4f68-b5a5-bf2bdf8f56ff.png)<br>

## 정렬 기준
> Dataverse의 API 통신시 $order에 해당되는 값이다. 정렬조건을 정한다. 

1. OData 통신의 API 통신시 $order에 해당되는 부분의 식과 함수를 통해 정렬 조건을 설정한다. 이때 열의 이름은 진짜 이름이여야 한다.

* XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.

## 쿼리 확장
## XML 쿼리 가져오기
> FetchXML 쿼리문을 사용하여 검색할 수 있다. 이제는 사용하지 않는게 더 좋기에 여기서 사용법을 다루지 않겠다.
## 행 수
> 가져오는 행의 최대개수를 정한다. 기본값은 5000이다.
## 토큰 건너뛰기
> 가져오는 행의 일부분을 스킵 후 가져온다.
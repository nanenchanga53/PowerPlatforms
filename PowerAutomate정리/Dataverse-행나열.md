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

- 테이블은 같은 PowerPlatform 환경에 속해있다면 별도의 준비과정이 필요없이 바로 선택이 가능하다.

## 열 선택
> 테이블 데이터 검색시 가져올 열을 선택한다. 가져올 열은 표시 이름이 아닌 진짜 열의 이름을 가져와야하며 ','로 구분하고 왼쪽부터 오른쪽 순서대로 가져오게된다.(그런데 결과는 Json형식으로 가져오기 때문에 순서가 영향을 주지 않는다.) Odata 형식의 $select 문에 해당된다.

1. 가져올 테이블의 열의 진짜 이름을 적는다. 확인은 Power Apps의 각 테이블에서 확인하자.<br>![image](https://user-images.githubusercontent.com/39551265/158018623-b7c04440-75c3-4a44-81fb-04f417957983.png)<br>

2. ',' 로 구분하여 가져올 행들을 선택<br>![image](https://user-images.githubusercontent.com/39551265/158018816-16466993-8ecb-4a34-ad8f-cbf0247fe211.png)<br>

- XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158018775-d4f0326c-79cd-478a-bbb2-a03439d66c5d.png)<br>

## 행 필터
> Dataverse의 API 통신시 $filter에 해당되는 값이다. 검색의 조건을 정한다.
1. OData 통신의 API 통신 중 $filter에 해당되는 부분의 식과 함수를 통해 검색 기준을 설정한다. 이때 열의 이름은 진짜 이름이여야 한다.<br>![image](https://user-images.githubusercontent.com/39551265/158018933-17a404b4-e77e-4207-ba6b-077daa7e8d3d.png)<br>

- XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158019002-79cd2bc8-e2d0-4f68-b5a5-bf2bdf8f56ff.png)<br>

## 정렬 기준
> Dataverse의 API 통신시 $order에 해당되는 값이다. 정렬조건을 정한다. 

1. OData 통신의 API 통신시 $order에 해당되는 부분의 식과 함수를 통해 정렬 조건을 설정한다. 이때 열의 이름은 진짜 이름이여야 한다.<br>![image](https://user-images.githubusercontent.com/39551265/160241363-a8502787-1511-406c-a85f-5f428eb09625.png)<br>

* XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/160241293-04d712ef-7074-471c-80ae-c3f66c52b79d.png)<br>

## 쿼리 확장
> 현재 테이블에서 조회를 사용하는 열의 조회값들을 가져올 수 있도록 설정한다.

1. 조회 열들을 보면 데이터를 조회하기위한 Link를 반환하지만 데이터를 반환하지 않는걸 실행 결과에서 확인 가능하다.(다음 이미지는 '만든 사람' 열 결과값들)<br>![image](https://user-images.githubusercontent.com/39551265/160285431-d2c71584-dbb5-446f-b6bc-6637191fba9f.png)<br>

2. 조회된 데이터에서 데이터를 반환하도록 만들기 위해 '쿼리확장' 열에 해당 열의 원래 이름을 입력하고 조회열을 추가한다. 다음 이미지와 같은 경우는 '만든 사람' 열에서 조회된 테이블의 열에서 'fullname'을 가져온다.<br>![image](https://user-images.githubusercontent.com/39551265/160285078-3fd627c1-5012-471a-b995-c0a9ba52ec08.png)<br>

3. 다음과 같이 결과에서 '쿼리 확장'에서 정의한 값이 추가로 반환된 것을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/160285584-0cfd9f88-296c-4a72-8176-70e3c6c49af6.png)<br>

## XML 쿼리 가져오기
> 기존 D365 검색 방식인 Fetch XML을 사용하여 검색이 가능하다 사용시 다른 항목은 사용하지 말고(테이블 이름 제외) 해당 항목만을 사용하자.

1. 'XML 쿼리 가져오기' 항목에 해당 테이블에 해당되는 Fetch XML 문을 사용한다.<br>![image](https://user-images.githubusercontent.com/39551265/160275226-93cc0c42-bb49-4d1a-9d3c-90b886f4a99e.png)<br>

## 행 수
> Dataverse의 API 통신시 $top에 해당되는 값이다. 가져오는 행의 최대개수를 정한다. 기본값은 5000이다.

1. 가져올 테이블의 행의 개수를 적는다. 적지 않으면 5000개까지 가져온다.<br>![image](https://user-images.githubusercontent.com/39551265/160242083-ecce6031-c04e-4ae2-94b7-d8bd166de734.png)<br>

2. 한번에 가져오는 최대량을 늘리기 위해선 <span style="color:red">... -< 설정</span> 에서 이때 '페이지 매김' 항목을 '켜기'로 변경한다. 그 후 '임계값' 항목에서 숫자를 변경한다. 100000 까지 설정이 가능하다 즉 100000 보다 큰 숫자는 한번에 가져오지 못한다. 만약 100000개 보다 더 많은 행을 가져오려면 '토큰 건너뛰기'와 조합하여 따로 흐름을 실행해야한다. <br>![image](https://user-images.githubusercontent.com/39551265/160243142-61f38596-cec3-4d19-b2f3-002bb5241d19.png)<br>

- XrmToolBox의 Fetch XML Builder 를 사용한다면 다음과 비슷할 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/160275255-b4760009-1efd-437f-8c62-0e1e1ca77aa6.png)<br>

## 토큰 건너뛰기
> 페이지 매김 설정을 하지 않고 한번에 검색을 사용시 5000개 보다 더 많은 행을 검색했지만 가져오지 못했을시 해당 '행 나열' 작업에서 '다음 링크'로 반환한다.

1.  <span style="color:red">... -> 설정</span> 에서  이때 '페이지 매김' 항목을 끄기로 설정한다.<br>![image](https://user-images.githubusercontent.com/39551265/160280283-9a559f83-7489-4c34-952c-27698c84bd63.png)<br>

2. 이후 작업에서 '다음 링크' 동적 콘텐츠를 저장하고 쿠키값을 선택하여 사용하면 된다.(더 자세한 내용은 별도 문서에서 설명하겠다.)<br>![image](https://user-images.githubusercontent.com/39551265/160281986-730f8a67-ca55-4196-bc59-cfec9f4abc8d.png)<br>


## 파디션 ID
> NoSQL 테이블에(cosmoDB) 대한 데이터를 검색하는 동안 partitionId를 지정하는 옵션. 현재 cosmoDB의 가격이 비싸서 한동한 설명할 기회는 없을 것으로 보인다. [공식문서](https://docs.microsoft.com/ko-kr/powerapps/developer/data-platform/org-service/azure-storage-partitioning-sdk)를 참조하자

# PowerAutomate 작업 : 행 나열-Dataverse 간단한 검색
> PowerAutomate에서 Dataverse의 행을 검색하고 불러올 수 있는데(API방식) Filter 테이블을 전부 사용할 일은 없기 때문에 필터로 조건에 맞는 것을 추려야 한다. 그런데 아직 필터링에 대해 편한 UI를 업데이트를 하지 못했는지 OData 쿼리를 사용해야 한다. 간단한 검색문을 사용해 보자.

## OData란?
> Open Data Protocol의 약자로, 데이터를 주고 받는 공통규약이다.<br>
공식 사이트는 www.odata.org 이며 이곳에서 표준을 정의하고 있다.<br>
간단하게, 요청 URL을 이용한 쿼리문 표준이다.

## PowerAutomate Dataverse 행 나열에서 필터 적용 전 기본 설정
1. 처음 행 나열을 만들고 테이블을 선택하면 아래와 같을 것이다. 이 상태에서 불러오기를 하면 모든 데이터를 불러와 사용하기는 어려울 것이다.(행 수 기본값 5000으로 5000개를 불러옴)<br>![image](https://user-images.githubusercontent.com/39551265/155049363-32dd008f-6623-4e10-b704-27115433f65d.png)<br>

2. <span style="color:yellow">열 선택</span>에서 필요한 열을 데이터 테이블 이름을 입력해 쉽표(,)로 구분하여 선택<br><img src="https://user-images.githubusercontent.com/39551265/155049802-4c7a33cb-8829-460b-ab94-7e6189c6ad3d.png" width="50%"><br>


3. <span style="color:yellow">행 수</span> 에서 가져올 행의 개수 숫자로 입력 (기본 5000)

4. 테이블만 선택해서 가져왔을 경우 결과는 아래 이미지와 같을 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155052172-85d39157-1819-4e95-8bed-b9d5c1279654.png)<br>

5. **출력** 에서 **다운로드하려면 클릭**을 클릭하면 반환값이 보일 것이다. Json형태로 반환됬으며 요청자 실행 결과 등의 정보를 포함한다는 것을 확인 할 수 있다.

6. 일단 저장하고 테스트를 실행해보자

7. 그다음 행 나열 아래에 <span style="color:yellow">변수 초기화</span>를 생성하고 바로 다음 단계에 <span style="color:yellow">변수 설정</span>을 만들어 보자

8. <span style="color:yellow">변수 초기화</span>에서 만든 변수를 <span style="color:yellow">변수 설정</span>에서 이름으로 선택한다.

9. <span style="color:yellow">행 설정</span>의 **값** 항목을 선택하면 동적 컨텐츠에 행 나열에서 생성한 행을 선택할 수 있다.(한번 테스트를 돌려야 생성)

10. 값을 선택하면 행 나열에서 선택된 모든 값을 각각 사용 가능하게 된다.<br>![image](https://user-images.githubusercontent.com/39551265/155052997-387a56dc-e454-414d-98bc-25991e69b646.png)<br>

## OData 형식으로 필터링

1. <span>행 필터</span> 에서 행을 필터링 할 수 있다.

2. 필터링은 OData형식을 사용해야하며 자세히는 [공식문서](https://docs.microsoft.com/ko-kr/powerapps/developer/data-platform/webapi/query-data-web-api#standard-filter-operators)에서 확인하자

3. 열 이름 'cr795_ccmpy_breg_no' 에서 '10000004' 인 행을 검색해야한다 치면 아래와 같다. 이후에는 각 형식별로 나열하겠다.
```OData
cr795_ccmpy_breg_no eq '10000004'
```

### 문자 : 아래의 경우는 '열이름' 열에 '찾는문자'와 같은 것
```
열이름 eq '찾는문자'
```
![image](https://user-images.githubusercontent.com/39551265/155060878-87fc213d-de41-4596-8b33-405c166b9c9d.png)

### 숫자 : 아래의 경우는 '열이름' 열에 '숫자'이상
```
열이름 ge 숫자
```
![image](https://user-images.githubusercontent.com/39551265/155061183-1cab04e6-9609-49c2-a5e7-798636700189.png)

### 예/아니요 형식(bool) : 똑같이 eq를 사용하지만 true,false값은 그냥 써도 되지만 가능하면 동적 콘텐츠로 추가해야한다.
```
열이름 eq true
```
![image](https://user-images.githubusercontent.com/39551265/155070134-4bc7c2a5-f361-48ca-b084-dd1ff246079e.png)

### 선택지 : 선택지의 코드번호를 사용한다. 번호는 테이블에서 확인하자
```
열이름 eq 숫자
```
![image](https://user-images.githubusercontent.com/39551265/155072889-b30a30c5-950f-44bf-872c-d010cfb8053b.png)

### 참조형 : 이건 검색후 검색결과값으로 사용하자
```
관계형열이름 eq '찾는 관계형 열의 GUID'
```
![image](https://user-images.githubusercontent.com/39551265/155073285-afd5e4b1-ee98-4260-8a24-b19846231778.png)

## 결론
> 이로써 PowerAutomate에서 Dataverse의 검색이 가능해 졌다. 이것을 이용하면 CRM에 직접 접속하기 위한 코드를 짤 필요가 없을 것이다. 원래는 API사용시 보안 설정 등 여러가지가 필요했던 쟉업을 줄일 수 있다.


참조 블로그 https://tech-blog.cloud-config.jp/2021-12-17-power-automate-dataverse-filter-query/
공식문서 https://docs.microsoft.com/ko-kr/powerapps/developer/data-platform/webapi/query-data-web-api#standard-filter-operators
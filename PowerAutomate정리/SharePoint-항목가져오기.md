# 파워 오토메이트 작업 - SharePoint-항목 가져오기
> SharePoint-항목 가져오기는 SharePoint에 있는 목록에서 테이블 데이터를 검색해 가져오는 역할을 한다. [공식문서](https://docs.microsoft.com/ko-kr/connectors/sharepointonline/#get-items)에서는 번역이 안되어 있는데 <span style="color:yellow">Get Items</span>이다  <span style="color:yellow"></span>

## SharePoint 항목 단계 만들기

1. <span style="color:yellow">**+새 단계**</span> 혹은 원하는 위치에서 <span style="color:yellow">**새 단계 삽입 아이콘 -> 작업 추가**</span>

2.  SharePoint를 검색해 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/155284540-df10a539-ee39-4bed-804c-5dd0b961a221.png)<br>

3. 동작 탭에서 <span style="color:yellow">항목 가져오기(2개 이상)</span>을 선택<br><br>

4. 아래이미지와 같도록 새 항목이 생겼을 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155437912-f5092db6-6fa8-46c4-a2bb-891be0a3bc23.png)<br>

5. 현재 항목의 목적에 맞게 이름을 변경한다.(필자는 아래 이미지와 같이 바꿨다.)<br>![image](https://user-images.githubusercontent.com/39551265/155438454-27b9c19e-58cc-4140-8673-2ebd8050ff7e.png)<br>

## 사이트 주소
> 현재 연결된 환경에 연결할 수 있는 쉐어포인트를 선택할 수 있는 항목이다.(계정이 아니다) 필수적으로 선택해야만 한다.

1. <span style="color:yellow">사이트 주소</span> 항목을 선택하면 아래의 여러 선택창이 뜰 것이다. 여기서 연결할 쉐어포인트를 선택한다.

## 목록 이름
> 연결한 쉐어포인트에 있는 목록을 선택한다.

1. <span style="color:yellow">목록 이름</span> 항목을 선택하면 아래의 여러 선택창이 뜰 것이다. 여기서 사용할 목록의 이름을 선택한다.

## 항목을 폴더로 제한
> 목록은 폴더별로 들어갈 데이터를 나눌 수 있다. 이후 SharePoint에서 폴더 만들기 설명을 추가하면 이 항목을 갱신하겠다.

## 중첩된 항목 포함
> 항목을 폴더로 제한을 선택하면 폴더의 하위 폴더에 있는 항목까지 가져올지 여부를 판단한다. 이후 SharePoint에서 폴더 만들기 설명을 추가하면 이 항목을 갱신하겠다.

## 실행 결과 보기
> 모든 항목을 가져온다면 여기까지만 설정하면 된다. 일단 실행결과를 보는 방법을 설명하겠다.

1. 저장 -> 테스트 를 눌러 테스트를 실행한다.

2. 결과 창으로 이동한다.

3. 실행에 문제가 없으면 아래 이미지와 같이 나올 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155456737-8132080d-d802-4bc5-a05b-5f452739b867.png)<br>

4. 입력 항목 옆의 <span style="color:yellow">원시 입력 표시<span> 클릭

5. 오른쪽에 OData형식으로 목록의 데이터를 요청할시 어떤 파라메터를 포함했는지 확인 할 수 있다.<br>![image](https://user-images.githubusercontent.com/39551265/155457018-f4f82e80-edee-485c-b3a0-4057852c7191.png)<br>

6. 출력 항목 아래쪽 본문을 확인하자

7. value 키 값 안에 목록의 데이터를 확인 가능할 것이다.

8. 열 이름이 쭉이어지지 않고 OData.~ 이런식으로 키 값이 정해진 것이 있을 것이다.

9. 쉐어포인트도 DB의 테이블 형식으로 저장하고 있는데 한글이름을 열 이름으로 지정할 수 없어서 SharePoint에서 인코딩 하여 영어와 숫자만 사용하도록 변경해 놓은 것이다.(영어로 열 이름을 지정했을시 없을 경우가 있다.)<br>![image](https://user-images.githubusercontent.com/39551265/155457607-a31b229a-b26f-4f66-ae1e-d3add738281b.png)<br>![image](https://user-images.githubusercontent.com/39551265/155458562-231d57e0-dca5-4b3c-b0f8-2cd916aec7a7.png)<br>

10. 우선 각 데이터와 sharepoint의 목록을 비교하면서 열 이름이 어떻게 등록되어있는지 기억해 두어야 이후의 고급옵션에서 조건을 사용 가능하다.

## 고급옵션 표시
> 이전 항목만을 선택하면 조건없이 모든 항목을 가져오게 된다. 하지만 검색을 하면 보통 특정 조건을 걸어서 가져오는 경우가 많을 것이다. 이때 고급옵션에서 설정해야한다. 고급옵션에서는 <span style="color:yellow">필터쿼리</span>, <span style="color:yellow">정렬 기준</span>, <span style="color:yellow">최대 개수</span>, <span style="color:yellow"></span><span style="color:yellow">보기별로 열 제한</span>이 있다.

1. <span style="color:yellow">고급옵션 표시</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/155442913-fbaa96f9-c45b-4fbb-8e7d-a1ebfad7d23a.png)<br>

2. 새로운 항목 4개가 보일 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/155459244-72a5efae-2b38-4317-9efe-e1ef110ffe79.png)<br>


## 필터 쿼리
> 필터 쿼리는 목록의 검색조건을 설정한다. OData 형식의 통신 방식을 사용할시 $filter 에 들어갈 쿼리를 사용한다.

1. 필터에 Odata형식의 $filter에 해당되는 구문을 사용한다. 이떄 항목 이름이 영어가 아니면 한번 '실행결과 보기' 에서 설명한대로 확인후 적어야 한다.

2. 아래는 출장비용이 1000을 넘는 숫자를 검색하는 구문이다.
```
OData__xcd9c__xc7a5__xbe44__xc6a9_ gt '1000'
```

## 정렬 기준
> 정렬 기준은 받아온 값의 정렬기준을 정한다. OData형식의 통신방식을 사용할시 $orderby 에 들어갈 쿼리를 사용한다.

1. 정렬 기준에 Odata형식의 $orderby 에 들어갈 쿼리를 사용한다. 이때 항목 이름이 영어가 아니면 한번 '실행결과 보기'에서 설명한대로 확인 후 적어야 한다.

2. 아래는 출장비용 기준으로 정렬하는 구문이다.
```
OData__xcd9c__xc7a5__xbe44__xc6a9_ desc
```

## 최대 개수
> 목록의 행 개수 제한을 설정한다. 기본값은 5000이다.

1. 최대 개수에 받아올 값의 최대 개수를 숫자로 적는다.


## 보기별로 열 제한
> 열의 보기를 여러개 사용시 어떤 보기에서 열 데이터를 가져올지 선택할 수 있다.(테이블의 뷰에 해당) 이후 SharePoint에서 보기 만들기 설명을 추가하면 이 항목을 갱신하겠다.
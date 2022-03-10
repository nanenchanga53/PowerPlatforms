# PowerAutomate 작업 : Dataverse 행 삭제
> 파워오토메이트에서 Dataverse 테이블의 데이터 행을 삭제하는 작업이다. 작업을 실행하려면 행의 GUID를 알 필요가 있다. 보통 행의 GUID를 검색하는 작업 이후에 사용된다.

## Dataverse 행 삭제 작업생성
1. <span style="color:red">**+새 단계**</span> 혹은 원하는 위치에서 <span style="color:red">**새 단계 삽입 아이콘 -> 작업 추가**</span>

2. Dataverse를 검색하고 <span style="color:red">Microsoft Dataverse</span>를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/157387547-ff0d09c5-eb5d-4b67-9a6e-9ad3fc34dcc6.png)<br>

3. 동작 리스트 중에서 <span style="color:red">행 삭제</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/157387807-2bd43742-5d45-4451-8b09-7c7efe484d3b.png)<br>

## Dataverse 행 삭제
1. '테이블 이름' 항목에서 작업을 실행하려는 테이블을 선택

2. '행 ID'에서 GUID 값을 적는다.(GUID값은 행 검색을 실행후의 반환값을 사용하는 것이 좋다)<br>![image](https://user-images.githubusercontent.com/39551265/157388754-64720413-e501-4860-9874-6c1e276d18b4.png)<br>

## 실행 결과

1. 실행 기록에서 실행을 확인하면 해당 작업에서 결과,입력값과 출력값을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/157389343-51cdf4e4-f2e5-4e36-a3fa-091105ae7ddb.png)<br>

2. <span style="color:red">원시 입력 표시</span>에서 API 통신의 입력값을 확인 가능

2. <span style="color:red">다운로드 하려면 클릭</span>에서 API 통신의 반환값을 확인 가능
# PowerAutomate 작업 : dataverse - 새 행 추가
> 파워오토메이트에서 Dataverse 테이블의 데이터 행을 추가하는 작업이다.

## Dataverse 행 삭제 작업생성
1. <span style="color:red">**+새 단계**</span> 혹은 원하는 위치에서 <span style="color:red">**새 단계 삽입 아이콘 -> 작업 추가**</span>

2. Dataverse를 검색하고 <span style="color:red">Microsoft Dataverse</span>를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/157387547-ff0d09c5-eb5d-4b67-9a6e-9ad3fc34dcc6.png)<br>

3. 동작 리스트 중에서 <span style="color:red">행 추가</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/159387823-c334bc58-7562-4a84-a120-69074784521e.png)<br>

## Dataverse 행 삭제
1. '테이블 이름' 항목에서 작업을 실행하려는 테이블을 선택<br>![image](https://user-images.githubusercontent.com/39551265/159388229-e4779fee-db60-4ab0-9c8e-a6415b776c57.png)<br> 

2. '고급 옵션 표시'클릭<br>![image](https://user-images.githubusercontent.com/39551265/159388401-9019062e-ece9-4f41-928c-73dedc7467ca.png)<br>

3. 이후 테이블의 열의 종류 만큼의 입력 항목이 추가될 것이다. 각 항목에 업데이트 하려는 데이터를 입력하면 된다.(테이블의 필수 입력 항목은 반드시 입력하자)<br>![image](https://user-images.githubusercontent.com/39551265/159388497-df707e0c-dfc0-4b54-833c-430d2546efb8.png)<br>

## 실행 결과

1. 실행 기록에서 실행을 확인하면 해당 작업에서 결과,입력값과 출력값을 확인 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/159388781-3e50e4e5-3ae5-4679-b6ce-57036a6f0361.png)<br>

2. <span style="color:red">원시 입력 표시</span>에서 API 통신의 입력값을 확인 가능

3. 출력 항목에서 추가한 항목의 반환 Value 값을 확인 가능

4. <span style="color:red">원시 출력 표시</span>에서 API 통신의 모든 반환값을 확인 가능
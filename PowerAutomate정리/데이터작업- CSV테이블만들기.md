# PowerAutomate 작업 : 데이터작업-CSV테이블 만들기
> 별도 데이터에서 CSV테이블을 만드는 Power Automate 단계. 보통 배열 형태의 JSON 형태의 데이터(PowerAutoamte의 배열변수)를 이용해 자동으로 만들거나 원하는 CSV목록을 이용해 만들 수 있다.


## CSV테이블 만들기 생성

1. 원하는 위치에 <span style="color:red">**새 단계(+ 아이콘) -> 작업 추가**</span><br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">**데이터 작업**</span> 선택<br>![image](https://user-images.githubusercontent.com/39551265/155927066-c1205ee5-07ca-441b-a547-c0c1053d8d6d.png)<br>

3. <span style="color:red">**CSV 테이블 만들기**</span> 선택<br><br>![image](https://user-images.githubusercontent.com/39551265/163901080-59a8edbb-0427-4425-a9ea-ae725432911f.png)<br>


## CSV테이블 JSON(배열 변수)을 이용해 자동 생성

1. <span style="color:red">'고급 옵션 보기'</span>을 클릭해 확대하자

2. '열' 항목이 '자동'으로 되어 있는것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163902264-54060957-2793-4796-a0a3-cdff0d35710d.png)<br>

3. '보낸 사람(데이터 원본)'에는 'JSON 배열' 혹은 '배열변수'에 동적값을 입력(SQL로 치면 테이블 형태의 데이터 형식이여야 한다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/163902101-0bca37ef-6825-4d2d-a3fd-61906049be6f.png)<br>


4. 이후 실행해보면 'Jsonn 배열'값에 따른 Key값을 기준으로 CSV형태의 데이터가 생성되는 것을 확인 가능할 것이다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163903785-95f9882e-253b-437a-aa89-c7e47ff7fe7c.png)<br>


## CSV테이블 JSON(배열 변수)을 이용해 열의 이름을 변경해 생성


1. <span style="color:red">'고급 옵션 보기'</span>을 클릭해 확대하자

2. '열' 항목이 '사용자 지정'으로 되어 있는것을 확인한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163903993-a7eb577e-888f-403b-a1dd-fbda88c0fb44.png)<br>

3. '보낸 사람(데이터 원본)'에는 'JSON 배열' 혹은 '배열변수'에 동적값을 입력(SQL로 치면 테이블 형태의 데이터 형식이여야 한다.)<br><br>![image](https://user-images.githubusercontent.com/39551265/163902101-0bca37ef-6825-4d2d-a3fd-61906049be6f.png)<br>

4. '머리글' 에는 CSV최상단 행에 쓰일 이름을 입력한다. 값에는 '보낸 사람(데이터 원본)'에 등록한 동적값의 항목중 하나를 선택한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163904126-7e0421cc-fde5-4474-ba25-aecb6e06b6d3.png)<br>


5. 이후 실행해보면 'Jsonn 배열'값에 따른 Key값을 기준으로 CSV형태의 데이터가 생성되는 것을 확인 가능할 것이다.<br><br>![image](https://user-images.githubusercontent.com/39551265/163905284-670d5f64-48ad-432f-aecb-ae6e56f06303.png)<br>


## 생성한 CSV 데이터를 다운로드

1. 다음 단계에서 저장할 위치에 콘텐츠를 만들어 저장하는 단계를 만든다.(필자는 OneDrive의 '파일 만들기'를 선택)<br><br>![image](https://user-images.githubusercontent.com/39551265/162677087-65484be0-1d81-4d75-8f60-34a135eb2e68.png)<br>

2. '폴더 경로'를 선택 하고 '파일 이름'을 `{파일이름}.csv` 형식으로 지정한다.

3. '파일 콘텐츠' 항목에 <span style="color:red">Fx</span> 버튼을 눌러 식을 추가한다.<br>식은 다음과 비슷하게 만든다.<br>concat을 추가하여 문자열을 csv테이블에 BOM을 추가하도록 만든다.<br>uriComponentToString을 이용해 UTF-8 형식의 문자열 타입을 지정하는 BOM을 추가한다. concat의 첫번째 항목은 다음과 같이 만든다. `uriComponentToString('%EF%BB%BF')`<br>두번째 항목은 해당 위치에서 '동적값/동적 컨텐츠'에서 선택하면 추가된다. `body('CSV_테이블_만들기')` 와 비슷하게 추가될 것이다.<br>완성된 식은 다음과 같다. `concat(uriComponentToString('%EF%BB%BF'),body('CSV_테이블_만들기'))` <br><br>![image](https://user-images.githubusercontent.com/39551265/162678297-e1c8bc70-d7ff-49e8-8519-d57d3ff3cbcf.png)<br>

* BOM 이란
> BOM 이란 문서의 맨 앞부분에 눈에 보이지 않는 특정 바이트(Byte)를 넣은 다음 해당 문서의 인코딩 방식이 어떠한 인코딩 방식으로 사용되었는지 알아내는 방법을 나타낸다. 이것을 설정하지 않으면 Power Automate에서 파일을 저장시 UTF-8로 저장하는데 엑셀 등에서 파일을 실행할때 한글이 깨지면서 나올 것이다.
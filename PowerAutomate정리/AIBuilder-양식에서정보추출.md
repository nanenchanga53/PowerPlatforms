# Power Autoamte 작업 : AI Builder - 양식에서 정보 추출
> AI Builder의 양식에서 정보 추출 모델을 이용해 이미지나 PDF에서 텍스트를 인식해보자. 양식에서 정보 추출을 사용하기 위에서는 Power Apps에서 AI Builder에서 양식 인식 모델을 만들어놓아야한다.

## 문서 PDF 파일 가져오기

1. 우선 Share Point 등에서 PDF의 콘텐츠를 불러온다.<br>![image](https://user-images.githubusercontent.com/39551265/158717542-844159a0-f543-4d61-9dcb-87fb134e1e99.png)<br>


## 양식에서 정보 추출 작업 만들기

1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. <span style="color:red">AI Builder</span> 아이콘 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158016397-44a03eec-868d-41e7-beb9-15e4bf9d407b.png)<br>

3. <span style="color:red">양식에서 정보 추출</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158717989-23684b7c-e0be-4b7e-b8b4-e8a1ee18eeed.png)<br>

4. 'AI 모델' 항목에서 미리 만들어 놓은 AI Builder 모델을 선택

5. '양식 유형' 항목에서 문서의 유형을 선택

6. '양식'에는 이전 단계에서 가져온 PDF파일의 콘텐츠를 동적 콘텐츠 삽입<br>![image](https://user-images.githubusercontent.com/39551265/158718886-83a549c4-dced-4a12-b5f3-c2f55d059fad.png)<br>


## 실행 결과 확인
1. <span style="color:red">저장 -> 테스트</span> 를 클릭하여 테스트를 실행

2. 텍스트 인식 모델의 작업 결과를 살펴보자

3. '입력' 에는 '다운로드 하려면 클릭' 을 클릭하여 입력된 값을 확인 가능하다.

4. '출력' 안의 'result'의 값에서 값을 확인 가능하다. 결과값은 아래와 같은 형식으로 들어올 것이다. 출력 값은 양식 인식 모델에서 '추출할 정보 선택'에서 설정한 값에 따라 달라질 것이다.<br>![image](https://user-images.githubusercontent.com/39551265/158719637-3fd178b2-15e9-48c4-9092-8dcc464dab49.png)<br>

* 양식 인식 모델에서 '추출할 정보 선택'에서 지정한 형식에 따라 값이 달라진다.
|양식종류|들어오는 값|
|---|---|
|필드|해당 필드의 값에 해당되는 텍스트 값, 위치, 정확도, 페이지 번호|
|확인란|해당 확인란의 값에 해당되는 체크 값, 위치, 정확도, 페이지 번호|
|한 페이지 테이블|해당 테이블에 값에 해당되는 엔티티,열,테이블값,전체값|
|여러 페이지 테이블|해당 테이블에 값에 해당되는 엔티티,열,테이블값,전체값, 페이지 값|

## 결과 텍스트값 가져오기

1. 결과 값을 가져와서 사용하는 과정 생성
2. 동적 콘텐츠에서 '추출할 정보 선택'에서 지정한 이름_value 를 통해 인식한 값을 가져옴<br>![image](https://user-images.githubusercontent.com/39551265/158721346-7fd8c56f-6732-4771-b10d-3ed1968966d4.png)<br>

* 테이블의 경우는 '테이블 이름 열 이름 value'를 선택 하면 각각에 적용에서 한개씩 받아서 적용한다.
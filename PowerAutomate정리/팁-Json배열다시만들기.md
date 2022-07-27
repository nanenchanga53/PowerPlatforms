# Power Autoamte 팁 - Json 배열 다시 만들기
> Power Automate에서 기존의 데이터 배열값을 이용해서 Json배열을 다시 만드는 방법을 알아본다.

## Json 배열 Key-Value 다시 만들어 넣기

1. '테이블에 있는 행 나열' 등의 Json배열을 반환하는 작업 이후에 Body의 Value은 이미 완성된 Json 배열값을 같고 있기에 이후 흐름에서 자신이 원하는 Key-Value값을 추가한 Json배열을 만들 수 없다.<br><Br>![image](https://user-images.githubusercontent.com/39551265/181258316-dc11a302-696a-4682-8ef1-b7cb7478c283.png)<br>

2. 위의 상황을 해결하기 위해 새로 `변수 초기화` 를 생성해 '유형'을 배열로 생성한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/181258648-adcfbd1a-7e88-4148-99a4-91f49bef6cf6.png)<br>

3. Json배열을 반환하는 작업의 값을 이용한 Loop(각각의 적용)에서 Json배열을 검색('이전 단계에서 출력 선택')하도록 설정한다. 이후 `배열 변수에 추가` 단계를 추가한 후 자신이 원하는 배열 요소의 Json 형식의 값을 입력한다. 이때 Key값은 직접 정해주고 Value값은 '각각에 적용'에서 검색되는 '동적 값'을 사용하는 것이 좋다.<br><br>![image](https://user-images.githubusercontent.com/39551265/181258897-bebebc29-496e-4d9a-ab48-c9fa9b65ebef.png)<br>

4. 위의 흐름은 다음과 비슷한 흐름을 갖게 될 것이다.<br><br>![image](https://user-images.githubusercontent.com/39551265/181260568-3763e1b8-9e9c-48b5-9a90-e123f9e03fda.png)<br>

5. 이후 코드를 이용한 데이터 수정이 어려운 Power Apps 등에서 사용하도록 변경한 Json배열 값을 반환한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/181260716-fcb66a65-d603-4163-9e8a-2e35558ee512.png)<br>
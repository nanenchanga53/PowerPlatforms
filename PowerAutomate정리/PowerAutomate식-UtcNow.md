# PowerAutomate 식 - 현재 세계표준시간을 가져오는 함수 : utcNow
> PowerAutomate 웹버전에서 UtcNow() 함수는 값들을 문자열 형태로 합치는 역할을 한다.

## 기본 사용법

1. 입력값 없이 사용
    * utc표준 시간 타임스템프 형식 'yyyy-MM-ddThh:mm:ss.ssssssZ' 으로 반환한다.
    * 식 : `utcNow()`
    * 결과 : `2022-05-06T01:54:50.2899053Z`<br><br>![image](https://user-images.githubusercontent.com/39551265/167054759-e6c1fbc9-ca97-4bbe-a156-2e4b79b72c47.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/167054885-bcfc22fa-22cf-4d51-a335-0bc2559c4fd9.png)<br>


2. 날짜형식 입력
   * 날짜형식을 함수의 파라메터로 입력하여 시간의 반환 형식을 설정한다. 이때 각 시간에 대한 정보는 타임 스템프의 문자형식을 따른다.
   * 식 : `utcNow('yyyy-MM-ddTHH:mm:ss')` 
   * 결과 : `2022-05-06T02:07:03`<br><br>![image](https://user-images.githubusercontent.com/39551265/167056283-a988ef0e-492b-4181-95cf-5cebcc40a3d6.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/167055681-ffd73dd8-be06-42bb-94bb-d0a3ae2fc0bb.png)<br>

3. 표준 시간대 변환 작업과 사용
    * 해당 함수는 '표준 시간대 변환 작업'과 사용하면 날짜형식을 변환하거나 시간대 계산을 직접 하지 않고 사용이 가능하다.
    * '기본 시간' 항목에 `utcNow()` 함수를 입력
    * '서식 문자열' 항목에서 어떠한 서식으로 시간을 반환할지 설정(원하는 형식이 없다면 직접 입력)
    * '원본 표준 시간대' 항목에서 '(UTC) 협정 세계시' 설정
    * '대상 표준 시간대' 항목에서 자신이 반환받고 싶은 시간대 설정<br><br>![image](https://user-images.githubusercontent.com/39551265/167056535-8a23269c-05cb-402f-b10f-3d4e7b179884.png)<br>

4. 같이 사용하면 좋은 함수들

    |함수|용도|
    |---|---|
    |addDays|타임스템프에 입력 일 수를 추가|
    |addHour|타임스템프에 입력 시간 수를 추가|
    |addMinutes|타임스템프에 입력 분 수를 추가|
    |addSeconds|타임스템프에 입력 초 수를 추가|
    |addToTime|타임스템프에 입력 시간만큼 추가|
    |convertFromUtc|UTC 입력 시간대에서 다른 시간대의 시간으로 변경|
    |convertTimeZone|원본 시간대에서 다른 시간대의 시간으로 변경|
    |convertToUtc|기존 시간대에서 UTC시간대로 변경|
    |dayOfMonth|입력 시간의 해당 달의 몇일인지 반환|
    |dayOfWeek|입력 시간의 해당 주의 몇일인지 반환|
    |dayOfYear|입력 시간의 해당 년의 몇일인지 반환|
    |formatDateTime|타임스템프에서 날짜 시간형식 변환|
    |getFutureTime|일정 시간 후의 타임스템프 반환|
    |getPastTime|일정 시간 전의 타임스템프 반환|
    |startOfDay|입력 시간의 날짜 시작 시간대를 반환|
    |startOfHour|입력 시간의 시작 시의 시간대를 반환|
    |startOfMonth|입력 시간의 시작 월의 시간대를 반환|
    |substractFromTime|입력 시간에서 일정 시간을 뺀 것을 반환|
    |ticks|타임스템프를 tick 시간으로 반환|
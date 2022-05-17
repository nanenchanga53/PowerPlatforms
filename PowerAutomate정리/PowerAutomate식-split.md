# PowerAutomate 식 - 문자열을 나누는 함수 : split
> PowerAutomate 클라우드에서 split() 함수는 문자열을 분리하는 역할을 한다.

## 기본 사용법

1. 문자열 분리
    * 문자열을 기준 문자로 나눈다. 반환은 JSON 배열 형식으로 반환된다.
    * 식 : `split('{문자열을 나누기 위한 문자열}','{문자열을 나눌 기준}')`
    * 결과 : `["{문자열}","{문자열}","{문자열}"]`<br><br>![image](https://user-images.githubusercontent.com/39551265/168421305-26b3d9cb-1f4b-4892-9aa1-88444013cab4.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/168421709-e8a89027-9576-46df-aac1-8b5518957309.png)<br>


2. 반환이 있는지 확인 방법
    * 반환 값이 문자열 배열이니 length 함수를 이용해 1보다 큰지 확인하면 제대로 나누어졌는지 확인 가능하다.
    * 식 : `length(split('{문자열을 나누기 위한 문자열}','{문자열을 나눌 기준}'))`
    * 결과 : `나누어진 문자열 개수 예 : 3`

3. 주의사항
    * 문자열은 대소문자를 구분한다. 대소문자를 구분하지 않는다면 `toUpper` 또는 `toLower`를 문자열에 사용하는 것이 좋다.
    * 문자열을 나눌 기준의 양옆이 비어있어도 비어있는 문자열을 반환한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/168421982-f70c4a56-c735-4782-98bc-8011fa3d130f.png)<br><br>![image](https://user-images.githubusercontent.com/39551265/168422031-3ce5a866-54c5-43de-991e-15c0fb99c5f8.png)<br>
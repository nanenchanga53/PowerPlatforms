# PowerAutomate 식 - 값이 존재하는지 판단 : Empty
> PowerAutomate 클라우드에서 Empty() 함수는 해당 값이 존재하는지 않는지(값이 NUll) 확인하여 없으면 true 존재하면 false를 반환한다.

## 기본 사용법

1. 값이 존재하는지 확인
    * Power Autoamte에서 설정한 변수나 문자열의 값이 존재하는지 확인하여 값이 비어있다면 true 비어있지 않다면 true 반환
    * 식 : `empty({변수나 문자값})`<br><br>![image](https://user-images.githubusercontent.com/39551265/169756776-5e5113a9-a31c-484c-aed1-8b122972e687.png)
    * 결과 : `true 혹은 false`<br>![image](https://user-images.githubusercontent.com/39551265/169757688-165c62a5-c9dd-4c45-9d21-cdabae39c5e1.png)<br>

2. 주의점
    * 파라메터에 값 '' 을 입력하면 true를 반환한다.

    * 비어있는 JSON 배열 값에 해당되는 '[]'을 입력하면 Json 배열이 아닌 string 값으로 인식하여 false 반환<br><br>![image](https://user-images.githubusercontent.com/39551265/169760894-3fe2e9ed-3c04-4e51-872f-10fe1ae6e8d0.png)<br>

    * `createArray({배열값},{배열값})`을 사용해 배열을 새로 생성하여 사용하면 배열 생성시 값이 포함되기 때문에 false만을 반환하게 된다.
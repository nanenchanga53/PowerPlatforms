# PowerAutomate 식 - Concat
> PowerAutomate 웹버전에서 Concat() 함수는 값들을 문자열 형태로 합치는 역할을 한다.

## 기본 사용법

1. 문자
> 문자열만을 매개변수로 포함시키면 입력된 문자열을 합쳐 반환한다.

    ```
    concat('Hello',' ','World')

    반환값
    Hello World

    ```


![image](https://user-images.githubusercontent.com/39551265/156303609-02a6a233-460e-433a-997b-dbc1e7daacc2.png)


2. Bool
> Bool값을 매개변수로 포함시키면 TRUE, FALSE를 문자열로 반환한다.
    ```
    concat('결과 : ',variables('TEST'))

    반환값
    결과 : TRUE

    ```

![image](https://user-images.githubusercontent.com/39551265/156306256-3e1664b2-7976-43b1-9238-c7f6701fabcc.png)


![image](https://user-images.githubusercontent.com/39551265/156304947-fb36550c-2032-4d52-b56e-cf3986ef80d5.png)

3. 숫자
> 숫자를 매개변수로 포함시키면 숫자를 문자열로 변환해 반환한다. (소수 포함)

    ```
    concat('결과 : ',variables('TEST'))

    반환값
    결과 : 10

    ```

![image](https://user-images.githubusercontent.com/39551265/156306118-e966ad2a-a29d-4b82-ad1b-08b2a72e820d.png)

![image](https://user-images.githubusercontent.com/39551265/156304947-fb36550c-2032-4d52-b56e-cf3986ef80d5.png)

4. 배열
> 배열을 그대로 포함하면 배열의 Values값이 그대로 나온다.

    ```
    concat('결과 : ',variables('TEST'))

    반환값
    결과 : [ "Apple", "Banana", "Cherry"]

    ```


![image](https://user-images.githubusercontent.com/39551265/156307797-2b2d92d6-4388-4bcb-aa1a-8ad6ec07c9f6.png)

![image](https://user-images.githubusercontent.com/39551265/156304947-fb36550c-2032-4d52-b56e-cf3986ef80d5.png)

> 배열에 포함된 값들만을 받고 싶으면 join() 함수를 사용한다.

    ```
    concat('결과 : ', join(variables('TEST'),' '))

    반환값
    결과 : Apple Banana Cherry

    ```

![image](https://user-images.githubusercontent.com/39551265/156308716-b774402f-2320-4c28-9741-5beb0de69690.png)
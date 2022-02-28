# PowerAutomate 작업 : 데이터작업-Json구문분석
> PowerAutomate의 작업 중 하나인 Json구문분석의 사용법을 알아본다.


## 작업 만들기
1. 원하는 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. **데이터 작업** 선택<br>![image](https://user-images.githubusercontent.com/39551265/155927066-c1205ee5-07ca-441b-a547-c0c1053d8d6d.png)<br>

3. **Json구문 분석** 선택<br>![image](https://user-images.githubusercontent.com/39551265/155927127-0a264637-c59b-4a8b-a842-32afb13fc17f.png)<br>

4. Json구문 분석 작업이 생길것이다.

5. **콘텐츠**에 분석할 Json구문을 입력한다.(직접입력해도 되지만 아래 이미지처럼 HTTP 결과 본문을 사용하는것이 보통이다.)<br>![image](https://user-images.githubusercontent.com/39551265/155926934-dd0c5510-5476-4753-9640-bcfb2ea3d9a4.png)<br>

6. 아래쪽의 **샘플에서 생성**을 클릭<br>![image](https://user-images.githubusercontent.com/39551265/155930232-05a2e180-9d70-4131-b526-a084995ad1bd.png)<br>

7. **샘플 Json 페이로드 삽입** 창에서 콘텐츠와 같은 형식의 샘플 Json 데이터를 입력 후 **완료** 클릭<br>![image](https://user-images.githubusercontent.com/39551265/155930437-d044606e-31e5-422b-9298-2e41779c0a6b.png)<br>

8. 그 후 PowerAutomate에서 사용이 가능하도록 스키마가 생성된다. <br>![image](https://user-images.githubusercontent.com/39551265/155930619-39a57672-6570-4665-adbb-8b15758d75ff.png)<br>


9. 이후 작업에선 **동적 컨텐츠**에서 Json항목을 가져와 사용하면 된다.<br>![image](https://user-images.githubusercontent.com/39551265/155930742-3ff67658-86b7-435f-af5c-c0312752dfb9.png)<br>
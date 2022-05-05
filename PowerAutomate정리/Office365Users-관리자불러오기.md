# Power Automate 작업 : Office 365 Users - 관리자 불러오기
> Microsoft 365 관리센터나 Azure Active Dirctory 에서 사용자의 관리자를 설정해둔 것을 손쉽게 가져오는 작업을 Power Automate에서 지원한다. 관리자 설정은 [사용자의 관리자설정](https://github.com/nanenchanga53/PowerPlatforms/blob/main/%EB%A7%88%EC%9D%B4%ED%81%AC%EB%A1%9C%EC%86%8C%ED%94%84%ED%8A%B8365%EA%B4%80%EB%A6%AC%EC%84%BC%ED%84%B0/%EC%82%AC%EC%9A%A9%EC%9E%90%EA%B4%80%EB%A6%AC%EC%9E%90%EC%84%A4%EC%A0%95.md)을 확인하자.

## 흐름에 관리자 불러오기 작업 추가
1. 파일 콘텐츠를 가져오는 작업 이후의 위치에 **새 단계(+ 아이콘) -> 작업 추가**<br>![image](https://user-images.githubusercontent.com/39551265/155929733-389e36ba-5b77-49c2-ada4-b892d0d1200f.png)<br>

2. 작업 중에서 <span style="color:red">Office 365 Users</span> 선택<br><br>![image](https://user-images.githubusercontent.com/39551265/166902521-2bd83274-eea1-4f2f-b52d-396ae4e26d2c.png)<br>

3. <span style="color:red">관리자 불러오기</span> 선택<br><br>![image](https://user-images.githubusercontent.com/39551265/166903003-75440723-b921-4de4-8c13-3efe5a5ded32.png)<br>


4. '사용자(UPN)' 항목에 사용자의 메일주소를 입력한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166905300-d0ede962-961f-4f1b-8a29-55b68a63726d.png)<br>

5. 흐름을 실행하면 관리자의 정보가 불러와 지는 것을 확인 가능하다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166905161-456bd01f-af38-4e6f-935a-8bf417f9c449.png)<br>

6. 만약 불러오는 필드를 제한하고 싶다면 '고급 옵션' 을 클릭하면 '필드선택' 항목이 나오는데 이곳에 불러오는 JSON값의 KEY값과 쉼표를 입력하여 제한한다.<br><br>![image](https://user-images.githubusercontent.com/39551265/166906255-357e9089-d4b8-46aa-9228-552290fb558e.png)<br>

7. 표시이름(displayName)만을 가져온 결과<br><br>![image](https://user-images.githubusercontent.com/39551265/166906187-02df4f41-dae4-4153-8798-4a2fd827b027.png)<br>
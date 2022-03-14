# # Power Apps 사용자 지정 구성요소 - 2 솔루션 만들어 포함시키기
> 사실 Power Apps 솔루션페이지에서 만들어서 업로드하는게 편하겠지만 내부에서 만들어두고 배포도 가능하니 일단 알아두자. 이 작업은 코드 구성 요소 만들기를 완료해야지 진행 가능하다.

## 솔루션 파일 만들기

1. 코드 구성요소를 만든 폴더에서 Solution 폴더를 생성한다.

2. PowerShell을 열어 다음 명령어를 실행해 솔루션을 초기화한다.
    ```PowerShell
    PowerShell을 열어 이전 Power Apps 
    ```

3. 다음 명령어를 통해 코드 구성요소를 솔루션에 추가한다.
    ```PowerShell
    pac solution add-reference --path ..
    ```

4. 다음 명령어를 실행해 zip 파일을 생성한다.(이 작업을 해야 솔루션으로 업로드가 가능하다.)
```PowerShell
msbuild /t:build /restore
```

5. \bin\debug\ 폴더를 열어 solution.zip 파일이 생성되었는지 확인한다.


## Power Apps 페이지에서 솔루션 업로드

1. Power Apps 페이지로 간다.

2. <span style="color:red">솔루션 -> 가져오기</span>를 클릭<br>![image](https://user-images.githubusercontent.com/39551265/158058353-83575f57-0a27-45fd-8ae6-85f9e0c632ce.png)<br>

3. <span style="color:red">찾아보기</span> 클릭후 생성한 솔루션을 찾아 <span style="color:red">다음</span>을 클릭하면 된다.<br>![image](https://user-images.githubusercontent.com/39551265/158058447-2985a806-47eb-4eb7-b062-3ad8a4328dab.png)<br>
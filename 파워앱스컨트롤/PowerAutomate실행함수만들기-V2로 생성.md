# PowerAutomate 실행함수 만들기 - V2로 생성
> 기존 트리거에서는 파라메터 입력 개수를 무조건 맞추어야 사용해야 하거나 파라메터의 추가, 삭제가 자유롭지 못하는 등의 문제가 있다. 이것을 해결하기 위해 새로운 버전인 V2가 생성되었다. 이후 정식버전이 된다면 해당 생성 방식이 기본적인 Power Apps 트리거 흐름이 될 것이다.

## Power Apps V2 트리거 흐름 만들기

1. 흐름을 생성 혹은 편집을 선택해 '흐름 편집 페이지'로 들어온다.

2. Power Apps 트리거(첫 단계)의 <span style="color:red">... -> 삭제</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162576900-92667740-18c5-4759-a529-f8a16b82b69b.png)<br>

3. <span style="color:red">확인</span> 클릭

4. <span style="color:red">Power Apps</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162577061-a490e69b-b3ef-4893-a62d-0f1bf8eb924e.png)<br>

5. <span style="color:red">PowerApps(V2)</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162577091-2d57935a-a5d9-4fcd-9ba4-8d2eb7dc283c.png)<br>

6. 다음과 같은 트리거가 생성된다.<br>![image](https://user-images.githubusercontent.com/39551265/162577136-cfd93ff9-2992-4f16-8fb0-d06e0fdf0add.png)<br>

## Power Apps V2 입력 파라메터 추가

1. <span style="color:red">+ 입력추가</span> 클릭<br>![image](https://user-images.githubusercontent.com/39551265/162577181-40b503d7-a3ca-470a-ba0c-d68aa849d4ce.png)<br>

2. 입력 종류를 선택한다.<br>![image](https://user-images.githubusercontent.com/39551265/162577224-ca46eb45-5ba4-4d4b-805e-bddedc34f209.png)<br>

## 입력 파라메터 설정

1. 첫번째 항목은 이후 흐름에서 사용한 동적 값/동적 컨텐츠 에서 사용될 이름, 두번째 항목은 해당 값의 설명<br>![image](https://user-images.githubusercontent.com/39551265/162577441-c1fb6d0a-dfb3-4510-9e60-46fc54967a6c.png)<br>

2. 오른쪽의 <span style="color:red">...</span> 을 클릭하면 해당 파라메터를 더 상세한 설정이 가능하다.<br>![image](https://user-images.githubusercontent.com/39551265/162577560-f847ffb9-8fb1-42b2-85b9-4ceff8ffbc19.png)<br>

3. Power Apps에서 필수로 들어와야 하는 파라메터라면 '선택 사항 필드 만들기' 문구가 나오는지 확인한다(현재 필수 필드로 선택되어 있다는 것). 값을 넣지 않아도 되는 값이면 '필수 필드 만들기'로 선택되어 있는지 확인한다.(현재 선택 사항 필드로 선택되어 있다는 것). 필수/선택 을 바꾸려면 해당 항목을 클릭하면 변경이 된다.<br>![image](https://user-images.githubusercontent.com/39551265/162577688-1de382b0-0e49-4e2a-81c5-aa6ecfe3e551.png)<br>
![image](https://user-images.githubusercontent.com/39551265/162577718-f02919e1-a344-48de-9273-3f5a1a736473.png)<br>

4. 만약 Power Apps에서 여러 값을 제시하여 하나의 값을 선택하도록 하고 싶으면 '옵션의 드롭다운 목록 추가'를 선택한다. 그후 '옵션의 드롭다운 목록' 항목에 제시할 값을 입력한다. 이후 Power Apps에서 흐름실행 함수(흐름이름.RUN)를 만들시 값이 제시된다.<br>![image](https://user-images.githubusercontent.com/39551265/162577908-a535aaa3-6515-4033-b179-6910b3465932.png)<br>![image](https://user-images.githubusercontent.com/39551265/162577947-7b6edc02-e831-49a5-a836-fea5cf99661c.png)<br>![image](https://user-images.githubusercontent.com/39551265/162578046-c3cd5d9e-9159-4a98-ac4b-d1a1c967c153.png)<br>


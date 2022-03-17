# Power Apps 코드 구성 요소 만들기
> PowerApps에서 제공하는 컨트롤만을 가지고는 원하는 모양과 필요한 작업을 하지 못할 경우가 있다, 그런 것을 해결하기 위해 코드 구성요소를 코드로 만드는 것을 타입스크립트와 node.js 형식으로 제공해준다. 지금부터 코드 구성요소를 만드는 실습을 해보자.

## 설치에 필요한 사항
1. Npm 이나 Node.js 를 최신버전을 받는다.
2. 비주얼 스튜디오(2019버전 이상)를 설치한다.
3. [Power Apps CLI](https://aka.ms/PowerAppsCLI/) 를 설치한다.


## 새 코드 구성 요소 프로젝트 만들기
1. Power Shell을 열어 아래의 명령어를 입력한다.
    ```PowerShell
    pac pcf init --namespace SampleNamespace --name HelloPCF --template field
    ```

2. 완료가 되면 `npm install pm2@latest -g` 명령어를 입력한다.

3. `code .`을 입력해 VSCode를 연다.

## 코드 구성 요소의 매니페스트 업데이트

1. ControlManifest.Input.xml 파일에 있는 속성을 변경
    ```xml
    <control namespace="SampleNamespace" constructor="HelloPCF" version="1.0.0" display-name-key="Hello PCF" description-key="Says hello" control-type="standard">
    ```

2. name 쪽의 속성도 바꿔준다.
    ```xml
    <property name="Name" display-name-key="Name" description-key="A name" of-type="SingleLine.Text" usage="bound" required="true" />
    ```

3. resources 안의 css를 추가한다.
    ```xml
    <css path="css/hello-pcf.css" order="1" />
    ```

## css파일 추가
1. HelloPCF 폴더 안에 css 폴더를 만들고 hello-pcf.css 파일을 만든다.

2. 만든파일에 아래 css를 입력
    ```css
    .SampleNamespace\.HelloPCF {
    font-size: 1.5em;
    }
    ```

## 빌드

1. 아래의 명령어를 입력해 빌드를 실행한다.
    ```PowerShell
    npm run build
    ```

* 빌드 아티팩트에는 다음이 포함 bundle.js , ControlManifest.xml


## 기능 구현

1. index.ts 를 연다

2. class 안 상단에 다음의 private 변수를 입력한다.
    ```ts
    // PCF context 오브젝트
    private context: ComponentFramework.Context<IInputs>;

    // div로 감싸는 container 정의
    private container: HTMLDivElement;

    // 속성을 변경할 때마다 호출할 콜백 만들기
    private notifyOutputChanged: () => void;

    // 구성 요소가 편집 모드에 있는지 여부 추적할 플래그
    private isEditMode: boolean;

    // 이벤트 처리기를 추적하여 완료되면 이를 제거할 수 있습니다.
    private buttonClickHandler: EventListener;

    // 이름 속성에 대한 추적 변수
    private name: string | null;
    ```

3. init 함수를 다음과 같이 변경
    ```ts
    public init(
    context: ComponentFramework.Context<IInputs>,
    notifyOutputChanged: () => void,
    state: ComponentFramework.Dictionary,
    container: HTMLDivElement
    ) {
    // 변화 기록(트래킹)
    this.context = context;
    this.notifyOutputChanged = notifyOutputChanged;
    this.container = container;
    this.isEditMode = false;
    this.buttonClickHandler = this.buttonClick.bind(this);

    // Hello 메시지를 보유할 범위 요소 만들기
    const message = document.createElement("span");
    message.innerText = `Hello ${this.isEditMode ? "" : context.parameters.Name.raw}`;

    // 이름을 편집할 텍스트 상자를 만듭니다.
    const textbox = document.createElement("input");
    textbox.type = "text";
    textbox.style.display = this.isEditMode ? "block" : "none";
    if (context.parameters.Name.raw) {
        textbox.value = context.parameters.Name.raw;
    }

    // 위의 두 요소를 div로 래핑하여 콘텐츠를 상자로 바꿈
    const messageContainer = document.createElement("div");
    messageContainer.appendChild(message);
    messageContainer.appendChild(textbox);

    // 편집 및 읽기 모드 사이를 전환할 버튼
    const button = document.createElement("button");
    button.textContent = this.isEditMode ? "Save" : "Edit";
    button.addEventListener("click", this.buttonClickHandler);

    // 전체 컨트롤 컨테이너에 메시지 컨테이너 및 버튼 추가
    this.container.appendChild(messageContainer);
    this.container.appendChild(button);
    }
    ```

4. buttonClick 함수를 init 함수 다음에 추가
    ```ts
    // 버튼 클릭 이벤트에 대한 이벤트 처리기
    public buttonClick() {
    // DOM 쿼리를 통해 컨트롤 받기
    const textbox = this.container.querySelector("input")!;
    const message = this.container.querySelector("span")!;
    const button = this.container.querySelector("button")!;

    // 편집 모드가 아닌 경우 현재 이름 값을 텍스트 상자에 복사합니다.
    if (!this.isEditMode) {
        textbox.value = this.name ?? "";
    } else if (textbox.value != this.name) {
        // 편집 모드에서 텍스트 상자 값을 복사하여 이름을 지정하고 모티프 콜백을 호출합니다.
        this.name = textbox.value;
        this.notifyOutputChanged();
    }

    // 모드 변경
    this.isEditMode = !this.isEditMode; 

    // 변경 사항에 따라 새 출력 설정
    message.innerText = `Hello ${this.isEditMode ? "" : this.name}`;

    textbox.style.display = this.isEditMode ? "inline" : "none";
    textbox.value = this.name ?? "";

    button.textContent = this.isEditMode ? "Save" : "Edit";
    }
    ``` 

5. Update 함수를 다음과 같이 변경
    ```ts
    public updateView(context: ComponentFramework.Context<IInputs>): void {
    // 외부에서 들어오는 업데이트 확인
    this.name = context.parameters.Name.raw;
    const message = this.container.querySelector("span")!;
    message.innerText = `Hello ${this.name}`;
    }
    ```

6. getOutputs 함수를 다음과 같이 변경
    ```ts
    public getOutputs(): IOutputs {
    return {
        // 이름 변수가 null인 경우 대신 정의되지 않은 반환
        Name: this.name ?? undefined
    };
    }
    ```

7. destroy 함수를 다음과 같이 변경
    ```ts
    public destroy() {
    // init에서 만든 이벤트 리스너 제거
    this.container.querySelector("button")!.removeEventListener("click", this.buttonClickHandler);
    }
    ```

## 빌드 후 실행

1. 아래 명령어를 입력해 빌드한다.
    ```PowerShell
    npm run build
    ```

2. 아래 명령어를 입력해 실행해본다.(실행 중 바뀌는 것을 확인 하고 싶으면 watch를 추가하낟)
    ```
    npm start
    ```

* 결과이미지<br>![image](https://user-images.githubusercontent.com/39551265/158055727-c0eba6ab-8820-4013-887b-43bda2512c2e.png)<br>

## 참고 사이트
https://microsoftlearning.github.io/PL-400_Microsoft-Power-Platform-Developer/Instructions/Labs/LAB%5BPL-400%5D_Lab05_PCF.html

https://docs.microsoft.com/ko-kr/learn/modules/build-power-app-component/1-create-code-component
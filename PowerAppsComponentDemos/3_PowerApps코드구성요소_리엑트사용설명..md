# Power Apps 코드 구성요소 - 리엑트 사용
> 코드 구성요소에서는 리엑트 등의 UI 라이브러리를 사용 가능하다. 여기서는 타입 스크립트와 같이 자주 사용하는 React를 사용해보자

## 코드 구성요소 초기화
1. 다음 명령을 파워쉘에서 실행해 초기화된 프로젝트를 만든다.


    ```PowerShell
    pac pcf init --namespace SampleControls --name ReactStandardControl --template field
    ```

2. 다음 종속성을 package.json의 "dependencies" 안에 추가한다.(React 및 Office UI 라이브러리 사용)


    ```json
    "office-ui-fabric-react": "^6.189.0",
    "react": "^16.8.6",
    "react-dom": "^16.8.6"
    ```

3. 다음 종속성을 package.json의 "devDependencies" 안에 추가한다.(설치 확인)


    ```json
    "@types/react": "^16.8",
    "@types/react-dom": "^16.8"
    ```

4. tsconfig.json 에 "compilerOptions" 안에 추가하여 컴파일러가 React를 사용하도록 설정한다.


    ```
    "jsx": "react",
    "jsxFactory": "React.createElement"
    ```


5. 다음 명령어를 입력하여 프로젝트에 종속 라이브러리를 로드한다.


    ```powershell
    npm install
    ```

## 코드 구성요소 로직 구현

1. 코드 구성 요소의 매니페스트 파일(ControlManifest.Input.xml)을 열고 다음과 같이 바꾼다.


    ```xml
    <?xml version="1.0" encoding="utf-8" ?>
    <manifest>
    <control namespace="SampleControls" constructor="ReactStandardControl" version="0.0.1" display-name-key="ReactStandardControl_Display_Key" description-key="ReactStandardControl_Desc_Key" control-type="standard">
        <!-- property node identifies a specific, configurable piece of data that the control expects from CDS -->
        <property name="numberOfFaces" display-name-key="numberOfFaces" description-key="numberOfFaces" of-type="Whole.None" usage="bound" required="false" />
        <resources>
        <css path="css/ReactStandardControl.css" order="1" />
        <code path="index.ts" order="2"/>
        </resources>
    </control>
    </manifest>
    ```

2. index.ts 파일을 열고 최상단에 다음 import 문을 추가한다.


    ```ts
    import { IInputs, IOutputs } from "./generated/ManifestTypes";
    import * as React from "react";
    import * as ReactDOM from "react-dom";
    import { FacepileBasicExample, IFacepileBasicExampleProps } from "./Facepile";
    ```

3. 클래스 내부 최상단에 다음 private 변수를 삽입


    ```ts
    // notifyOutputChanged 매소드의 참조
    private notifyOutputChanged: () => void;
    // 컨테이너 div의 참조
    private theContainer: HTMLDivElement;
    // 반환 이벤트 처리기로 미리 정의된 React 요소에 대한 참조
    private props: IFacepileBasicExampleProps = {
    numberFacesChanged: this.numberFacesChanged.bind(this)
    };

    ```

4. 다음 로직을 init 함수 안에 추가한다.


    ```ts
    this.notifyOutputChanged = notifyOutputChanged;
    this.props.numberOfFaces = context.parameters.numberOfFaces.raw || 3;
    this.theContainer = container;
    ```

5. 다음 로직을 updateView 함수 안에 추가한다.


    ```ts
    if (context.updatedProperties.includes("numberOfFaces"))
        this.props.numberOfFaces = context.parameters.numberOfFaces.raw || 3;

        // React구성 요소를 div 컨테이너에 랜더링
        ReactDOM.render(
        // React 구성 요소를 생성
        React.createElement(
            FacepileBasicExample, // Facepile.tsx 안의 React class 유형
            this.props
        ),
        this.theContainer
        );
    ```

6. 다음 로직을 getOutputs 함수 안에 추가한다.


    ```ts
    numberOfFaces: this.props.numberOfFaces
    ```

7. 다음 로직을 destroy 함수 안에 추가한다.


    ```ts
    ReactDOM.unmountComponentAtNode(this.theContainer);
    ```

8. 전부 변경했다면 다음과 비슷할 것이다.

    ```ts
    import { IInputs, IOutputs } from "./generated/ManifestTypes";
    import * as React from "react";
    import * as ReactDOM from "react-dom";
    import { FacepileBasicExample, IFacepileBasicExampleProps } from "./Facepile";

    export class ReactStandardControl
    implements ComponentFramework.StandardControl<IInputs, IOutputs> {
    // reference to the notifyOutputChanged method
    private notifyOutputChanged: () => void;
    // reference to the container div
    private theContainer: HTMLDivElement;
    // reference to the React props, prepopulated with a bound event handler
    private props: IFacepileBasicExampleProps = {
        numberFacesChanged: this.numberFacesChanged.bind(this)
    };

    /**
     * Empty constructor.
     */
    constructor() {}

    /**
     * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
     * Dataset values are not initialized here, use updateView.
     * @param context The entire property bag that is available to control though the Context Object; It contains values as set up by the customizer that are mapped to property names that are defined in the manifest and to utility functions.
     * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs that are ready to be retrieved asynchronously.
     * @param state A piece of data that persists in one session for a single user. Can be set at any point in a control's life cycle by calling 'setControlState' in the Mode interface.
     * @param container If a control is marked control-type='starndard', it will receive an empty div element within which it can render its content.
     */
    public init(
        context: ComponentFramework.Context<IInputs>,
        notifyOutputChanged: () => void,
        state: ComponentFramework.Dictionary,
        container: HTMLDivElement
    ) {
        this.notifyOutputChanged = notifyOutputChanged;
        this.props.numberOfFaces = context.parameters.numberOfFaces.raw || 3;
        this.theContainer = container;
    }

    /**
     * Called when any value in the property bag has changed. This includes field values, datasets, global values such as container height and width, offline status, control metadata values such as label, visible, and so on.
     * @param context The entire property bag that is available to control through the Context Object; It contains values as set up by the customizer that is mapped to names that are defined in the manifest and to utility functions
     */
    public updateView(context: ComponentFramework.Context<IInputs>): void {
        if (context.updatedProperties.includes("numberOfFaces"))
        this.props.numberOfFaces = context.parameters.numberOfFaces.raw || 3;

        // Render the React component into the div container
        ReactDOM.render(
        // Create the React component
        React.createElement(
            FacepileBasicExample, // the class type of the React component found in Facepile.tsx
            this.props
        ),
        this.theContainer
        );
    }

    /**
     * Called by the React component when it detects a change in the number of faces shown
     * @param newValue The newly detected number of faces
     */
    private numberFacesChanged(newValue: number) {
        // only update if the number of faces has truly changed
        if (this.props.numberOfFaces !== newValue) {
        this.props.numberOfFaces = newValue;
        this.notifyOutputChanged();
        }
    }

    /**
     * It is called by the framework prior to a control receiving new data.
     * @returns an object based on nomenclature that is defined in the manifest, expecting object[s] for property marked as "bound" or "output"
     */
    public getOutputs(): IOutputs {
        return {
        numberOfFaces: this.props.numberOfFaces
        };
    }

    /**
     * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup,
     * for example, canceling any pending remote calls, removing listeners, and so on.
     */
    public destroy(): void {
        ReactDOM.unmountComponentAtNode(this.theContainer);
    }
    }
    ```

## 코드 구성요소의 스타일 추가(CSS)

1. ReactContorl 폴더 안에 CSS 폴더를 추가한다.

2. CSS 폴더 안에 ReactStandardControl.css 파일을 추가한다.

3. ReactStandardControl.css 에 다음 css 스타일을 입력한다.


    ```css
    .msFacepileExample {
    max-width: 300px;
    }

    .msFacepileExample .control {
    padding-top: 20px;
    }

    .msFacepileExample .ms-Dropdown-container,
    .msFacepileExample .ms-Slider {
    margin: 10px 0 10px 0;
    }

    .msFacepileExample .ms-Dropdown-container .ms-Label {
    padding-top: 0;
    }

    .msFacepileExample .ms-Checkbox {
    padding-top: 15px;
    }

    .exampleCheckbox {
    margin: 10px 0;
    }

    .exampleLabel {
    margin: 10px 0;
    }
    ```

## React 요소 추가

1. [React파일다운](https://github.com/MicrosoftDocs/mslearn-developer-tools-power-platform/tree/master/power-apps-component-framework) 깃 허브 사이트에서 zip 파일을 다운받는다.

2. ReactStandardControl 폴더에 zip 파일 안에 있는 다음 파일들을 추가한다.
    * Facepile.tsx
    * FacepileExampledata.ts
    * ReactVersion.Tsx
    * TestImages.ts

3. `npm run build` 를 파워쉘에서 실행해 빌드한다.

4. `npm start` 로 실행해서 잘 적용됬는지 확인한다.<br>![image](https://user-images.githubusercontent.com/39551265/158554180-8cb03e4e-69d8-40f0-8e36-987bc106baae.png)<br>
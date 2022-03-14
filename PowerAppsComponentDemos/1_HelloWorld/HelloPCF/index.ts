import {IInputs, IOutputs} from "./generated/ManifestTypes";

export class HelloPCF implements ComponentFramework.StandardControl<IInputs, IOutputs> {

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

	/**
	 * Empty constructor.
	 */
	constructor()
	{

	}

	/**
	 * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
	 * Data-set values are not initialized here, use updateView.
	 * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
	 * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs ready to be retrieved asynchronously.
	 * @param state A piece of data that persists in one session for a single user. Can be set at any point in a controls life cycle by calling 'setControlState' in the Mode interface.
	 * @param container If a control is marked control-type='standard', it will receive an empty div element within which it can render its content.
	 */
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


	/**
	 * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
	 * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
	 */
	public updateView(context: ComponentFramework.Context<IInputs>): void {
		// 외부에서 들어오는 업데이트 확인
		this.name = context.parameters.Name.raw;
		const message = this.container.querySelector("span")!;
		message.innerText = `Hello ${this.name}`;
	}
	/**
	 * It is called by the framework prior to a control receiving new data.
	 * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as “bound” or “output”
	 */
	public getOutputs(): IOutputs {
		return {
		  // 이름 변수가 null인 경우 대신 정의되지 않은 반환
		  Name: this.name ?? undefined
		};
	}

	/**
	 * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup.
	 * i.e. cancelling any pending remote calls, removing listeners, etc.
	 */
	public destroy() {
		// init에서 만든 이벤트 리스너 제거
		this.container.querySelector("button")!.removeEventListener("click", this.buttonClickHandler);
	}
}

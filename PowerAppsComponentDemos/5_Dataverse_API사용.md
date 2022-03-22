# Power Apps 코드 구성요소 - Dataverse API 사용
> Power Apps 코드 구성요소는 캔버스 앱 뿐만 아니라 Dynamics 365에서 데이터 요소에서 기본적으로 제공하는 컨트롤(텍스트,날짜 입력 등)을 대체하여 넣을 수 있다. 여기서는 기본으로 제공하는 테이블 '거래처' 에서 연간 매출을 자동으로 입력된 행을 만드는 컨트롤을 만들어보자

## 코드 구성요소 초기화
1. 다음 명령을 파워쉘에서 실행해 초기화된 프로젝트를 만든다.


    ```PowerShell
    pac pcf init --namespace SampleNamespace --name TSWebAPI --template field
    ```

2. 다음 명령어를 입력하여 프로젝트에 종속 라이브러리를 로드한다.


    ```powershell
    npm install
    ```


## 코드 구성요소 로직 구현
1. 코드 구성 요소의 매니페스트 파일(ControlManifest.Input.xml)을 열고 다음과 같이 바꾼다.


    ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <manifest>
        <control namespace="SampleNamespace" constructor="TSWebAPI" version="1.0.0" display-name-key="TS_WebAPI_Display_Key" description-key="TS_WebAPI_Desc_Display_Key" control-type="standard">
            <property name="stringProperty" display-name-key="stringProperty_Display_Key" description-key="stringProperty_Desc_Key" of-type="SingleLine.Text" usage="bound" required="true" />
            <resources>
                <code path="index.ts" order="1" />
                <css path="css/TS_WebAPI.css" order="2" />
            </resources>
            <feature-usage>
                <uses-feature name="WebAPI" required="true" />
            </feature-usage>
        </control>
    </manifest>
    ```

2. index.ts 파일을 연다.

3. 클래스 내부 최상단에 컨트롤로 적용할 다음 private 변수를 삽입


    ```ts
    // Reference to the control container HTMLDivElement
    // This element contains all elements of our custom control example
    private _container: HTMLDivElement;

    // Reference to ComponentFramework Context object
    private _context: ComponentFramework.Context<IInputs>;

    // Flag if control view has been rendered
    private _controlViewRendered: Boolean;

    // References to button elements that are rendered by example custom control
    private _createEntity1Button: HTMLButtonElement;
    private _createEntity2Button: HTMLButtonElement;
    private _createEntity3Button: HTMLButtonElement;
    private _deleteRecordButton: HTMLButtonElement;
    private _fetchXmlRefreshButton: HTMLButtonElement;
    private _oDataRefreshButton: HTMLButtonElement;

    // References to div elements that are rendered by the example custom control
    private _odataStatusContainerDiv: HTMLDivElement;
    private _resultContainerDiv: HTMLDivElement;

    ```

4. 다음 테이블의 이름,열을 나타내는. private 변수를 추가로 삽입


    ```ts
    // Name of entity to use for example Web API calls that are performed by this control
    private static _entityName: string = "account";

    // Required field on _entityName of type 'single line of text'
    // Example Web API calls that are performed by the example custom control will set this field for new record creation examples
    private static _requiredAttributeName: string = "name";

    // Value that the _requiredAttributeName field will be set to for new created records
    private static _requiredAttributeValue: string = "Web API Custom Control (Sample)";

    // Name of currency field on _entityName to populate during record create
    // Example Web API calls that are performed by the example custom control will set and read this field
    private static _currencyAttributeName: string = "revenue";

    // Friendly name of currency field (only used for control UI - no functional impact)
    private static _currencyAttributeNameFriendlyName: string = "annual revenue";

    ```

5. 다음 로직을 init 함수 안에 삽입

    ```ts
    this._context = context;
    this._controlViewRendered = false;
    this._container = document.createElement("div");
    this._container.classList.add("TSWebAPI_Container");
    container.appendChild(this._container);
    ```

6. updateView 함수안에 다음 로직 추가

    ```ts
    if (!this._controlViewRendered) {
                this._controlViewRendered = true;

                // Render Web API Examples
                this.renderCreateExample();
                this.renderDeleteExample();
                this.renderFetchXmlRetrieveMultipleExample();
                this.renderODataRetrieveMultipleExample();

                // Render result div to display output of Web API calls
                this.renderResultsDiv();}
    ```

7. html을 랜더링하기위해 다음 함수들을 추가


    ```ts
    /**
         * Helper method to create HTML button that is used for CreateRecord Web API Example
         * @param buttonLabel : Label for button
         * @param buttonId : ID for button
         * @param buttonValue : Value of button (attribute of button)
         * @param onClickHandler : onClick event handler to invoke for the button
         */
        private createHTMLButtonElement(buttonLabel: string, buttonId: string, buttonValue: string | null, onClickHandler: (event?: any) => void): HTMLButtonElement {
            let button: HTMLButtonElement = document.createElement("button");
            button.innerHTML = buttonLabel;

            if (buttonValue) {
                button.setAttribute("buttonvalue", buttonValue);
            }

            button.id = buttonId;

            button.classList.add("SampleControl_WebAPI_ButtonClass");
            button.addEventListener("click", onClickHandler);
            return button;
        }

        /**
         * Helper method to create HTML Div Element
         * @param elementClassName : Class name of div element
         * @param isHeader : True if 'header' div - adds extra class and post-fix to ID for header elements
         * @param innerText : innerText of Div Element
         */
        private createHTMLDivElement(elementClassName: string, isHeader: Boolean, innerText?: string): HTMLDivElement {
            let div: HTMLDivElement = document.createElement("div");

            if (isHeader) {
                div.classList.add("SampleControl_WebAPI_Header");
                elementClassName += "_header";
            }

            if (innerText) {
                div.innerText = innerText.toUpperCase();
            }

            div.classList.add(elementClassName);
            return div;
        }

        /** 
         * Renders a 'result container' div element to inject the status of the example Web API calls 
         */
        private renderResultsDiv() {
            // Render header label for result container
            let resultDivHeader: HTMLDivElement = this.createHTMLDivElement("result_container", true,
                "Result of last action");
            this._container.appendChild(resultDivHeader);

            // Div elements to populate with the result text
            this._resultContainerDiv = this.createHTMLDivElement("result_container", false, undefined);
            this._container.appendChild(this._resultContainerDiv);

            // Init the result container with a notification that the control was loaded
            this.updateResultContainerText("Web API sample custom control loaded");
        }

        /**
         * Helper method to inject HTML into result container div
         * @param statusHTML : HTML to inject into result container
         */
        private updateResultContainerText(statusHTML: string): void {
            if (this._resultContainerDiv) {
                this._resultContainerDiv.innerHTML = statusHTML;
            }
        }

        /**
         * Helper method to inject error string into result container div after failed Web API call
         * @param errorResponse : error object from rejected promise
         */
        private updateResultContainerTextWithErrorResponse(errorResponse: any): void {
            if (this._resultContainerDiv) {
                // Retrieve the error message from the errorResponse and inject into the result div
                let errorHTML: string = "Error with Web API call:";
                errorHTML += "<br />"
                errorHTML += errorResponse.message;
                this._resultContainerDiv.innerHTML = errorHTML;
            }
        }

        /**
         * Helper method to generate Label for Create Buttons
         * @param entityNumber : value to set _currencyAttributeNameFriendlyName field to for this button
         */
        private getCreateRecordButtonLabel(entityNumber: string): string {
            return "Create record with " + TSWebAPI._currencyAttributeNameFriendlyName + " of " + entityNumber;
        }

        /**
         * Helper method to generate ID for Create button
         * @param entityNumber : value to set _currencyAttributeNameFriendlyName field to for this button
         */
        private getCreateButtonId(entityNumber: string): string {
            return "create_button_" + entityNumber;
        }

    ```

8. 다음 oncClick 이벤트 핸들러를 추가해서 CURD 작업을 실행하도록 만든다


    ```ts
        /**
         * Event Handler for onClick of create record button
         * @param event : click event
         */
        private createButtonOnClickHandler(event: Event): void {
            // Retrieve the value to set the currency field to from the button's attribute
            const currencyAttributeValue: number = parseInt(
                (event.target as Element)?.attributes?.getNamedItem("buttonvalue")?.value ?? "0"
            );

            // Generate unique record name by appending timestamp to _requiredAttributeValue
            const recordName = `${TSWebAPI._requiredAttributeValue}_${Date.now()}`;

            // Set the values for the attributes we want to set on the new record
            // If you want to set additional attributes on the new record, add to data dictionary as key/value pair
            const data: ComponentFramework.WebApi.Entity = {};
            data[TSWebAPI._requiredAttributeName] = recordName;
            data[TSWebAPI._currencyAttributeName] = currencyAttributeValue;

            // Invoke the Web API to creat the new record
            this._context.webAPI.createRecord(TSWebAPI._entityName, data).then(
                (response: ComponentFramework.LookupValue) => {
                    // Callback method for successful creation of new record

                    // Get the ID of the new record created
                    const id: string = response.id;

                    // Generate HTML to inject into the result div to showcase the fields and values of the new record created
                    let resultHtml = `Created new ${  TSWebAPI._entityName  } record with below values:`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `id: ${id}`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `${TSWebAPI._requiredAttributeName}: ${recordName}`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `${TSWebAPI._currencyAttributeName}: ${currencyAttributeValue}`;

                    this.updateResultContainerText(resultHtml);
                },
                (errorResponse) => {
                    // Error handling code here - record failed to be created
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }

        /**
         * Event Handler for onClick of delete record button
         * @param event : click event
         */
        private deleteButtonOnClickHandler(): void {
            // Invoke a lookup dialog to allow the user to select an existing record of type _entityName to delete
            const lookUpOptions: any =
            {
                entityTypes: [TSWebAPI._entityName]
            };

            const lookUpPromise = this._context.utils.lookupObjects(lookUpOptions);

            lookUpPromise.then(
                // Callback method - invoked after user has selected an item from the lookup dialog
                // Data parameter is the item selected in the lookup dialog
                (data: ComponentFramework.LookupValue[]) => {
                    if (data && data[0]) {
                        // Get the ID and entityType of the record selected by the lookup
                        const id: string = data[0].id;
                        const entityType: string = data[0].entityType;

                        // Invoke the deleteRecord method of the WebAPI to delete the selected record
                        this._context.webAPI.deleteRecord(entityType, id).then(
                            (response: ComponentFramework.LookupValue) => {
                                // Record was deleted successfully
                                const responseId: string = response.id;
                                const responseEntityType: string = response.entityType;

                                // Generate HTML to inject into the result div to showcase the deleted record 
                                this.updateResultContainerText(`Deleted ${responseEntityType} record with ID: ${responseId}`);
                            },
                            (errorResponse) => {
                                // Error handling code here
                                this.updateResultContainerTextWithErrorResponse(errorResponse);
                            }
                        );
                    }
                },
                (error) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(error);
                }
            );
        }

        /**
         * Event Handler for onClick of calculate average value button
         * @param event : click event
         */
        private calculateAverageButtonOnClickHandler(): void {
            // Build FetchXML to retrieve the average value of _currencyAttributeName field for all _entityName records
            // Add a filter to only aggregate on records that have _currencyAttributeName not set to null
            let fetchXML = "<fetch distinct='false' mapping='logical' aggregate='true'>";
            fetchXML += `<entity name='${TSWebAPI._entityName}'>`;
            fetchXML += `<attribute name='${TSWebAPI._currencyAttributeName}' aggregate='avg' alias='average_val' />`;
            fetchXML += "<filter>";
            fetchXML += `<condition attribute='${TSWebAPI._currencyAttributeName}' operator='not-null' />`;
            fetchXML += "</filter>";
            fetchXML += "</entity>";
            fetchXML += "</fetch>";

            // Invoke the Web API RetrieveMultipleRecords method to calculate the aggregate value
            this._context.webAPI.retrieveMultipleRecords(TSWebAPI._entityName, `?fetchXml=${  fetchXML}`).then(
                (response: ComponentFramework.WebApi.RetrieveMultipleResponse) => {
                    // Retrieve multiple completed successfully -- retrieve the averageValue 
                    const averageVal: number = response.entities[0].average_val;

                    // Generate HTML to inject into the result div to showcase the result of the RetrieveMultiple Web API call
                    const resultHTML = `Average value of ${TSWebAPI._currencyAttributeNameFriendlyName} attribute for all ${TSWebAPI._entityName} records: ${averageVal}`;
                    this.updateResultContainerText(resultHTML);
                },
                (errorResponse) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }

        /**
         * Event Handler for onClick of calculate record count button
         * @param event : click event
         */
        private refreshRecordCountButtonOnClickHandler(): void {
            // Generate OData query string to retrieve the _currencyAttributeName field for all _entityName records
            // Add a filter to only retrieve records with _requiredAttributeName field which contains _requiredAttributeValue
            const queryString = `?$select=${TSWebAPI._currencyAttributeName  }&$filter=contains(${TSWebAPI._requiredAttributeName},'${TSWebAPI._requiredAttributeValue}')`;

            // Invoke the Web API Retrieve Multiple call
            this._context.webAPI.retrieveMultipleRecords(TSWebAPI._entityName, queryString).then(
                (response: ComponentFramework.WebApi.RetrieveMultipleResponse) => {
                    // Retrieve Multiple Web API call completed successfully
                    let count1 = 0;
                    let count2 = 0;
                    let count3 = 0;

                    // Loop through each returned record
                    for (const entity of response.entities) {
                        // Retrieve the value of _currencyAttributeName field
                        const value: number = entity[TSWebAPI._currencyAttributeName];

                        // Check the value of _currencyAttributeName field and increment the correct counter
                        if (value == 100) {
                            count1++;
                        }
                        else if (value == 200) {
                            count2++;
                        }
                        else if (value == 300) {
                            count3++;
                        }
                    }

                    // Generate HTML to inject into the fetch xml status div to showcase the results of the OData retrieve example
                    let innerHtml = "Use above buttons to create or delete a record to see count update";
                    innerHtml += "<br />";
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 100: ${count1}`;
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 200: ${count2}`;
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 300: ${count3}`;

                    // Inject the HTML into the fetch xml status div
                    if (this._odataStatusContainerDiv) {
                        this._odataStatusContainerDiv.innerHTML = innerHtml;
                    }

                    // Inject a success message into the result div
                    this.updateResultContainerText("Record count refreshed");
                },
                (errorResponse) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }
    ```

9. 다음 함수를 추가하여 CURD작업의 결과를 랜더링


    ```ts
    /** 
     * Renders example use of CreateRecord Web API
     */
    private renderCreateExample() {
        // Create header label for Web API sample
        let headerDiv: HTMLDivElement = this.createHTMLDivElement("create_container", true, "Click to create "
            + TSWebAPI._entityName + " record");
        this._container.appendChild(headerDiv);

        // Create button 1 to create a record with the revenue field set to 100
        let value1: string = "100";
        this._createEntity1Button = this.createHTMLButtonElement(
            this.getCreateRecordButtonLabel(value1),
            this.getCreateButtonId(value1),
            value1,
            this.createButtonOnClickHandler.bind(this));

        // Create button 2 to create a record with the revenue field set to 200
        let value2: string = "200";
        this._createEntity2Button = this.createHTMLButtonElement(
            this.getCreateRecordButtonLabel(value2),
            this.getCreateButtonId(value2),
            value2,
            this.createButtonOnClickHandler.bind(this));

        // Create button 3 to create a record with the revenue field set to 300
        let value3: string = "300";
        this._createEntity3Button = this.createHTMLButtonElement(
            this.getCreateRecordButtonLabel(value3),
            this.getCreateButtonId(value3),
            value3,
            this.createButtonOnClickHandler.bind(this));

        // Append all button HTML elements to custom control container div
        this._container.appendChild(this._createEntity1Button);
        this._container.appendChild(this._createEntity2Button);
        this._container.appendChild(this._createEntity3Button);
    }

    /** 
     * Renders example use of DeleteRecord Web API
     */
    private renderDeleteExample(): void {
        // Create header label for Web API sample
        let headerDiv: HTMLDivElement = this.createHTMLDivElement("delete_container", true, "Click to delete " + TSWebAPI._entityName + " record");

        // Render button to invoke DeleteRecord Web API call
        this._deleteRecordButton = this.createHTMLButtonElement(
            "Select record to delete",
            "delete_button",
            null,
            this.deleteButtonOnClickHandler.bind(this));

        // Append elements to custom control container div
        this._container.appendChild(headerDiv);
        this._container.appendChild(this._deleteRecordButton);
    }

    /** 
     * Renders example use of RetrieveMultiple Web API with OData
     */
    private renderODataRetrieveMultipleExample(): void {
        let containerClassName: string = "odata_status_container";

        // Create header label for Web API sample
        let statusDivHeader: HTMLDivElement = this.createHTMLDivElement(containerClassName, true, "Click to refresh record count");
        this._odataStatusContainerDiv = this.createHTMLDivElement(containerClassName, false, undefined);

        // Create button to invoke OData RetrieveMultiple Example
        this._fetchXmlRefreshButton = this.createHTMLButtonElement(
            "Refresh record count",
            "odata_refresh",
            null,
            this.refreshRecordCountButtonOnClickHandler.bind(this));

        // Append HTML elements to custom control container div
        this._container.appendChild(statusDivHeader);
        this._container.appendChild(this._odataStatusContainerDiv);
        this._container.appendChild(this._fetchXmlRefreshButton);
    }

    /** 
     * Renders example use of RetrieveMultiple Web API with Fetch XML
     */
    private renderFetchXmlRetrieveMultipleExample(): void {
        let containerName: string = "fetchxml_status_container";

        // Create header label for Web API sample
        let statusDivHeader: HTMLDivElement = this.createHTMLDivElement(containerName, true,
            "Click to calculate average value of " + TSWebAPI._currencyAttributeNameFriendlyName);
        let statusDiv: HTMLDivElement = this.createHTMLDivElement(containerName, false, undefined);

        // Create button to invoke Fetch XML RetrieveMultiple Web API example
        this._oDataRefreshButton = this.createHTMLButtonElement(
            "Calculate average value of " + TSWebAPI._currencyAttributeNameFriendlyName,
            "odata_refresh",
            null,
            this.calculateAverageButtonOnClickHandler.bind(this));

        // Append HTML Elements to custom control container div
        this._container.appendChild(statusDivHeader);
        this._container.appendChild(statusDiv);
        this._container.appendChild(this._oDataRefreshButton);
    }
    ```

10. 모든 작업이 완료되면 소스는 다음과 비슷할 것이다.


    ```ts
    import {IInputs, IOutputs} from "./generated/ManifestTypes";

    export class TSWebAPI implements ComponentFramework.StandardControl<IInputs, IOutputs> 
    {
        // Reference to the control container HTMLDivElement
        // This element contains all elements of our custom control example
        private _container: HTMLDivElement;

        // Reference to ComponentFramework Context object
        private _context: ComponentFramework.Context<IInputs>;

        // Name of entity to use for example Web API calls performed by this control
        private static _entityName = "account";

        // Required field on _entityName of type 'single line of text'
        // Example Web API calls performed by example custom control will set this field for new record creation examples
        private static _requiredAttributeName = "name";

        // Value the _requiredAttributeName field will be set to for new created records
        private static _requiredAttributeValue = "Web API Custom Control (Sample)";

        // Name of currency field on _entityName to populate during record create
        // Example Web API calls performed by example custom control will set and read this field
        private static _currencyAttributeName = "revenue";

        // Friendly name of currency field (only used for control UI - no functional impact)
        private static _currencyAttributeNameFriendlyName = "annual revenue";

        // Flag if control view has been rendered
        private _controlViewRendered: boolean;

        // References to button elements rendered by example custom control
        private _createEntity1Button: HTMLButtonElement;
        private _createEntity2Button: HTMLButtonElement;
        private _createEntity3Button: HTMLButtonElement;
        private _deleteRecordButton: HTMLButtonElement;
        private _fetchXmlRefreshButton: HTMLButtonElement;
        private _oDataRefreshButton: HTMLButtonElement;

        // References to div elements rendered by the example custom control
        private _odataStatusContainerDiv: HTMLDivElement;
        private _resultContainerDiv: HTMLDivElement;

        /**
         * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
         * Data-set values are not initialized here, use updateView.
         * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
         * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs ready to be retrieved asynchronously.
         * @param state A piece of data that persists in one session for a single user. Can be set at any point in a controls life cycle by calling 'setControlState' in the Mode interface.
         * @param container If a control is marked control-type='standard', it will receive an empty div element within which it can render its content.
         */
        public init(context: ComponentFramework.Context<IInputs>, notifyOutputChanged: () => void, state: ComponentFramework.Dictionary, container: HTMLDivElement): void {
            this._context = context;
            this._controlViewRendered = false;
            this._container = document.createElement("div");
            this._container.classList.add("TSWebAPI_Container");
            container.appendChild(this._container);
        }

        /**
         * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
         * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
         */
        public updateView(context: ComponentFramework.Context<IInputs>): void {
            this._context = context;
            if (!this._controlViewRendered) {
                this._controlViewRendered = true;

                // Render Web API Examples
                this.renderCreateExample();
                this.renderDeleteExample();
                this.renderFetchXmlRetrieveMultipleExample();
                this.renderODataRetrieveMultipleExample();

                // Render result div to display output of Web API calls
                this.renderResultsDiv();
            }
        }

        /** 
         * It is called by the framework prior to a control receiving new data. 
         * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as "bound" or "output"
         */
        public getOutputs(): IOutputs {
            // no-op: method not leveraged by this example custom control
            return {};
        }

        /** 
         * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup.
         * i.e. cancelling any pending remote calls, removing listeners, etc.
         */
        public destroy(): void {
            // no-op: method not leveraged by this example custom control
        }

        /** 
         * Renders example use of CreateRecord Web API
         */
        private renderCreateExample() {
            // Create header label for Web API sample
            const headerDiv: HTMLDivElement = this.createHTMLDivElement("create_container", true, `Click to create ${TSWebAPI._entityName} record`);
            this._container.appendChild(headerDiv);

            // Create button 1 to create record with revenue field set to 100
            const value1 = "100";
            this._createEntity1Button = this.createHTMLButtonElement(
                this.getCreateRecordButtonLabel(value1),
                this.getCreateButtonId(value1),
                value1,
                this.createButtonOnClickHandler.bind(this));

            // Create button 2 to create record with revenue field set to 200
            const value2 = "200";
            this._createEntity2Button = this.createHTMLButtonElement(
                this.getCreateRecordButtonLabel(value2),
                this.getCreateButtonId(value2),
                value2,
                this.createButtonOnClickHandler.bind(this));

            // Create button 3 to create record with revenue field set to 300
            const value3 = "300";
            this._createEntity3Button = this.createHTMLButtonElement(
                this.getCreateRecordButtonLabel(value3),
                this.getCreateButtonId(value3),
                value3,
                this.createButtonOnClickHandler.bind(this));

            // Append all button HTML elements to custom control container div
            this._container.appendChild(this._createEntity1Button);
            this._container.appendChild(this._createEntity2Button);
            this._container.appendChild(this._createEntity3Button);
        }

        /** 
         * Renders example use of DeleteRecord Web API
         */
        private renderDeleteExample(): void {
            // Create header label for Web API sample
            const headerDiv: HTMLDivElement = this.createHTMLDivElement("delete_container", true, `Click to delete ${TSWebAPI._entityName} record`);

            // Render button to invoke DeleteRecord Web API call
            this._deleteRecordButton = this.createHTMLButtonElement(
                "Select record to delete",
                "delete_button",
                null,
                this.deleteButtonOnClickHandler.bind(this));

            // Append elements to custom control container div
            this._container.appendChild(headerDiv);
            this._container.appendChild(this._deleteRecordButton);
        }

        /** 
         * Renders example use of RetrieveMultiple Web API with OData
         */
        private renderODataRetrieveMultipleExample(): void {
            const containerClassName = "odata_status_container";

            // Create header label for Web API sample
            const statusDivHeader: HTMLDivElement = this.createHTMLDivElement(containerClassName, true, "Click to refresh record count");
            this._odataStatusContainerDiv = this.createHTMLDivElement(containerClassName, false, undefined);

            // Create button to invoke OData RetrieveMultiple Example
            this._fetchXmlRefreshButton = this.createHTMLButtonElement(
                "Refresh record count",
                "odata_refresh",
                null,
                this.refreshRecordCountButtonOnClickHandler.bind(this));

            // Append HTML elements to custom control container div
            this._container.appendChild(statusDivHeader);
            this._container.appendChild(this._odataStatusContainerDiv);
            this._container.appendChild(this._fetchXmlRefreshButton);
        }

        /** 
         * Renders example use of RetrieveMultiple Web API with Fetch XML
         */
        private renderFetchXmlRetrieveMultipleExample(): void {
            const containerName = "fetchxml_status_container";

            // Create header label for Web API sample
            const statusDivHeader: HTMLDivElement = this.createHTMLDivElement(containerName, true,
                `Click to calculate average value of ${TSWebAPI._currencyAttributeNameFriendlyName}`);
            const statusDiv: HTMLDivElement = this.createHTMLDivElement(containerName, false, undefined);

            // Create button to invoke Fetch XML RetrieveMultiple Web API example
            this._oDataRefreshButton = this.createHTMLButtonElement(
                `Calculate average value of ${TSWebAPI._currencyAttributeNameFriendlyName}`,
                "odata_refresh",
                null,
                this.calculateAverageButtonOnClickHandler.bind(this));

            // Append HTML Elements to custom control container div
            this._container.appendChild(statusDivHeader);
            this._container.appendChild(statusDiv);
            this._container.appendChild(this._oDataRefreshButton);
        }

        /** 
         * Renders a 'result container' div element to inject the status of the example Web API calls 
         */
        private renderResultsDiv() {
            // Render header label for result container
            const resultDivHeader: HTMLDivElement = this.createHTMLDivElement("result_container", true,
                "Result of last action");
            this._container.appendChild(resultDivHeader);

            // Div elements to populate with the result text
            this._resultContainerDiv = this.createHTMLDivElement("result_container", false, undefined);
            this._container.appendChild(this._resultContainerDiv);

            // Init the result container with a notification the control was loaded
            this.updateResultContainerText("Web API sample custom control loaded");
        }

        /**
         * Event Handler for onClick of create record button
         * @param event : click event
         */
        private createButtonOnClickHandler(event: Event): void {
            // Retrieve the value to set the currency field to from the button's attribute
            const currencyAttributeValue: number = parseInt(
                (event.target as Element)?.attributes?.getNamedItem("buttonvalue")?.value ?? "0"
            );

            // Generate unique record name by appending timestamp to _requiredAttributeValue
            const recordName = `${TSWebAPI._requiredAttributeValue}_${Date.now()}`;

            // Set the values for the attributes we want to set on the new record
            // If you want to set additional attributes on the new record, add to data dictionary as key/value pair
            const data: ComponentFramework.WebApi.Entity = {};
            data[TSWebAPI._requiredAttributeName] = recordName;
            data[TSWebAPI._currencyAttributeName] = currencyAttributeValue;

            // Invoke the Web API to creat the new record
            this._context.webAPI.createRecord(TSWebAPI._entityName, data).then(
                (response: ComponentFramework.LookupValue) => {
                    // Callback method for successful creation of new record

                    // Get the ID of the new record created
                    const id: string = response.id;

                    // Generate HTML to inject into the result div to showcase the fields and values of the new record created
                    let resultHtml = `Created new ${  TSWebAPI._entityName  } record with below values:`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `id: ${id}`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `${TSWebAPI._requiredAttributeName}: ${recordName}`;
                    resultHtml += "<br />";
                    resultHtml += "<br />";
                    resultHtml += `${TSWebAPI._currencyAttributeName}: ${currencyAttributeValue}`;

                    this.updateResultContainerText(resultHtml);
                },
                (errorResponse) => {
                    // Error handling code here - record failed to be created
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }

        /**
         * Event Handler for onClick of delete record button
         * @param event : click event
         */
        private deleteButtonOnClickHandler(): void {
            // Invoke a lookup dialog to allow the user to select an existing record of type _entityName to delete
            const lookUpOptions: any =
            {
                entityTypes: [TSWebAPI._entityName]
            };

            const lookUpPromise = this._context.utils.lookupObjects(lookUpOptions);

            lookUpPromise.then(
                // Callback method - invoked after user has selected an item from the lookup dialog
                // Data parameter is the item selected in the lookup dialog
                (data: ComponentFramework.LookupValue[]) => {
                    if (data && data[0]) {
                        // Get the ID and entityType of the record selected by the lookup
                        const id: string = data[0].id;
                        const entityType: string = data[0].entityType;

                        // Invoke the deleteRecord method of the WebAPI to delete the selected record
                        this._context.webAPI.deleteRecord(entityType, id).then(
                            (response: ComponentFramework.LookupValue) => {
                                // Record was deleted successfully
                                const responseId: string = response.id;
                                const responseEntityType: string = response.entityType;

                                // Generate HTML to inject into the result div to showcase the deleted record 
                                this.updateResultContainerText(`Deleted ${responseEntityType} record with ID: ${responseId}`);
                            },
                            (errorResponse) => {
                                // Error handling code here
                                this.updateResultContainerTextWithErrorResponse(errorResponse);
                            }
                        );
                    }
                },
                (error) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(error);
                }
            );
        }

        /**
         * Event Handler for onClick of calculate average value button
         * @param event : click event
         */
        private calculateAverageButtonOnClickHandler(): void {
            // Build FetchXML to retrieve the average value of _currencyAttributeName field for all _entityName records
            // Add a filter to only aggregate on records that have _currencyAttributeName not set to null
            let fetchXML = "<fetch distinct='false' mapping='logical' aggregate='true'>";
            fetchXML += `<entity name='${TSWebAPI._entityName}'>`;
            fetchXML += `<attribute name='${TSWebAPI._currencyAttributeName}' aggregate='avg' alias='average_val' />`;
            fetchXML += "<filter>";
            fetchXML += `<condition attribute='${TSWebAPI._currencyAttributeName}' operator='not-null' />`;
            fetchXML += "</filter>";
            fetchXML += "</entity>";
            fetchXML += "</fetch>";

            // Invoke the Web API RetrieveMultipleRecords method to calculate the aggregate value
            this._context.webAPI.retrieveMultipleRecords(TSWebAPI._entityName, `?fetchXml=${  fetchXML}`).then(
                (response: ComponentFramework.WebApi.RetrieveMultipleResponse) => {
                    // Retrieve multiple completed successfully -- retrieve the averageValue 
                    const averageVal: number = response.entities[0].average_val;

                    // Generate HTML to inject into the result div to showcase the result of the RetrieveMultiple Web API call
                    const resultHTML = `Average value of ${TSWebAPI._currencyAttributeNameFriendlyName} attribute for all ${TSWebAPI._entityName} records: ${averageVal}`;
                    this.updateResultContainerText(resultHTML);
                },
                (errorResponse) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }

        /**
         * Event Handler for onClick of calculate record count button
         * @param event : click event
         */
        private refreshRecordCountButtonOnClickHandler(): void {
            // Generate OData query string to retrieve the _currencyAttributeName field for all _entityName records
            // Add a filter to only retrieve records with _requiredAttributeName field which contains _requiredAttributeValue
            const queryString = `?$select=${TSWebAPI._currencyAttributeName  }&$filter=contains(${TSWebAPI._requiredAttributeName},'${TSWebAPI._requiredAttributeValue}')`;

            // Invoke the Web API Retrieve Multiple call
            this._context.webAPI.retrieveMultipleRecords(TSWebAPI._entityName, queryString).then(
                (response: ComponentFramework.WebApi.RetrieveMultipleResponse) => {
                    // Retrieve Multiple Web API call completed successfully
                    let count1 = 0;
                    let count2 = 0;
                    let count3 = 0;

                    // Loop through each returned record
                    for (const entity of response.entities) {
                        // Retrieve the value of _currencyAttributeName field
                        const value: number = entity[TSWebAPI._currencyAttributeName];

                        // Check the value of _currencyAttributeName field and increment the correct counter
                        if (value == 100) {
                            count1++;
                        }
                        else if (value == 200) {
                            count2++;
                        }
                        else if (value == 300) {
                            count3++;
                        }
                    }

                    // Generate HTML to inject into the fetch xml status div to showcase the results of the OData retrieve example
                    let innerHtml = "Use above buttons to create or delete a record to see count update";
                    innerHtml += "<br />";
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 100: ${count1}`;
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 200: ${count2}`;
                    innerHtml += "<br />";
                    innerHtml += `Count of ${TSWebAPI._entityName} records with ${TSWebAPI._currencyAttributeName} of 300: ${count3}`;

                    // Inject the HTML into the fetch xml status div
                    if (this._odataStatusContainerDiv) {
                        this._odataStatusContainerDiv.innerHTML = innerHtml;
                    }

                    // Inject a success message into the result div
                    this.updateResultContainerText("Record count refreshed");
                },
                (errorResponse) => {
                    // Error handling code here
                    this.updateResultContainerTextWithErrorResponse(errorResponse);
                }
            );
        }

        /**
         * Helper method to inject HTML into result container div
         * @param statusHTML : HTML to inject into result container
         */
        private updateResultContainerText(statusHTML: string): void {
            if (this._resultContainerDiv) {
                this._resultContainerDiv.innerHTML = statusHTML;
            }
        }

        /**
         * Helper method to inject error string into result container div after failed Web API call
         * @param errorResponse : error object from rejected promise
         */
        private updateResultContainerTextWithErrorResponse(errorResponse: any): void {
            if (this._resultContainerDiv) {
                // Retrieve the error message from the errorResponse and inject into the result div
                let errorHTML = "Error with Web API call:";
                errorHTML += "<br />";
                errorHTML += errorResponse.message;
                this._resultContainerDiv.innerHTML = errorHTML;
            }
        }

        /**
         * Helper method to generate Label for Create Buttons
         * @param entityNumber : value to set _currencyAttributeNameFriendlyName field to for this button
         */
        private getCreateRecordButtonLabel(entityNumber: string): string {
            return `Create record with ${TSWebAPI._currencyAttributeNameFriendlyName} of ${entityNumber}`;
        }

        /**
         * Helper method to generate ID for Create Button
         * @param entityNumber : value to set _currencyAttributeNameFriendlyName field to for this button
         */
        private getCreateButtonId(entityNumber: string): string {
            return `create_button_${entityNumber}`;
        }

        /**
         * Helper method to create HTML Button used for CreateRecord Web API Example
         * @param buttonLabel : Label for button
         * @param buttonId : ID for button
         * @param buttonValue : value of button (attribute of button)
         * @param onClickHandler : onClick event handler to invoke for the button
         */
        private createHTMLButtonElement(buttonLabel: string, buttonId: string, buttonValue: string | null, onClickHandler: (event?: any) => void): HTMLButtonElement {
            const button: HTMLButtonElement = document.createElement("button");
            button.innerHTML = buttonLabel;

            if (buttonValue) {
                button.setAttribute("buttonvalue", buttonValue);
            }

            button.id = buttonId;

            button.classList.add("SampleControl_TSWebAPI_ButtonClass");
            button.addEventListener("click", onClickHandler);
            return button;
        }

        /**
         * Helper method to create HTML Div Element
         * @param elementClassName : Class name of div element
         * @param isHeader : True if 'header' div - adds extra class and post-fix to ID for header elements
         * @param innerText : innerText of Div Element
         */
        private createHTMLDivElement(elementClassName: string, isHeader: boolean, innerText?: string): HTMLDivElement {
            const div: HTMLDivElement = document.createElement("div");

            if (isHeader) {
                div.classList.add("SampleControl_TSWebAPI_Header");
                elementClassName += "_header";
            }

            if (innerText) {
                div.innerText = innerText.toUpperCase();
            }

            div.classList.add(elementClassName);
            return div;
        }
    }
    ```

    ## 코드 구성요소의 스타일 추가(CSS)

1. TSWebAPI 폴더 안에 CSS 폴더를 추가한다.

2. CSS 폴더 안에 TS_WebAPI.css 파일을 추가한다.

3. TS_WebAPI.css 에 다음 css 스타일을 입력한다.


    ```css
    .SampleNamespace\.TSWebAPI
    {
        font-family: 'SegoeUI-Semibold', 'Segoe UI Semibold', 'Segoe UI Regular', 'Segoe UI';
        color: #1160B7;
    }

    .SampleNamespace\.TSWebAPI .TSWebAPI_Container
    {
        overflow-x: auto;
    }

    .SampleNamespace\.TSWebAPI .SampleControl_WebAPI_Header
    {
        color: rgb(51, 51, 51);
        font-size: 1rem;
        padding-top: 20px;
    }

    .SampleNamespace\.TSWebAPI .result_container
    {
        padding-bottom: 20px;
    }

    .SampleNamespace\.TSWebAPI .SampleControl_WebAPI_ButtonClass
    {
        text-decoration: none;
        display: inline-block;
        font-size: 14px;
        cursor: pointer;
        color: #1160B7;
        background-color: #FFFFFF;
        border: 1px solid black;
        padding: 5px;
        text-align: center;
        min-width: 300px;
        margin-top: 10px;
        margin-bottom: 5px;
        display: block;
    }
    ```


## 빌드 및 실행

1. `npm run build` 를 파워쉘에서 실행해 빌드한다.

2. `npm start` 로 실행해서 잘 적용됬는지 확인한다.

3. 이후 솔루션에 포함시켜서 업로드를 한다.

4. 업로드한 코드 구성 요소를 '거래처' 테이블의 양식에서 적당한 행에 대체하여 넣는다.(코드 구성요소를 모델 기반 앱에서 사용하는 법은 이후 올리겠다.)

5. 실제 모델 기반 앱에서 실행되는 것을 버튼을 클릭하며 확인한다.
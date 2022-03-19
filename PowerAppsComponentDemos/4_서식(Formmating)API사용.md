# Power Apps 코드 구성요소 - 서식(Formatting) 사용
> 보통 코드 구성요소는 Power Apps나 D365에서 사용할 것이다. 사용시 서식을 사용해 특정 방식으로 만들것이다.(보통 화폐) 여기서는 간단한 서식을 사용해보자.

## 코드 구성요소 초기화
1. 다음 명령을 파워쉘에서 실행해 초기화된 프로젝트를 만든다.
```PowerShell
pac pcf init --namespace SampleNamespace --name FormattingAPI --template field
```

2. 다음 명령어를 입력하여 프로젝트에 종속 라이브러리를 로드한다.
```powershell
npm install
```

## 코드 구성요소 로직 구현

1. 코드 구성 요소의 매니페스트 파일(ControlManifest.Input.xml)을 열고 다음과 같이 바꾼다.


```xml
<?xml version="1.0" encoding="utf-8" ?>
<manifest>
<control namespace="SampleNamespace" constructor="FormattingAPI" version="1.1.0" display-name-key="TS_FormattingAPI_Display_Key" description-key="TS_FormattingAPI_Desc_Key" control-type="standard">
    <property name="controlValue" display-name-key="controlValue_Display_Key" description-key="controlValue_Desc_Key" of-type="SingleLine.Text" usage="bound" required="true" />
    <resources>
    <code path="index.ts" order="1" />
    <css path="css/TS_FormattingAPI.css" order="2" />
    </resources>
</control>
</manifest>
```

2. index.ts 파일을 연다.

3. 클래스 내부 최상단에 다음 private 변수를 삽입


```ts
// 업데이트가 발생할떄 호출되는 PCF 프레임워크 대리자
private _notifyOutputChanged: () => void;
// 이 컨트롤을 감싸는 div 요소에 대한 참조
private divElement: HTMLDivElement;

// 제어에 의해 렌더링된 HTMLTableElement에 대한 참조
private _tableElement: HTMLTableElement;

// 제어 컨테이너 HTMLDivElement에 대한 참조
// 이 요소에는 사용자 지정 제어 예제의 모든 요소가 포함되어 있습니다.
private _container: HTMLDivElement;

// 구성 요소 프레임워크 컨텍스트 개체에 대한 참조
private _context: ComponentFramework.Context<IInputs>;

// 컨트롤 뷰가 렌더링된 경우 확인
private _controlViewRendered: Boolean;
};

```

4. 다음 로직을 init 함수 안에 추가한다.


```ts
this._notifyOutputChanged = notifyOutputChanged;
this._controlViewRendered = false;
this._context = context;

this._container = document.createElement("div");
this._container.classList.add("TSFormatting_Container");
container.appendChild(this._container);
```

5. 다음 로직을 updateView 함수 안에 추가한다.


```ts
if (!this._controlViewRendered)
        {
            // Render and add HTMLTable to the custom control container element
            let tableElement: HTMLTableElement = this.createHTMLTableElement();
            this._container.appendChild(tableElement);

            this._controlViewRendered = true;
        }
```

6. 다음 Html 테이블을 생성하는 함수를 추가한다.


```ts
/**
 * Helper method to create an HTML Table Row Element
    * @param key : string value to show in left column cell
    * @param value : string value to show in right column cell
    * @param isHeaderRow : true if method should generate a header row
    */
private createHTMLTableRowElement(key: string, value: string, isHeaderRow: boolean): HTMLTableRowElement
{
    let keyCell: HTMLTableCellElement = this.createHTMLTableCellElement(key, "FormattingControlSampleHtmlTable_HtmlCell_Key", isHeaderRow);
    let valueCell: HTMLTableCellElement = this.createHTMLTableCellElement(value, "FormattingControlSampleHtmlTable_HtmlCell_Value", isHeaderRow);

    let rowElement: HTMLTableRowElement = document.createElement("tr");
    rowElement.setAttribute("class", "FormattingControlSampleHtmlTable_HtmlRow");
    rowElement.appendChild(keyCell);
    rowElement.appendChild(valueCell);

    return rowElement;
}

/**
 * Helper method to create an HTML Table Cell Element
    * @param cellValue : string value to inject in the cell
    * @param className : class name for the cell
    * @param isHeaderRow : true if method should generate a header row cell
    */
private createHTMLTableCellElement(cellValue: string, className: string, isHeaderRow: boolean): HTMLTableCellElement
{
    let cellElement: HTMLTableCellElement;

    if (isHeaderRow)
    {
        cellElement = document.createElement("th");
        cellElement.setAttribute("class", "FormattingControlSampleHtmlTable_HtmlHeaderCell " + className);
        let textElement: Text = document.createTextNode(cellValue);
        cellElement.appendChild(textElement);
    }
    else
    {
        cellElement = document.createElement("td");
        cellElement.setAttribute("class", "FormattingControlSampleHtmlTable_HtmlCell " + className);
        let textElement: Text = document.createTextNode(cellValue);
        cellElement.appendChild(textElement);
    }
    return cellElement;
}
```

7. 다음 서식 API를 이용해 값을 집어넣는 함수를 추가한다.


```ts
/** 
* Creates an HTML Table that showcases examples of basic methods available to the custom control
* The left column of the table shows the method name or property that is being used
* The right column of the table shows the result of that method name or property
*/
private createHTMLTableElement(): HTMLTableElement
{
    // Create HTML Table Element
    let tableElement: HTMLTableElement = document.createElement("table");
    tableElement.setAttribute("class", "FormattingControlSampleHtmlTable_HtmlTable");

    // Create header row for table
    let key: string = "Example Method";
    let value: string = "Result";
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, true));

    // Example use of formatCurrency() method 
    // Change the default currency and the precision or pass in the precision and currency as additional parameters.
    key = "formatCurrency()";
    value = this._context.formatting.formatCurrency(10250030);
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    // Example use of formatDecimal() method 
    // Change the settings from user settings to see the output change its format accordingly
    key = "formatDecimal()";
    value = this._context.formatting.formatDecimal(123456.2782);
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    // Example use of formatInteger() method
    // change the settings from user settings to see the output change its format accordingly.
    key = "formatInteger()";
    value = this._context.formatting.formatInteger(12345);
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    // Example use of formatLanguage() method
    // Install additional languages and pass in the corresponding language code to see its string value
    key = "formatLanguage()";
    value = this._context.formatting.formatLanguage(1033);
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    // Example of formatDateYearMonth() method
    // Pass a JavaScript Data object set to the current time into formatDateYearMonth method to format the data
    // and get the return in Year, Month format
    key = "formatDateYearMonth()";
    value = this._context.formatting.formatDateYearMonth(new Date());
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    // Example of getWeekOfYear() method
    // Pass a JavaScript Data object set to the current time into getWeekOfYear method to get the value for week of the year
    key = "getWeekOfYear()";
    value = this._context.formatting.getWeekOfYear(new Date()).toString();
    tableElement.appendChild(this.createHTMLTableRowElement(key, value, false));

    return tableElement;
}
```

## 코드 구성요소의 스타일 추가(CSS)

1. ReactContorl 폴더 안에 CSS 폴더를 추가한다.

2. CSS 폴더 안에 ReactStandardControl.css 파일을 추가한다.

3. ReactStandardControl.css 에 다음 css 스타일을 입력한다.


```css
.SampleNamespace\.FormattingAPI
{
font-family: 'SegoeUI-Semibold', 'Segoe UI Semibold', 'Segoe UI Regular', 'Segoe UI';
}

.SampleNamespace\.FormattingAPI .TSFormatting_Container
{
    overflow-x: auto;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlRow
{
    background-color: #FFFFFF;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlHeaderCell
{
    text-align: center;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlCell, 
.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlHeaderCell
{
    border: 1px solid black;
    padding-left: 3px;
    padding-right: 3px;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlInputTextCell
{
    border: 1px solid black;
    padding: 0px;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlHeaderCell
{
    font-weight: bold;
    font-size: 16px;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlCell_Key
{
    color: #1160B7;
}

.SampleNamespace\.FormattingAPI .FormattingControlSampleHtmlTable_HtmlCell_Value
{
    color: #1160B7;
    text-align: center;
}
```

## 빌드 및 실행

1. `npm run build` 를 파워쉘에서 실행해 빌드한다.

2. `npm start` 로 실행해서 잘 적용됬는지 확인한다.<br>![image](https://user-images.githubusercontent.com/39551265/158758442-c462925d-2cb8-4c79-97f2-b2f9649c523f.png)<br>
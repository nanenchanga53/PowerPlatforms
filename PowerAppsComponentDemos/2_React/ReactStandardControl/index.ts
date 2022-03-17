import { IInputs, IOutputs } from "./generated/ManifestTypes";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { FacepileBasicExample, IFacepileBasicExampleProps } from "./Facepile";

export class ReactStandardControl
  implements ComponentFramework.StandardControl<IInputs, IOutputs> {
  // notifyOutputChanged 매소드의 참조
  private notifyOutputChanged: () => void;
  // 컨테이너 div의 참조
  private theContainer: HTMLDivElement;
  // 반환 이벤트 처리기로 미리 정의된 React 요소에 대한 참조
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
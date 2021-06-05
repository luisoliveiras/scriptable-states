# Scriptable States
![GitHub release (latest by date)](https://img.shields.io/github/v/release/luisoliveiras/scriptable-states?label=current%20release)
![GitHub package.json version (branch)](https://img.shields.io/github/package-json/v/luisoliveiras/scriptable-states/develop?label=develop)


## What is this?
Scriptable States is a `ScriptableObject` based implementaton of a Finite State Machine.   
It's main purpose is to create reusable behaviour bits like the `ScriptableAction` and the `ScriptableCondition`, and be able to create and edit a `ScriptableState` using those actions and sequencing those states with a `ScriptableStateMachine` setting transitions with those conditions to create unique behaviour through the editor.

---
## Installation:
##### On Unity 2018.4:
Download this package to your disk.
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from disk...** option and then add the ScriptableStates package.

##### On Unity 2019.1 and above:
Open the project manifest file under the Packages folder and add these lines to the dependencies:
```json
"dependencies": {
  ...  
    "com.loophouse.scriptable-states":"https://github.com/luisoliveiras/scriptable-states.git#v0.4.0",
  ...
}

```

##### On Unity 2019.3 and above:
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from git URL...** option and then add the ScriptableStates package link:  
https://github.com/luisoliveiras/scriptable-states.git#v0.4.0

_\* You can also add it from disk if you want, just follow the steps from 2018.4 install guide._\
_\** You can can choose another version of the tool by changing the end of the link (#v0.4.0) for the version you want. Versions under v0.4.0 have a dependency on the reorderable list package._


---
## How to Use
#### Setting up a State:
Access _**Create > Scriptable State Machine > State**_ like the image below.
![Scriptable State on Create Menu](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/create_menu_state_02.png?raw=true)

Select a name for your state and you should be ready to use it. The image below is what you should get from creating a state asset.

![Scriptable State Asset on Inspector](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/inspector_state_01.png?raw=true)

As you can see from the image, a state contains five lists: **Entry Actions**, **Exit Actions**, **Physics Actions** and **State Actions**.
- **Entry Actions** are excecuted only once, when there is a transition to the state.
- **Exit Actions** are executed only once, when there is a transition from the state.
- **Physics Actions** are executed in the `FixedUpdate()` method.
- **State Actions** are executed in the `Update()` method.

#### Creating a State Machine
Access _**Create > Scriptable State Machine > State Machine**_ like the image below.
![Scriptable State on Create Menu](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/create_menu_state_machine_01.png?raw=true)

To set up a **State Machine** you will need an _Initial State_, from where your state machine will start, an _Empty State_ reference, which will be used when comparing the transitions responses and a list of all possible _Transitions_ for that state machine.

![Scriptable State Machine Inspector](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/inspector_state_machine_01.png?raw=true)

**Transitions** are executed in the `LateUpdate()` method of the `StateComponent`, where based on the current state of the state machine a condition will be tested, triggering a move (or not) to the next state. A _Transition_ contains a _Origin State_ that will be compared to the current state, a `ScriptableCondition` that will be tested, a _True State_, achieved when the condition is met, and a _False State_ when not.

![Scriptable State Machine Transition on Inspector](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/inspector_transition_01.png?raw=true)

#### Creating Actions
Create a _C#_ script inheriting from `ScriptableAction` and add a CreateMenu attribute to it like in the example below:

```csharp
[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MyAction", fileName = "new MyAction")]
public class MyAction : ScriptableAction
{
    //Add some variables here to setup your action
	public override void Act(StateComponent stateComponent)
	{
        // put your code here
        // You can use the stateComponent to get other components in your game object
	}
}
```
With this done, you're ready to create some action from the **_Create > Scriptable State Machine > Actions_** menu. By adding variables to your action and making them visible in the inspector, you can create variations for that action, like a _MoveAction_ with different values for speed.

#### Creating Conditions
Create a _C#_ script inheriting from `ScriptableCondition` and add a CreateMenu attribute to it like in the example below:

```csharp
[CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/MyCondition", fileName = "new MyCondition")]
public class MyCondition : ScriptableCondition
{
    //Add some variables here to setup your condition
	public override bool Verify(StateComponent stateComponent)
	{
        // put your code here
        // You can use the stateComponent to get other components in your game object
	}
}
```
With this step completed, it is now possible to create a condition from the **_Create > Scriptable State Machine > Conditions_** menu and start setting up your states' transitions. The states transitions uses the value returned from the condition's Verify method to determine if should go to the state referenced in the _True State_ or _False State_.
You can add variables and set them visible in the inspector to create variations of that condition, like a _DetectionCondition_ that uses a float to determine the detection radius.

#### Creating the State Component
Create the `GameObject` that will driven by the state machine, in the Inspector, click in **Add Component** and search for `StateComponent` and add it to your game object.

![States Component](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/inspector_state_component_1.gif?raw=true)

To set up this component, add a `ScriptableStateMachine` on the _State Machine_ field. By doing this, the `StateComponent` will start on the _Initial State_ set on the _State Machine_, running its _actions_ while testing the _State Machine_'s _transitions_ for new states. While in play mode, the _Current State_ will show the current state of this component in green and if something go wrong with your states or if it is not in play mode, it will show "_None_" in red.

Following this steps you should not have problems setting up your states machines.

\* When creating your actions and conditions, remember that they can be used by more then one object, and you should not change the values of the variables added to them in runtime, or you'll change the value for all the objects using them, unless that's your expected behaviour. Think of the values you expose in the actions and conditions editor as constants for that behaviour piece.

---
## Samples
#### Script Templates:

**What:** It adds create menu options to make it easier to create a `ScriptableAction` or `ScriptableCondition` script by adding them to the _Create menu_ with all the information they need.

![Scriptable Action Script on Create Menu](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/create_menu_action_script_01.png?token=ADU3KQA32EBV5SCMUFPBPUK64WT64)

![Scriptable Condition Script on Create Menu](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/create_menu_condition_script_01.png?token=ADU3KQGNMLPQYYMZDTZSECK64WT2O)

**How:** Move the _ScriptTemplates_ folder from _Samples_ to your _Assets_ folder (root) and restart the editor. The _"Scriptable Action Script"_ and _"Scriptable Condition Script"_ options will be available under the Create menu options. If you already have a ScriptTemplates folder in your project, just move the assets inside the _Samples/ScriptTemplates_ folder to it and restart the editor.

#### Follow Behavior Example:

**What:** A Simple implementation of movement, stamina and follow behaviour using _scriptable states, scriptable state machines, actions and conditions_.

![Follow Behaviour Example](https://github.com/luisoliveiras/project-images/blob/master/scriptable-states/v0.4.0/follow_behaviour_example.gif?raw=true)


**How:** Install the sample from the Package Manager UI. Open the _FollowBehaviourExample_ scene inside the _Follow Behaviour Example_ folder added to your project's _Assets_ folder and you're ready to go.  
_\* This sample requires the new unity Input System to work._

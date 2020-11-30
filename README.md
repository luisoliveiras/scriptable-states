# Scriptable States
![GitHub package.json version](https://img.shields.io/github/package-json/v/luisoliveiras/scriptable-states?color=green)


## What is this?
Scriptable States is a `ScriptableObject` based implementaton of a Finite State Machine.   
It's main purpose is to create reusable behaviour bits like the `ScriptableAction` and the `ScriptableCondition`, and be able to create and edit a sequence of possible states using the `ScriptableState`, using those actions and conditions to create unique behaviour through the editor.

---
## Installation:
##### On Unity 2018.4:
Download this package and the [ReorderableList](https://github.com/cfoulston/Unity-Reorderable-List) package to your disk.
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from disk...** option.
- Add the ReorderableList package.
- Add the ScriptableStates package.

_\* The order is important as the custom editor for ScriptableState uses the reorderable lists._

##### On Unity 2019.1 and above:
Open the project manifest file under the Packages folder and add these lines to the dependencies:
```json
"dependencies": {
  ...
    "com.malee.reorderablelist": "https://github.com/cfoulston/Unity-Reorderable-List.git",   
    "com.loophouse.scriptable-states":"https://github.com/luisoliveiras/scriptable-states.git",
  ...
}

```

##### On Unity 2019.3 and above:
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from git URL...** option.
- Add the ReorderableList package from: https://github.com/cfoulston/Unity-Reorderable-List.git
- Add the ScriptableStates package from: https://github.com/luisoliveiras/scriptable-states.git

_\* The order is important as the custom editor for ScriptableState uses the reorderable lists._   
_\** You can also add it from disk if you want, just follow the steps from 2018.4 install guide._

---
## How to Use
#### Setting up a State:
Access _**Create > Scriptable State Machine > State**_ like the image below.
![Scriptable State on Create Menu](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/create_menu_state_01.png?token=ADU3KQGHSWLQQHG5D7XG2LK64W2PC)

Select a name for your state and you should be ready to use it. The image below is what you should get from creating a state asset.

![Scriptable State Asset on Inspector](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/inspector_state_01.png?token=ADU3KQFACBTJZPANEYHWPV264ZE3K)

As you can see from the image, a state contains five lists: **Entry Actions**, **Exit Actions**, **Physics Actions**, **State Actions** and **Transitions**.
- **Entry Actions** are excecuted only once, when there is a transition to the state.
- **Exit Actions** are executed only once, when there is a transition from the state.
- **Physics Actions** are executed in the `FixedUpdate()` method.
- **State Actions** are executed in the `Update()` method.
- **Transitions** are executed in the `LateUpdate()` method, where a condition will be tested, triggering a move (or not) to the next state.

A **Transition** contains a `ScriptableCondition` that will be tested, a _True State_, achieved when the condition is met, and a _False State_ when not.

#### Creating Actions
Create a _C#_ script inheriting from ScriptableAction and add a CreateMenu attribute to it like in the example below:

```csharp
[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MyAction", fileName = "new MyAction")]
public class MyAction : ScriptableAction
{
    //Add some variables here to setup your action
	public override void Act(ScriptableStatesComponent statesComponent)
	{
        // put your code here
        // You can use the statesComponent to get other components in your game object
	}
}
```
With this done, you're ready to create some action from the **_Create > Scriptable State Machine > Actions_** menu. By adding variables to your action and making them visible in the inspector, you can create variations for that action, like a MoveAction with different values for speed.

#### Creating Conditions
Create a _C#_ script inheriting from ScriptableCondition and add a CreateMenu attribute to it like in the example below:

```csharp
[CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/MyCondition", fileName = "new MyCondition")]
public class MyCondition : ScriptableCondition
{
    //Add some variables here to setup your condition
	public override bool Verify(ScriptableStatesComponent statesComponent)
	{
        // put your code here
        // You can use the statesComponent to get other components in your game object
	}
}
```
With this step completed, it is now possible to create a condition from the **_Create > Scriptable State Machine > Conditions_** menu and start setting up your states' transitions. The states transitions uses the value returned from the condition's Verify method to determine if should go to the state referenced by the _True State_ or _False State_.
You can add variables and set them visible in the inspector to create variations of that condition, like a DetectionCondition that uses a float to determine the detection radius.

#### Creating the States Component
Create the `GameObject` that will driven by the state machine, in the Inspector, click in **Add Component** and search for `ScriptableStatesComponent` and add it to your game object.

![Scriptable States Component](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/inspector_states_component_02.gif)

To set up this component, add the starting state of your state machine to the _Initial State_ field, and for the _Empty State_ field, click on it and search for the **_EmptyState_** asset that comes with this package. While in play mode, the **_Current State_** will show the current state of this component in green, if something go wrong with your states or if it is not in play mode, it will show "**None**" in red.

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

**What:** A Simple implementation of movement, stamina and follow behaviour using _scriptable states, actions and conditions_.

![Follow Behaviour Example](https://raw.githubusercontent.com/luisoliveiras/project-images/master/scriptable-states/follow_behaviour_example.gif)


**How:** Install the sample from the Package Manager UI. Open the _FollowBehaviourExample_ scene inside the _Follow Behaviour Example_ folder added to your project's _Assets_ folder and you're ready to go.

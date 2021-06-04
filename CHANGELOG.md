# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
---

## [0.4.0] - 2021-06-02
### Added
- New ScriptableStateMachine class, containing a list of all possible transitions for that state machine, making states more reusable.

### Changed
- ScriptableStatesComponent now only have a reference to the ScriptableStateMachine, that has the references to the initial state and empty state for that machine.
- ScriptableState no longer has a list of transitions. Entry actions, exit actions, physics actions and state actions remain.

### Removed
- ReorderableList package has been removed. It is recommended to use Unity 2020.3 or higher from now on. (lists and arrays are now reorderable on Unity)

---

## [0.3.0] - 2020-11-09
### Changed
- Company name changed from devludico to loophouse.
- The namespace devludico was changed to loophouse.
- Updated README (now it has some gifs!)

---
## [0.2.0] - 2020-09-02
### Added
- New Sample Folder - Follow Behaviour Example, with some use example.
- New Inspector UI for ScriptableStatesComponent.
- New logs for errors, highlighting the correct object or scriptable that caused it.
- Description for the Follow Behaviour Example into the README Samples Section.
- Version tag into the README file.

### Changed
- ScriptableCondition Verify parameter name changed from smComponent to statesComponent, as in ScriptableAction's Act method.

## [0.1.0] - 2020-06-14
### Added
- Base scripts of the tool, ScriptableState, ScriptableAction and ScriptableCondition.
- Sample folder with a usability trick.
- Instalation and use guide into the README file.

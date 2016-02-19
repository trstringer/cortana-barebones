# Cortana Barebones Sample

There are a few great examples out there on how to robustly implement Cortana development in a UWP application (namely the [Cortana Voice Command Sample in the Windows-universal-samples repository](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CortanaVoiceCommand)), but if you're looking for the bare necessities on how to have a background service that can be implemented and invoked through Voice (Cortana) then take a look at this solution.

For all intents and purposes, this is the bare minimum code in a blank UWP app that is needed to be invoked via Cortana voice commands.

## Contents

- **RandomThought** - this is the project that includes the UWP application
- **VoiceCommandService** - this is the project that includes the runtime component for the background service

## Build/Run

1. Clone the repository to your local system
2. Open up the solution in Visual Studio 2015
3. Build and run the solution

## Usage

Once you have run the application for the first time, you simply need to speak the following into Cortana:

*"Random Thought, tell me something interesting"*

Cortana should come back with a comment that she doesn't have anything interesting to say because it is whatever day of the week it is.

> :bulb: This is the only command that this service will recognize in the true essence of "least possible code"

## Next Steps...

This can provide a good **base** sample for learning purposes.  Add onto this with more powerful and complex aspects of voice integration with Cortana, and I urge you to use the [Cortana Voice Command Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CortanaVoiceCommand) as a reference for those tasks.
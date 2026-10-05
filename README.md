# Vocabulary C# / Unity Code Sample

A legacy Unity/C# vocabulary-learning and quiz application. The repository is retained as a code sample demonstrating hands-on C# development, game/application state management, quiz logic, local progress tracking, and integration points for Google Play Services.

## Authored Code

The primary application code I wrote is under:

```text
Assets/Resources/Scripts/
```

Key areas include:

- `Game/` - quiz flow, scoring, timers, answer handling, and session logic
- `Menu/` - menu state, navigation, difficulty and category selection
- `Classes/` - player/application data structures
- `ForJSON/` - serializable data models used by the quiz content
- `PlayServices.cs` - Google Play Games integration points

## Highlights

- Unity and C#
- Multi-category vocabulary and quiz workflows
- Difficulty selection and timed questions
- Score, correct/incorrect/blank-answer tracking
- Player progress stored with Unity `PlayerPrefs`
- JSON-backed learning content
- Menu and UI state management
- Google Play Games leaderboard and achievement integration

## Repository Scope

This is an older code sample, not a complete modern build-ready Unity project. The repository primarily preserves the authored gameplay/application code and supporting resources.

Third-party plugin source, generated service identifiers, local build artifacts, and machine-specific files are intentionally excluded so that the repository focuses on the application code itself.

## Notes

The project reflects an earlier stage of my software-development work and is kept to show practical C# and Unity experience alongside my more recent Python, AI, and application-development work.

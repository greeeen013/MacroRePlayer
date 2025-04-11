# MacroRePlayer ⌨️🖱️

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![GitHub stars](https://img.shields.io/github/stars/greeeen013/MacroRePlayer)](https://github.com/greeeen013/MacroRePlayer/stargazers)

**MacroRePlayer** is a lightweight and easy-to-use application for **recording**, **editing**, and **replaying** mouse and keyboard events.  
It aims to simplify the automation of repetitive tasks — without writing a single line of code.  
Packed with a built-in editor, advanced configuration, and playback features, it's ideal for both casual and power users.

---

## Table of Contents
1. [Key Features](#key-features-✨)
2. [Installation](#installation-🛠️)
3. [Requirements](#Requirements-🎯)
4. [Getting Started](#getting-started-🚀)
5. [Detailed Use](#Detailed-Use-📖)
   - [Recording](#Recording)
   - [Editing](#Editing)
   - [Replaying](#(Re)Playing)
6. [Configuration (coming soon)](#Configuration-⚙️-(TODO))
7. [Planned Features (TODO)](#Planned-Features-🗺️-(TODO))
8. [Contributing](#contributing)
9. [License](#license)

---

## Key Features ✨

- 🔴 **Macro Recording** – Records mouse and keyboard events with millisecond-level precision.
- ✏️ **Editor** – Modify your macros with a full-featured editor:
  - Reorder, copy, delete, and insert events.
  - Adjust timing between actions.
  - Visual event list with ComboBox file selector.
- 🔁 **Replay** – Play back macros with options for:
  - One-time or repeated execution.
  - Adjustable playback speed.
  - Hotkey support for quick start/stop.
- ⚙️ **Settings** – Customize defaults like playback speed, delays, theme, and more.
- 💾 **Save & Config** – Configuration is saved via `.cfg` file.
- 🧠 **Intuitive UI** – Clean interface with helpful tooltips for beginners and advanced users alike.
---

## Download ⬇️

You can download the latest `.exe` version from the **[Releases page](https://github.com/greeeen013/MacroRePlayer/releases)**.  
No installation required — just download and run.

> **Note**: If you're a developer, you can clone the repository using:
> ```bash
> git clone https://github.com/greeeen013/MacroRePlayer.git
> ```

---

### Requirements 🎯

  - none at this time

---

## Getting Started 🚀

- Launch the application.
- Use the top buttons to **Record**, **Edit**, or **Replay** a macro.
- Define keybinds in settings for quick control.
- Save and load macros as `.json` files.

---

## Detailed Use 📖

### Record
1. Click **Start Recording**.
2. Perform mouse/keyboard actions.
3. Click **Stop Recording**.
4. Your session is automatically saved as a `.json` file.

### Edit
1. Open the **Editor**.
2. Select a recorded file from the dropdown.
3. Modify entries:
   - Reorder with **Drag & Drop**.
   - **Copy**, **Delete**, **Extract/Insert**.
   - Adjust **values**.
   - **Visual icons per event type** coming soon.

### (Re)Play
1. Open the **RePlayer** form and look for **Player** section.
2. Select a `.json` file
3. Choose playback **mode** and **speed**.
4. Start or stop using a **keybind** or UI button.
5. Precise timing and corrected **delay logic**.

---

## Configuration ⚙️
- the `.cfg` file should create automatically when needed to save some data and by default it should look like this
[Settings]
ExecutionPlayer="C#"
FormTheme="White"
PlayerStartUpDelay=0
DefaultPlaybackMethod="One time play"
DefaultPlaybackHowManyTimesRepeat=1
DefaultPlaybackSpeed="1x"
KeyRepeating=False
KeyDelayBeforeRepetetion=200
PlayerDelayEventOffset=0
KeyRepetetionRate=5
AutoDeleteLastClick=False
StartStopPlayingMacroKey=""
StartStopPlayingMacroHexKey=

---

## Planned Features 🗺️

- **Key repeating control** – Allows a key to be held down for a longer period of time to type multiple characters instead of one (ideal for text fields).
- **Event icons in Editor** – Add visual icons for each event type to enhance navigation.
- **Python macro execution** – Future idea to allow running macros via Python scripts.
- **Loop/conditional logic** – Add support for loops in **EditorForm** and conditions in macros.
- **Theme customization** – Allow users to choose and customize the application theme.
- **Full mouse movement tracking** – Long-term goal to track and replay entire mouse movements (not just where it was pressed and released)

---

## Contributing ℹ️

Feel free to open an issue or submit a PR:

1. **Fork** the repo.
2. **Create a feature branch**.
   ```bash
   git checkout -b feature/your-feature
3. **Commit & push changes.**
   ```bash
   git commit -m "feat: add feature"
   git push origin feature/your-feature

---

## Issues / Support 🚩

Found a bug or have a suggestion? Open an issue here:
👉 [Issue Tracker](https://github.com/greeeen013/MacroRePlayer/issues)

---

## Screenshots 📷

![RePlayerForm](https://github.com/user-attachments/assets/1ade1cfb-54d5-4710-9b5f-28675330f4fd)

![SettingsForm](https://github.com/user-attachments/assets/c39a0737-5d7a-49a2-845c-3a7da88689ae)

![EditorForm](https://github.com/user-attachments/assets/02eb6320-0cf9-4d35-aaf5-7ae250d57726)

---

Thank you for your interest in MacroRePlayer! We hope it helps you automate repetitive tasks and allows you to focus on more important and creative work.
